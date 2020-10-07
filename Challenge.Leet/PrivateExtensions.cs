using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Challenge.Leet.Common;
using FluentAssertions.Collections;

namespace Challenge.Leet
{
    public static class PrivateExtensions
    {
        private static readonly Random Random = new Random();

        public static double Round(this double value)
        {
            return Math.Round(value, 5);
        }

        public static IEnumerable<int> Mix(this IEnumerable<int> set)
        {
            return set.OrderBy(x => Random.Next(-1, 2));
        }

        public static void BeEqualTo<T>(this GenericCollectionAssertions<T> set, IEnumerable<T> other,
            string testCase = null)
        {
            set.BeEquivalentTo(other, options => options.WithStrictOrdering(), testCase);
        }

        public static TreeNode ToTreeNode(this int?[] values)
        {
            if (values.Length == 0) return null;

            var root = values[0].HasValue ? new TreeNode(values[0].Value) : new TreeNode();

            var parentNodes = new List<TreeNode> { root };

            var i = 0;
            while (parentNodes.Count > 0)
            {
                var parents = parentNodes.ToList();
                parentNodes = new List<TreeNode>();
                foreach (var parent in parents)
                {
                    if (++i == values.Length) return root;
                    if (values[i].HasValue)
                    {
                        parent.left = new TreeNode(values[i].Value);
                        parentNodes.Add(parent.left);
                    }

                    if (++i == values.Length) return root;
                    
                    if (!values[i].HasValue) continue;
                    
                    parent.right = new TreeNode(values[i].Value);
                    parentNodes.Add(parent.right);
                }
            }

            return root;
        }

        public static string ToText(this int?[] elements)
        {
            var sb = new StringBuilder(elements.Length);
            sb.AppendLine(string.Empty);
            sb.AppendLine("{");
            foreach (var element in elements)
            {
                sb.AppendLine(element.HasValue ? element.Value.ToString() : "NULL");
            }

            sb.AppendLine("}");
            sb.AppendLine(string.Empty);

            return sb.ToString();
        }
    }
}