//Point.cs
using System;

namespace L4
{
    public class Point : IEquatable<Point>
    {
        // X coordinate of the point
        public int X { get; set; }

        // Y coordinate of the point
        public int Y { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Point()
        {
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="x">X coordinate value.</param>
        /// <param name="y">Y coordinate value.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Determines whether the specified Point is equal to 
        /// the current point.
        /// </summary>
        /// <param name="other">The point to compare with the
        /// current point.</param>
        /// <returns>True if both X and Y coordinates are equal; 
        /// otherwise, false.</returns>
        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        /// <summary>
        /// Checks if the current point is greater than or 
        /// equal to another point.
        /// Returns true if this.X >= other.X and
        /// this.Y <= other.Y.
        /// </summary>
        /// <param name="a">The left point.</param>
        /// <param name="b">The right point.</param>
        /// <returns>True if conditions are met; 
        /// otherwise, false.</returns>
        public static bool operator >=(Point a, Point b)
        {
            return a.X >= b.X && a.Y <= b.Y;
        }

        /// <summary>
        /// Checks if the current point is less than or 
        /// equal to another point.
        /// Returns true if this.X <= other.X and 
        /// this.Y >= other.Y.
        /// </summary>
        /// <param name="a">The left point.</param>
        /// <param name="b">The right point.</param>
        /// <returns>True if conditions are met; 
        /// otherwise, false.</returns>
        public static bool operator <=(Point a, Point b)
        {
            return a.X <= b.X && a.Y >= b.Y;
        }
    }
}
