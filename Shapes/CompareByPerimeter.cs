namespace Shapes
{
    class CompareByPerimeter : IComparable<IShape, IShape>
    {
        public int CompareTo(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter() > shape2.GetPerimeter())
            {
                return -1;
            }

            if (shape1.GetPerimeter() < shape2.GetPerimeter())
            {
                return 1;
            }

            return 0;
        }
    }
}