using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Challenge.Leet.Twenty.July.CourseSchedule
{
    public class Test : Solution
    {
        public static TestCase GetTest(int courseCount, int preCount)
        {
            var coursePrerequisites = new Dictionary<int, List<int>>();
            var random = new Random();
            for (var i = 0; i < preCount; i++)
            {
                int courseKey;
                do
                {
                    courseKey = random.Next(0, courseCount);
                } while (coursePrerequisites.ContainsKey(courseKey));

                coursePrerequisites.Add(courseKey, new List<int>());

                do
                {
                    int preKey;
                    do
                    {
                        preKey = random.Next(0, courseCount);
                    } while (courseKey == preKey || coursePrerequisites[courseKey].Contains(preKey));

                    coursePrerequisites[courseKey].Add(preKey);
                } while (coursePrerequisites[courseKey].Count < 5);
            }

            var cycles =
                from coursePrerequisite in coursePrerequisites
                from prerequisite in coursePrerequisite.Value
                where TestCase.HasCycle(coursePrerequisite.Key, prerequisite, coursePrerequisites)
                select coursePrerequisite;
            foreach (var cycle in cycles)
            {
                coursePrerequisites.Remove(cycle.Key);
            }

            return new TestCase(courseCount) { CoursePrerequisites = coursePrerequisites };
        }

        [Fact]
        public void Check()
        {
            Validate(new TestCase(0), RunArray(0, Array.Empty<int[]>()));
            Validate(new TestCase(1), RunArray(1, Array.Empty<int[]>()));

            var test = new TestCase(2).Add(0, 1);
            Validate(test, RunArray(test.CourseCount, test.Prerequisites));

            test = new TestCase(3).Add(0, 1).Add(1, 2);
            Validate(test, RunArray(test.CourseCount, test.Prerequisites));

            test = new TestCase(3).Add(0, 1).Add(1, 2).Add(2, 0);
            Validate(test, RunArray(test.CourseCount, test.Prerequisites));

            var data = File.ReadAllText($"{Directory.GetCurrentDirectory()}/July/CourseSchedule/Data/pres.json");
            var prerequisites = JsonConvert.DeserializeObject<int[][]>(data);
            test = new TestCase(2000);
            foreach (var prerequisite in prerequisites)
            {
                test.Add(prerequisite[0], prerequisite[1]);
            }

            Validate(test, RunObject(test.CourseCount, test.Prerequisites));
        }

        private static void Validate(TestCase test, int[] result)
        {
            if (test.Expectation != null)
            {
                result.Should().BeEqualTo(test.Expectation);
            }
            else
            {
                foreach (var (course, coursePre) in test.CoursePrerequisites)
                {
                    foreach (var pre in coursePre)
                    {
                        result.Should().ContainInOrder(pre, course);
                    }
                }
            }
        }

        [Fact]
        public void CompareSolutions()
        {
            var test = GetTest(1000, 100);

            for (var i = 0; i < 10; i++)
            {
                This();
            }

            void This()
            {
                var timer = new Stopwatch();
                {
                    timer.Reset();
                    timer.Start();
                    var result = RunObject(test.CourseCount, test.Prerequisites);
                    timer.Stop();
                    Debug.WriteLine($"Object = {timer.ElapsedTicks}");
                    timer.Reset();
                    Validate(test, result);
                }
                {
                    timer.Reset();
                    timer.Start();
                    var result = RunArray(test.CourseCount, test.Prerequisites);
                    timer.Stop();
                    Debug.WriteLine($"Array = {timer.ElapsedTicks}");
                    timer.Reset();
                    Validate(test, result);
                }
                {
                    timer.Reset();
                    timer.Start();
                    var result = RunSortedList(test.CourseCount, test.Prerequisites);
                    timer.Stop();
                    Debug.WriteLine($"Dictionary = {timer.ElapsedTicks}");
                    timer.Reset();
                    Validate(test, result);
                }
            }
        }
    }
}