namespace Challenge.Leet.Twenty.August.FindDuplicates
{
    public class TheHashSet
    {
        public class Number
        {
            public byte Digit;
            public bool IsLastDigit;
            public Number[] NextDigits;
            public Number(byte digit = 10)
            {
                Digit = digit;
            }

            public void Set(int value)
            {
                var digit = (byte)(value % 10);
                NextDigits ??= new Number[10];
                NextDigits[digit] ??= new Number(digit);
                var number = NextDigits[digit];
                if (value < 10)
                {
                    number.IsLastDigit = true;
                }
                else
                {
                    number.Set(value / 10);
                }
            }
        }

        public Number Root;

        public TheHashSet()
        {
            Root = new Number();
        }

        public void Add(int key)
        {
            Root.Set(key);
        }

        public void Remove(int key)
        {
            var number = Root;
            do
            {
                if (number.NextDigits == null) return;
                var digit = key % 10;
                number = number.NextDigits[digit];
                if (number == null) return;
                key /= 10;
            } while (key > 0);

            // ToDo: Clear the path
            number.IsLastDigit = false;
        }

        public bool Contains(int key)
        {
            var number = Root;
            do
            {
                if (number.NextDigits == null) return false;
                var digit = key % 10;
                number = number.NextDigits[digit];
                if (number == null) return false;
                key /= 10;
            } while (key > 0);

            return number.IsLastDigit;
        }
    }
}