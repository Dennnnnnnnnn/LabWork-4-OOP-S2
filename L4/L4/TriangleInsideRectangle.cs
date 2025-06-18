//TriangleInsideRectangle.cs
using System;

namespace L4
{
    public class TriangleInsideRectangle : 
        IComparable<TriangleInsideRectangle>, IEquatable<TriangleInsideRectangle>
    {
        // Rectangle name
        public string RectangleName { get; set; }
        // Upper-left corner point of rectangle
        public Point UpperLeftCorner { get; set; }
        // Lower-right corner point of rectangle
        public Point LowerRightCorner { get; set; }
        // Triangle name
        public string TriangleName { get; set; }
        // First corner of triangle
        public Point TriangleCorner1 { get; set; }
        // Second corner of triangle
        public Point TriangleCorner2 { get; set; }
        // Third corner of triangle
        public Point TriangleCorner3 { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TriangleInsideRectangle()
        {

        }

        /// <summary>
        /// Constructor with rectangle and triangle data
        /// </summary>
        public TriangleInsideRectangle(string rectangleName, 
            Point upperLeftCorner, Point lowerRightCorner, 
            string triangleName, Point triangleCorner1, 
            Point triangleCorner2, Point triangleCorner3)
        {
            this.RectangleName = rectangleName;
            this.UpperLeftCorner = upperLeftCorner;
            this.LowerRightCorner = lowerRightCorner;
            this.TriangleName = triangleName;
            this.TriangleCorner1 = triangleCorner1;
            this.TriangleCorner2 = triangleCorner2;
            this.TriangleCorner3 = triangleCorner3;
        }

        /// <summary>
        /// Compares this instance to another TriangleInsideRectangle, 
        /// by triangle name then rectangle name
        /// </summary>
        public int CompareTo(TriangleInsideRectangle other)
        {
            int rCompare = string.Compare(RectangleName, 
                other.RectangleName);
            int tCompare = string.Compare(TriangleName, 
                other.TriangleName);
            if (tCompare != 0)
            {
                return tCompare;
            }
            else
            {
                return rCompare;
            }
        }

        /// <summary>
        /// Checks equality with another TriangleInsideRectangle instance
        /// </summary>
        public bool Equals(TriangleInsideRectangle other)
        {
            return false;
        }

        /// <summary>
        /// Returns a formatted string representation of this object
        /// </summary>
        public override string ToString()
        {
            string line = string.Format("| {0, 10} | ({1,2},{2,2});" +
                "({3, 2},{4,2}) | {5, 10} | ({6, 3},{7,3}) | ({8, 3},{9,3}) " +
                "| ({10, 3},{11,3}) |",
                RectangleName, UpperLeftCorner.X, UpperLeftCorner.Y, 
                LowerRightCorner.X, LowerRightCorner.Y, TriangleName, 
                TriangleCorner1.X, TriangleCorner1.Y, TriangleCorner2.X, 
                TriangleCorner2.Y, TriangleCorner3.X, TriangleCorner3.Y); 
            return line;
        }

        /// <summary>
        /// Returns the header string for tabular display
        /// </summary>
        public static string Header()
        {
            string line = new string('-', 81) + "\r\n"
                + string.Format("| {0,10} | {1,15} | {2,10} | {3,9} | " +
                "{4,9} | {5,9} |", "Rectangle", "Coordinates", "Triangle",
                "Corner 1", "Corner 2", "Corner 3") + "\r\n"
                + new string('-', 81) + "\r\n";
            return line;
        }

        /// <summary>
        /// Returns the footer string for tabular display
        /// </summary>
        public static string Footer()
        {
            return new string('-', 81);
        }
    }
}
