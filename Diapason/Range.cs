namespace Range
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public Range(Range range) : this(range.From, range.To)
        {
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range[] GetUnion(Range range)
        {
            if (To <= range.From)
            {
                return new Range[] { new Range(this), new Range(range) };
            }

            return new Range[] { new Range(From, range.To) };
        }

        public Range GetIntersection(Range range)
        {
            if (To <= range.From)
            {
                return null;
            }

            return new Range(range.From, To);
        }

        public Range[] GetExcept(Range range)
        {
            if (To <= range.From)
            {
                return new Range[] { new Range(this), new Range(range) };
            }

            return new Range[] { new Range(From, range.From - 1) };
        }

        public override string ToString()
        {
            return string.Format("({0:f1}; {1:f1})", From, To);
        }
    }
}
