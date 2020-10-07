using System;
using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Common;
using Xunit;

namespace Challenge.Leet.July.RemoveLinkedListNodes
{
    public class Test : Solution
    {
        public Func<ListNode, int, ListNode> TestMethod;
        
        [Fact]
        public void CheckRemoveElementsWhile()
        {
            TestMethod = RemoveElementsByWhile;
            CheckList();
        }
        
        [Fact]
        public void CheckRemoveElementsByStoringOthers()
        {
            TestMethod = RemoveElementsByIgnoringHeads;
            CheckList();
        }

        [Fact]
        public void CheckRemoveElementsByDoWhile()
        {
            TestMethod = RemoveElementsByDoWhile;
            CheckList();
        }

        private void CheckList()
        {
            Check(new[] {1, 2, 3}, 1, new[] {2, 3});
            Check(new[] {1, 2, 3}, 2, new[] {1, 3});
            Check(new[] {1, 2, 3}, 3, new[] {1, 2});
            Check(new[] {1, 1}, 1, Array.Empty<int>());
            Check(new[] {1}, 1, Array.Empty<int>());
            Check(new[] {1}, 2, new[] {1});
            Check(new[] {1, 2, 6, 3, 4, 5, 6}, 6, new[] {1, 2, 3, 4, 5});
            Check(new[] {1, 2, 2, 1}, 2, new[] {1, 1});

            void Check(IEnumerable<int> nodeValues, int value, int[] result)
            {   
                var node = TestMethod(CreateLinkedList(nodeValues), value);
                Array.ForEach(result, x =>
                {
                    Assert.Equal(x, node.val);
                    node = node.next;
                });
            }
        }

        [Fact]
        public void CompareSolutions()
        {
            var tests = new List<TestCase>();
            for (var i = 1; i <= 100; i++)
            {
                var test = new TestCase(1000 * i, 15);
                test.Head = CreateLinkedList(test.Numbers);
                tests.Add(test);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var test in tests)
            {
                RemoveElementsByDoWhile(test.Head, test.NumberToRemove);
            }

            stopwatch.Stop();
            Debug.WriteLine($"{nameof(CheckRemoveElementsByDoWhile)} = {stopwatch.ElapsedTicks}");

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var test in tests)
            {
                RemoveElementsByWhile(test.Head, test.NumberToRemove);
            }

            stopwatch.Stop();
            Debug.WriteLine($"{nameof(RemoveElementsByWhile)} = {stopwatch.ElapsedTicks}");

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var test in tests)
            {
                RemoveElementsByIgnoringHeads(test.Head, test.NumberToRemove);
            }

            stopwatch.Stop();
            Debug.WriteLine($"{nameof(RemoveElementsByIgnoringHeads)} = {stopwatch.ElapsedTicks}");
        }

        private static ListNode CreateLinkedList(IEnumerable<int> numbers)
        {
            ListNode head = null;
            ListNode current = null;
            foreach (var number in numbers)
            {
                if (head == null)
                {
                    head = new ListNode(number);
                    current = head;
                }
                else
                {
                    current.next = new ListNode(number);
                    current = current.next;
                }
            }

            return head;
        }
    }
}