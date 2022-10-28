using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BinarySearch
{
    public class BinaryTree<T> where T : IEquatable<T>, IComparable<T>
    {
        Node<T> root;
        List<Node<T>> nodeList;

        public class Node<T> where T : IEquatable<T>, IComparable<T>
        {
            public T? value;
            public Node<T>? left, right;

            public Node(T value)
            {
                this.value = value;
            }

            public Node(T value, Node<T> leftNode, Node<T> rightNode)
            {
                this.value = value;
                this.left = leftNode;
                this.right = rightNode;
            }

            internal int CompareTo(Node<T> node)
            {
                return Comparer<T>.Default.Compare(this.value, node.value);
            }
        }

        public BinaryTree()
        {
            nodeList = new List<Node<T>>();
            #pragma warning disable CS8604 // Possible null reference argument.
            root = new Node<T>(default);
            #pragma warning restore CS8604 // Possible null reference argument.
            nodeList.Add(root);
        }

        public void Add(T element)
        {
            int index = 0;
            Node<T> elementNode = new Node<T>(element);
            {

            }





            nodeList.Add(elementNode);
        }
    }
}
