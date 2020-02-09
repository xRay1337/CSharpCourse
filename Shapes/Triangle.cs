using System;

namespace Shapes
{
    class Triangle : IShape
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public double X3 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        private double GetSideLegth(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public double GetArea()
        {
            double epsilon = 1.0e-10;

            if (Math.Abs((X3 - X1) * (Y2 - Y1) - (Y3 - Y1) * (X2 - X1)) < epsilon)
            {
                return 0;
            }

            double side1 = GetSideLegth(X1, Y1, X2, Y2);
            double side2 = GetSideLegth(X2, Y2, X3, Y3);
            double side3 = GetSideLegth(X3, Y3, X1, Y1);

            double halfPerimeter = (side1 + side2 + side3) / 2;
            double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - side1) * (halfPerimeter - side2) * (halfPerimeter - side3));

            return triangleArea;
        }

        public double GetPerimeter()
        {
            double side1 = GetSideLegth(X1, Y1, X2, Y2);
            double side2 = GetSideLegth(X2, Y2, X3, Y3);
            double side3 = GetSideLegth(X3, Y3, X1, Y1);

            return side1 + side2 + side3;
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public int CompareTo(object obj)
        {
            IShape shape = obj as IShape;

            if (GetArea() > shape.GetArea())
            {
                return 1;
            }

            if (GetArea() < shape.GetArea())
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}. X1 = {1:f2}, Y1 = {2:f2}, X1 = {3:f2}, Y1 = {4:f2}, X1 = {5:f2}, Y1 = {6:f2}. Area = {7:f2}. Perimeter = {8:f2}.", GetType(), X1, Y1, X2, Y2, X3, Y3, GetArea(), GetPerimeter());
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

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

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3 && Y3 == triangle.Y3;
        }
    }
}