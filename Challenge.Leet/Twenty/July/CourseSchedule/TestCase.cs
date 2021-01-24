using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.Twenty.July.CourseSchedule
{
    public class TestCase
    {
        public int CourseCount;
        public bool CycleFlag;
        public int[] Expectation;
        public Dictionary<int, List<int>> CoursePrerequisites;

        public TestCase(int courseCount)
        {
            CourseCount = courseCount;
            CoursePrerequisites = new Dictionary<int, List<int>>();
        }

        public TestCase Add(int course, int prerequisite)
        {
            if (CoursePrerequisites.ContainsKey(course))
            {
                CoursePrerequisites[course].Add(prerequisite);
            }
            else
            {
                CoursePrerequisites.Add(course, new List<int> {prerequisite});
            }

            if (CycleFlag || !HasCycle(course, prerequisite, CoursePrerequisites)) return this;

            CycleFlag = true;
            SetExpectation(Array.Empty<int>());

            return this;
        }

        public TestCase SetExpectation(params int[] values)
        {
            Expectation = values;
            return this;
        }

        public int[][] Prerequisites =>
            CoursePrerequisites.SelectMany(x => x.Value.Select(y => new[] {x.Key, y})).ToArray();

        public static bool HasCycle(int key, int pre, Dictionary<int, List<int>> courses)
        {
            return courses.ContainsKey(pre) &&
                   (courses[pre].Contains(key) ||
                    courses[pre].Any(prerequisite => HasCycle(key, prerequisite, courses)));
        }
    }
}