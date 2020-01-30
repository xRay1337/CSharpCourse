using System;

namespace Shapes
{
    class Circle : IShape
    {
        double Radius { get; set; }

        public Circle(double Radius)
        {
            this.Radius = Radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }

        public double GetWidth()
        {
            return Radius * 2;
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
            int prime = 37;
            int hash = 1;

            hash = prime * hash + (int)Radius;

            hash = prime * hash + GetArea().GetHashCode();

            return hash;
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