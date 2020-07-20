using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.July.CourseSchedule
{
    /// <summary>
    /// 
    /// TITLE
    ///
    ///     Course Schedule II
    /// 
    /// DESCRIPTION
    ///
    ///     There are a total of n courses you have to take, labeled from 0 to n-1
    ///
    ///     Some courses may have prerequisites,
    ///         for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
    ///
    ///     Given the total number of courses and a list of prerequisite pairs,
    ///         return the ordering of courses you should take to finish all courses
    ///
    ///     There may be multiple correct orders, you just need to return one of them
    ///
    ///     If it is impossible to finish all courses, return an empty array
    ///
    /// EXAMPLES
    ///
    ///     Example 1
    /// 
    ///         Input
    ///             2, [[1,0]]
    ///         Output
    ///             [0,1]
    ///         Explanation
    ///             There are a total of 2 courses to take
    ///             To take course 1 you should have finished course 0
    ///             So the correct course order is [0,1]
    ///
    ///     Example 2
    /// 
    ///         Input
    ///             4, [[1,0],[2,0],[3,1],[3,2]]
    ///         Output
    ///             [0,1,2,3] or [0,2,1,3]
    ///         Explanation
    ///             There are a total of 4 courses to take
    ///             To take course 3 you should have finished both courses 1 and 2
    ///             Both courses 1 and 2 should be taken after you finished course 0
    ///             So one correct course order is [0,1,2,3]
    ///             Another correct ordering is [0,2,1,3]
    ///
    /// NOTE
    ///
    ///     The input prerequisites is a graph represented by a list of edges,
    ///         not adjacency matrices
    ///     Read more about how a graph is represented
    ///     You may assume that there are no duplicate edges in the input prerequisites
    /// 
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Runtime: 284 ms
        /// Memory Usage: 35.2 MB
        /// </summary>
        public int[] RunSortedList(int numCourses, int[][] prerequisites)
        {
            var result = Enumerable.Range(0, numCourses).ToArray();
            if (prerequisites.Length == 0) return result;
            const double epsilon = 0.0001;
            var positions = new double[numCourses];
            var parents = new Stack<int>();
            var courses = new SortedList<int, List<int>>();
            foreach (var prerequisite in prerequisites)
            {
                if (courses.ContainsKey(prerequisite[0]))
                {
                    courses[prerequisite[0]].Add(prerequisite[1]);
                }
                else
                {
                    courses.Add(prerequisite[0], new List<int> { prerequisite[1] });
                }
            }

            if (courses.Any(course => GetPosition(course.Key) > numCourses + 1))
            {
                return Array.Empty<int>();
            }

            Array.Sort(result, (x, y) => positions[x].CompareTo(positions[y]));

            return result[^1] > numCourses + 1 ? Array.Empty<int>() : result;

            double GetPosition(int i)
            {
                if (positions[i] >= epsilon) return positions[i];
                if (!courses.ContainsKey(i)) return positions[i] = i + 1;
                var pres = courses[i];
                if (pres.Any(parents.Contains)) return positions[i] = double.MaxValue - 1.0;
                parents.Push(i);
                positions[i] = Math.Max(i + 1, pres.Max(GetPosition) + epsilon);
                parents.Pop();
                return positions[i];
            }
        }

        /// <summary>
        /// Runtime: 404 ms
        /// Memory Usage: 34.5 MB
        /// ToDo: Optimize Array.FindAll(...), ...
        /// </summary>
        public int[] RunArray(int numCourses, int[][] prerequisites)
        {
            var result = Enumerable.Range(0, numCourses).ToArray();
            if (prerequisites.Length == 0) return result;
            var positions = new double[numCourses];
            const double epsilon = 0.0001;
            var parents = new Stack<int>();
            // Array.Sort(prerequisites, (x, y) => x[0].CompareTo(y[0]));
            if (prerequisites.Any(pre => GetPosition(pre[0]) > numCourses + 1)) return Array.Empty<int>();
            Array.Sort(result, (x, y) => positions[x].CompareTo(positions[y]));
            return result[^1] > numCourses + 1 ? Array.Empty<int>() : result;

            double GetPosition(int i)
            {
                if (positions[i] >= epsilon) return positions[i];
                var pres = Array.FindAll(prerequisites, x => x[0] == i);
                if (pres.Length == 0) return positions[i] = i + 1;
                if (pres.Any(x => parents.Contains(x[1]))) return positions[i] = double.MaxValue - 1.0;

                parents.Push(i);
                positions[i] = Math.Max(i + 1, pres.Max(x => GetPosition(x[1])) + epsilon);
                parents.Pop();
                return positions[i];
            }
        }

        /// <summary>
        /// CodeForFun
        /// Runtime: 280 ms
        /// Memory Usage: 35 MB
        /// </summary>
        public int[] RunObject(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0) return Enumerable.Range(0, numCourses).ToArray();
            var courses = Enumerable.Range(0, numCourses).Select(x => new Course(x)).ToArray();
            Array.ForEach(prerequisites, pre => courses[pre[0]].Prerequisites.Add(courses[pre[1]]));
            Array.Sort(courses);
            return courses[^1].Position > numCourses + 1 ? Array.Empty<int>() : courses.Select(x => x.Key).ToArray();
        }
    }
}