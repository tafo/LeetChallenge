using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace Challenge.Leet.July.WordSearch
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
            Solution.Exist(Board.Table, "DO").Should().BeTrue();
            Solution.Exist(Board.Table, "OR").Should().BeTrue();
            Solution.Exist(Board.Table, "OLD").Should().BeFalse();
            Solution.Exist(Board.Table, "ROW").Should().BeTrue();
            Solution.Exist(Board.Table, "LOW").Should().BeFalse();
            Solution.Exist(Board.Table, "WORD").Should().BeFalse();
            Solution.Exist(Board.Table, "WORK").Should().BeTrue();
            Solution.Exist(Board.Table, "WOOD").Should().BeFalse();
            Solution.Exist(Board.Table, "WORLD").Should().BeFalse();
        }
        
        [Fact]
        public void Check_Leet()
        {
            Board = new Board();
            Board.FillTable(3,
                'A', 'B', 'C', 'E',
                'X', 'F', 'C', 'S',
                'A', 'D', 'E', 'E');
            Solution.Exist(Board.Table, "SEE").Should().BeTrue();
        }   
        
        [Fact]
        public void Check_Ignoring_Edge_Adjacent()
        {
            Board = new Board();
            Board.FillTable(2, 
                'a', 'b', 
                'c', 'd');
            Solution.Exist(Board.Table, "abcd").Should().BeFalse();
        }
    }
}