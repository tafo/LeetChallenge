using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.July.CourseSchedule
{
    public class Course : IComparable<Course>
    {
        private double _position;

        public int Key;
        public List<Course> Prerequisites;
        public static Stack<int> PrerequisiteTo;
        public int CompareTo(Course other) => Position.CompareTo(other.Position);
        public static double Epsilon = 0.0001;

        public Course(int key)
        {
            Key = key;
            Position = -1.0;
            Prerequisites = new List<Course>();
            PrerequisiteTo = new Stack<int>();
        }

        public double Position
        {
            get
            {
                if (_position >= Epsilon) return _position;
                if (!Prerequisites.Any()) return _position = Key + 1;
                if (Prerequisites.Any(x => PrerequisiteTo.Contains(x.Key))) return _position = double.MaxValue - 1.0;

                PrerequisiteTo.Push(Key);
                _position = Math.Max(Key + 1, Prerequisites.Max(x => x.Position) + Epsilon);
                PrerequisiteTo.Pop();

                return _position;
            }
            set => _position = value;
        }
    }
}