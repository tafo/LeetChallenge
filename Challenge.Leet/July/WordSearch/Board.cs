using System;
using System.Linq;

namespace Challenge.Leet.July.WordSearch
{
    public class Board
    {
        public char[] Chars;
        public char[][] Matrix;
        public int RowSize;
        public int ColSize;

        public void FillTable(int rowSize, params char[] chars)
        {
            Chars = chars;
            RowSize = rowSize;
            ColSize = Chars.Length / rowSize;
            Matrix = Enumerable.Range(1, RowSize).Select(x => new char[ColSize]).ToArray();
            var i = 0;
            Array.ForEach(Chars, c =>
            {
                Matrix[i / ColSize][i % RowSize] = c;
                i++;
            });
        }
    }
}