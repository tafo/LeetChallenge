using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace Challenge.Leet.Twenty.July.WordSearch
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class Test
    {
        public Solution Solution;
        public Board Board;

        public Test()
        {
            Solution = new Solution();
        }

        [Fact]
        public void Check3X3()
        {
            // var words = File.ReadAllLines($"{Directory.GetCurrentDirectory()}/Words.txt");
            Board = new Board();
            Board.FillTable(3,
                'W', 'O', 'R',
                'L', 'D', 'K',
                'X', 'Y', 'Z');
            Solution.Exist(Board.Matrix, "DO").Should().BeTrue();
            Solution.Exist(Board.Matrix, "OR").Should().BeTrue();
            Solution.Exist(Board.Matrix, "OLD").Should().BeFalse();
            Solution.Exist(Board.Matrix, "ROW").Should().BeTrue();
            Solution.Exist(Board.Matrix, "LOW").Should().BeFalse();
            Solution.Exist(Board.Matrix, "WORD").Should().BeFalse();
            Solution.Exist(Board.Matrix, "WORK").Should().BeTrue();
            Solution.Exist(Board.Matrix, "WOOD").Should().BeFalse();
            Solution.Exist(Board.Matrix, "WORLD").Should().BeFalse();
        }
        
        [Fact]
        public void Check_Leet()
        {
            Board = new Board();
            Board.FillTable(3,
                'A', 'B', 'C', 'E',
                'X', 'F', 'C', 'S',
                'A', 'D', 'E', 'E');
            Solution.Exist(Board.Matrix, "SEE").Should().BeTrue();
        }   
        
        [Fact]
        public void Check_Ignoring_Edge_Adjacent()
        {
            Board = new Board();
            Board.FillTable(2, 
                'a', 'b', 
                'c', 'd');
            Solution.Exist(Board.Matrix, "abcd").Should().BeFalse();
        }
    }
}