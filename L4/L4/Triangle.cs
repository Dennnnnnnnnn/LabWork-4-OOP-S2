//Triangle.cs
using System;

namespace L4
{
    internal class Triangle : IEquatable<Triangle>, 
        IComparable<Triangle>, IAreaMeasurable
    {
        // Triangle name
        public string TriangleName { get; set; }
        // First corner point
        public Point FirstCorner { get; set; }
        // Second corner point
        public Point SecondCorner { get; set; }
        // Third corner point
        public Point ThirdCorner { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Triangle()
        {

        }

        /// <summary>
        /// Constructor with name and three corners
        /// </summary>
        public Triangle(string triangleName, Point firstCorner, 
            Point secondCorner, Point thirdCorner)
        {
            this.TriangleName = triangleName;
            this.FirstCorner = firstCorner;
            this.SecondCorner = secondCorner;
            this.ThirdCorner = thirdCorner;
        }

        /// <summary>
        /// Overrides Equals(object) to compare two triangles
        /// </summary>
        public override bool Equals(object obj)
        {
            Triangle triangle = obj as Triangle;
            return this.Equals(triangle);
        }

        /// <summary>
        /// Checks equality with another Triangle instance
        /// </summary>
        public bool Equals(Triangle triangle)
        {
            return this.FirstCorner.Equals(triangle.FirstCorner) &&
                   this.SecondCorner.Equals(triangle.SecondCorner) &&
                   this.ThirdCorner.Equals(triangle.ThirdCorner);
        }

        /// <summary>
        /// Overrides GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return TriangleName.GetHashCode() ^ FirstCorner.GetHashCode() ^ 
                SecondCorner.GetHashCode() ^ ThirdCorner.GetHashCode();
        }

        /// <summary>
        /// Compares two triangles by name
        /// </summary>
        public int CompareTo(Triangle other)
        {
            int pCompare = String.Compare(this.TriangleName, 
                other.TriangleName, StringComparison.CurrentCulture);
            return pCompare;
        }

        /// <summary>
        /// Returns a formatted string representation of the triangle
        /// </summary>
        public override string ToString()
        {
            string line = string.Format("| {0, 12} | ({1, -3},{2,-3})  | " +
                "({3,-3},{4,-3})  | ({5,-3},{6,-3})  |", TriangleName,
                FirstCorner.X, FirstCorner.Y, SecondCorner.X, SecondCorner.Y,
                ThirdCorner.X, ThirdCorner.Y);
            return line;
        }

        /// <summary>
        /// Returns the formatted table header string for display
        /// </summary>
        public static string Header()
        {
            string line = "---------------------------------------------" +
                "----------" + Environment.NewLine +
                        string.Format("| {0, 12} | {1, 10} | {2,10} |" +
                        " {3,10} |", "Triangle", "1st corner", "2nd corner", 
                        "3rd corner") + Environment.NewLine +
                        "-----------------------------------------------" +
                        "--------" + Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Returns the formatted table footer string for display
        /// </summary>
        public static string Footer()
        {
            return "-------------------------------------------------" +
                "------" + Environment.NewLine;
        }

        /// <summary>
        /// Calculates and returns the area of the triangle using 
        /// the coordinate formula
        /// </summary>
        public double Area()
        {
            int x1 = this.FirstCorner.X;
            int y1 = this.FirstCorner.Y;
            int x2 = this.SecondCorner.X;
            int y2 = this.SecondCorner.Y;
            int x3 = this.ThirdCorner.X;
            int y3 = this.ThirdCorner.Y;

            return 0.5 * Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1)
                + x3 * (y1 - y2));
        }
    }
}
