using Shapes.Shapes;
using System.Collections.Generic;

namespace Shapes.Comparers
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}