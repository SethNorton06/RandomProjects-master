using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        TicTacToePanel[,] panels = new TicTacToePanel[3,3];
        GameManager gameManager;


        // Networking

        TcpListener server;
        TcpClient client;
        Socket networkSocket;
        EndPoint epLocal, epRemote;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        byte[] buffer;



        bool multiplayer = false;
        bool turn = true;
        char character = 'X';

        public TicTacToeForm()
        {
            InitializeComponent();
            CreatePanels();
            gameManager = new GameManager();
        }

        public TicTacToeForm(bool multiplayer, bool host, string serverIp = null)
        {
            InitializeComponent();
            CreatePanels();
            gameManager = new GameManager();
            this.multiplayer = multiplayer;

            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if (host)
            {
                StartSocket();
            }
            else
            {
                try
                {
                    client = new TcpClient(serverIp, 5732);
                    networkSocket = client.Client;
                    character = 'O';
                    turn = false;
                    MessageReceiver.RunWorkerAsync();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    this.Close();
                }
            }


        }

        private async void StartSocket()
        {
            server = new TcpListener(IPAddress.Any, 5732);
            server.Start();
            networkSocket = await server.AcceptSocketAsync();  // accept the incoming connection
        }




        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            return;
            // throw new NotImplementedException();
        }

        public void CreatePanels()
        {
            int x = 0;
            int y = 0;
            // There will be nine panels
            Debug.WriteLine("===============================================");
            for (int i = 0; i < 3; i++)
            {
                TicTacToePanel p = null;
                for (int j = 0; j < 3; j++)
                {
                    const int HEIGHT = 100;
                    const int WIDTH = 100;

                    p = new TicTacToePanel();
                    p.Size = new Size(WIDTH, HEIGHT);
                    p.Location = new Point(x, y);
                    p.Click += PanelClick;
                    p.Paint += p.CharacterInPanelChange;
                    if (i != 2)
                        CreateHorizontalLines(new Rectangle(p.Location.X, p.Location.Y + HEIGHT + 1, 100, 10));
                    if(j != 2)
                        CreateVerticalLines(new Rectangle(p.Location.X  + WIDTH, p.Location.Y, 10, 100));

                    Debug.WriteLine($"Panel {i+j}: " + p.Location);
                    p.BackColor = Color.Aquamarine;
                    x += p.Size.Width + 10;
                    this.Controls.Add(p);
                    panels[i, j] = p;
                    Debug.WriteLine($"Inner Loop {i}: " + this.Controls.Count);
                }
                x = 0;
                y += p.Size.Height + 10; 
                Debug.WriteLine($"Loop {i}: " + this.Controls.Count);
            }
            Debug.WriteLine($"Panel Count: {this.Controls.Count}");
            Debug.WriteLine("===============================================");
        }

        private void PanelClick(object sender, EventArgs e)
        {
            if(turn)
            {
                TicTacToePanel p = sender as TicTacToePanel;

                foreach (var pa in panels)
                {
                    if (pa.BackColor == Color.Orange)
                        pa.BackColor = Color.Aquamarine;
                }



                if (p.BackColor == Color.Aquamarine)
                    p.BackColor = Color.Orange;
                else
                    p.BackColor = Color.Aquamarine;


                bool invalidSelection = true;
                while (invalidSelection)
                {

                    InputForm inputChoice = new InputForm(character);
                    DialogResult inputResult = inputChoice.ShowDialog();
                    if (inputResult == DialogResult.OK)
                    {
                        string text = inputChoice.TextField;
                        if (text != String.Empty && text[0] != '\0' && p.CharacterInPanel == '\0')
                        {
                            p.CharacterInPanel = text[0];
                            invalidSelection = false;
                        }
                        p.Invalidate();
                        p.Update();

                        if (character == 'X' && !invalidSelection)
                            character = 'O';
                        else if(!invalidSelection)
                            character = 'X';

                        if (multiplayer && !invalidSelection)
                            turn = false;

                        invalidSelection = false;
                    }
                }

                


                char winner = ' ';
                bool win = gameManager.CheckWinCondition(panels, out winner);
                if ((winner != '\0' || winner != ' ') && win)
                {
                    // Logic to end the game
                    Winning w = new Winning($"{winner} won the game");
                    this.Close();
                }
                if(multiplayer && !turn)
                    SendMove(p.Location);
                    
            }
            else
            {
                await ReceiveMove();
            }
            
        }

        private async void ReceiveMove()
        {
            byte[] buffer = new byte[(sizeof(int) * 2) + sizeof(char)];
            int bytesReceived;
            while( (bytesReceived = networkSocket.Receive(buffer, 0, (sizeof(int) * 2) + sizeof(char), SocketFlags.None)) > 0)
            {
                byte[] actualBytesRead = new byte[bytesReceived];
                Buffer.BlockCopy(buffer, 0, actualBytesRead, 0, bytesReceived);
            }

        }

        private void SendMove(Point panelLocation)
        {
            using (var MemoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Send the indexes
                formatter.Serialize(MemoryStream, panelLocation.X);
                formatter.Serialize(MemoryStream, panelLocation.Y);

                // send the character
                formatter.Serialize(MemoryStream, character);


                networkSocket.Send(MemoryStream.GetBuffer(), (sizeof(int) * 2) + sizeof(char), SocketFlags.None);
            }
        }

        public void CreateHorizontalLines(Rectangle r)
        {
            Panel p = new Panel();
            p.Size = new Size(r.Width, r.Height);
            p.Location = new Point(r.X, r.Y);
            p.BackColor = Color.Black;
            this.Controls.Add(p);

            // Debug.WriteLine($"Rectangle Horizontal: " + this.Controls.Count);
        }

        public void CreateVerticalLines(Rectangle r)
        {
            Panel p = new Panel();
            p.Size = new Size(r.Width, r.Height);
            p.Location = new Point(r.X, r.Y);
            p.BackColor = Color.Black;
            this.Controls.Add(p);

            // Debug.WriteLine($"Rectangle Vertical: " + this.Controls.Count);
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            variableBox.Text = "Player turn: " + turn + "\n";
        }

        private void TicTacToeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Begin begin = new Begin();
            begin.Show();
        }
    }
}
