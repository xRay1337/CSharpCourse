using System;

namespace Diapason
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

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range Intersection(Range range)
        {
            if (To < range.From)
            {
                return null;
            }

            return new Range(range.From, To);
        }

        public Range[] Union(Range range)
        {
            if (To < range.From)
            {
                return new Range[] { this, range };
            }

            return new Range[] { new Range(From, range.To) };
        }

        public Range[] Except(Range range)
        {
            if (To < range.From)
            {
                return new Range[] { this };
            }

            return new Range[] { new Range(From, range.From), new Range(To, range.To) };
        }
    }
}
