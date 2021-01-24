using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.TwentyOne.SortTheMatrixDiagonally
{
    public class Solution
    {
        public int[][] DiagonalSort(int[][] mat)
        {
            var rowCount = mat.Length;
            var columnCount = mat[0].Length;
            for (var i = 0; i < rowCount; i++)
            {
                Sort(i, 0);
            }

            for (var j = 0; j < columnCount; j++)
            {
                Sort(0, j);
            }
            
            return mat;
            
            void Sort(int i, int j)
            {
                var diagonal = new List<int>();
                
                while (i < rowCount && j < columnCount)
                {
                    diagonal.Add(mat[i][j]);
                    i++;
                    j++;
                }
                
                diagonal.Sort();
                
                while (i > 0 && j > 0)
                {
                    i--;
                    j--;
                    mat[i][j] = diagonal.Last();
                    diagonal.RemoveAt(diagonal.Count - 1);
                }
            }
        }
    }
}