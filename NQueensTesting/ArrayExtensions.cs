using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueensTesting
{
    internal static class ArrayExtensions
    {

        public static IEnumerable<int> SliceRow<T>(this int[,] array, int row)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                yield return array[row, i];
            }
        }

    }
}
