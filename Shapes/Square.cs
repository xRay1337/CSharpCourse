using System;

namespace Shapes
{
    class Square : IShape
    {
        private double SideLength { get; set; }

        public Square(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public int CompareTo(Object obj)
        {
            IShape shape = obj as IShape;

            if (this.GetArea() > shape.GetArea())
            {
                return 1;
            }

            if (this.GetArea() < shape.GetArea())
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}. Area {1:f2}", this.GetType(), this.GetArea());
        }

        public override int GetHashCode()
        {
            return GetArea().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                IShape shape = obj as IShape;

                if (this.GetArea() == shape.GetArea())
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}