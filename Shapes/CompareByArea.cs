namespace Shapes
{
    class CompareByArea : IComparable<IShape, IShape>
    {
        public int CompareTo(IShape shape1, IShape shape2)
        {
            if (shape1.GetArea() > shape2.GetArea())
            {
                return -1;
            }

            if (shape1.GetArea() < shape2.GetArea())
            {
                return 1;
            }

            return 0;
        }
    }
}