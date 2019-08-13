using System;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;
        public Point()
        {

        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;
        public Line() { }
        public Line(Point start, Point end)
        {
            Start = new Point(start.X, start.Y);
            End = new Point(end.X, end.Y);
        }

        public Line DeepCopy()
        {
            return new Line(Start, End);
        }
    }
}
