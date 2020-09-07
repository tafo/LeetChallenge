using System;
using System.Diagnostics;

namespace Challenge.Leet.August.DesignHashSet.Backup
{
    // Create Enum
    public class TheHashSet
    {
        private long[] _set;
        private const int KeyFactor = 0xFFFFF;
        private const int MoveFactor = 0x16;
        private const int PageSize = 4;
        private readonly int _rootRange;

        public TheHashSet(int max)
        {
            _rootRange = 1;
            var maximum = max / PageSize;
            while (_rootRange < maximum)
            {
                _rootRange *= PageSize;
            }
            _set = new long[PageSize];
        }

        public void Add(int key)
        {
            Debug.WriteLine(key);
            var rootIndex = key / _rootRange;
            AddIfNotExists(key, rootIndex * _rootRange, rootIndex, _rootRange);
        }

        private void AddIfNotExists(int key, int header, int index, int range)
        {
            long status = _set[index] & 0x03;
            while (status == 0x02)
            {
                if (_set[index] >> 0x02 == key) return;
                header += index * range;
                if (range >= PageSize) range /= PageSize;
                index = FindReference(key, header, index, range);
                status = _set[index] & 0x03;
            }

            if (status == 0x00)
            {
                _set[index] = (key << 0x02) + 0x01;
            }
            else
            {
                if (_set[index] >> 0x02 == key) return;
                var newReference = _set.Length;
                Array.Resize(ref _set, newReference + PageSize);
                _set[newReference + (key - header) / range] = key;
                _set[index] = (newReference << MoveFactor) + _set[index] + 0x01;
            }
        }

        public void Remove(int key)
        {

        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            var rootIndex = key / _rootRange;
            return CheckBranches(key, rootIndex * PageSize, rootIndex, _rootRange);
        }

        private bool CheckBranches(int key, int header, int index, int range)
        {
            var status = _set[index] & 0x03;
            if (status == 0x00) return false;
            while (status == 0x02)
            {
                if (((_set[index] >> 0x02) & KeyFactor) == key) return true;
                header += index * range;
                if (range >= PageSize) range /= PageSize;
                index = FindReference(key, header, index, range);
                status = _set[index] & 0x03;
            }
            if (status == 0x00) return false;
            return ((_set[index] >> 0x02) & KeyFactor) == key;
        }

        public long[] Get()
        {
            return _set;
        }

        private int FindReference(int key, int header, int branchIndex, int range)
        {
            return (int)(_set[branchIndex] >> 22) + (key - header) / range;
        }
    }
}