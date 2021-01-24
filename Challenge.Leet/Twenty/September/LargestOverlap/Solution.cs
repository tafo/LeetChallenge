using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Challenge.Leet.Twenty.September.LargestOverlap
{
    /// <summary>
    /// https://leetcode.com/problems/image-overlap/
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Time Complexity = O(n^4).
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public int LargestOverlap(int[][] A, int[][] B)
        {
            var nonEmptyCellsA = GetNonEmptyCells(A);
            var nonEmptyCellsB = GetNonEmptyCells(B);

            var slideGroups = new Dictionary<Tuple<int, int>, int>();
            foreach (var (x, y) in nonEmptyCellsA)
            {
                foreach (var (a, b) in nonEmptyCellsB)
                {
                    var vector = new Tuple<int, int>(x - a, y - b);
                    if (slideGroups.ContainsKey(vector))
                    {
                        slideGroups[vector]++;
                    }
                    else
                    {
                        slideGroups.Add(vector, 1);
                    }
                }
            }

            return slideGroups.Values.Any() ? slideGroups.Values.Max() : 0;

            List<Tuple<int, int>> GetNonEmptyCells(IReadOnlyList<int[]> M)
            {
                var output = new List<Tuple<int, int>>();

                for (var row = 0; row < A.Length; row++)
                {
                    for (var col = 0; col < B.Length; col++)
                    {
                        if (M[row][col] == 1)
                        {
                            output.Add(new Tuple<int, int>(row, col));
                        }
                    }
                }

                return output;
            }
        }
    }
}