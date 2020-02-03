using System;

namespace Diapason
{
    class Range
    {
        private double From { get; set; }
        private double To { get; set; }

        public Range(double from, double to)
        {
            if (from < to)
            {
                From = from;
                To = to;
            }
            else
            {
                From = to;
                To = from;
            }
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            if (number >= From && number <= To)
            {
                return true;
            }

            return false;
        }
    }
}
