using System;

namespace ShapesShapes
{
    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
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

        public override string ToString()
        {
            return string.Format("{0}. Radius = {1:f2}. Area = {2:f2}. Perimeter = {3:f2}.", GetType(), Radius, GetArea(), GetPerimeter());
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;

            hash = prime * hash + Radius.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            return Radius == circle.Radius;
        }
    }
}