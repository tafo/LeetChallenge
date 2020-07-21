using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.July.WordSearch
{
    /// <summary>
    ///
    ///  TITLE
    ///
    ///     Word Search
    ///
    /// DESCRIPTION
    ///
    ///     Given a 2D board and a word, find if the word exists in the grid.
    ///     The word can be constructed from letters of sequentially adjacent cell,
    ///         where "adjacent" cells are those horizontally or vertically neighboring.
    ///     The same letter cell may not be used more than once.
    ///
    /// EXAMPLES
    ///
    ///     Example:
    ///     
    ///         board =
    ///         [
    ///             ['A','B','C','E'],
    ///             ['S','F','C','S'],
    ///             ['A','D','E','E']
    ///         ]
    /// 
    ///         Given word = "ABCCED", return true.
    ///         Given word = "SEE", return true.
    ///         Given word = "ABCB", return false.
    /// 
    /// 
    /// CONSTRAINTS
    ///
    ///     board and word consists only of lowercase and uppercase English letters.
    /// 
    ///     1 <= board.length <= 200
    ///     1 <= board[i].length <= 200
    ///     1 <= word.length <= 10^3
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "CommentTypo")]
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            var rowSize = board.Length;
            var colSize = board[0].Length;
            var visited = new bool[rowSize, colSize];
            for (var x = 0; x < rowSize; x++)
            {
                for (var y = 0; y < colSize; y++)
                {
                    if (board[x][y] != word[0]) continue;
                    if (word.Length == 1 || Check(x, y, 1)) return true;
                }
            }

            return false;

            bool Check(int rowIndex, int colIndex, int charIndex)
            {
                Debug.WriteLine(word.Substring(0, charIndex));

                visited[rowIndex, colIndex] = true;

                if (rowIndex > 0 && Found(rowIndex - 1, colIndex, charIndex))
                {
                    return true;
                }

                if (rowIndex + 1 < rowSize && Found(rowIndex + 1, colIndex, charIndex))
                {
                    return true;
                }

                if (colIndex > 0 && Found(rowIndex, colIndex - 1, charIndex))
                {
                    return true;
                }

                if (colIndex + 1 < colSize && Found(rowIndex, colIndex + 1, charIndex))
                {
                    return true;
                }

                visited[rowIndex, colIndex] = false;

                return false;

                bool Found(int x, int y, int i)
                    => !visited[x, y]
                       && board[x][y] == word[i]
                       && (i + 1 == word.Length || Check(x, y, i + 1));
            }
        }
    }
}