//RectangleOneTriangleVertex.cs
using System;

namespace L4
{
    public class RectangleOneTriangleVertex : 
        IComparable<RectangleOneTriangleVertex>, 
        IEquatable<RectangleOneTriangleVertex>
    {
        // Name of the rectangle
        public string RectangleName { get; set; }

        // Upper-left corner point of the rectangle
        public Point UpperLeftCorner { get; set; }

        // Lower-right corner point of the rectangle
        public Point LowerRightCorner { get; set; }

        // Name of the triangle
        public string TriangleName { get; set; }

        // The triangle vertex point related to this rectangle
        public Point TriangleCorner { get; set; }

        /// <summary>
        /// Initializes a new instance of the RectangleOneTriangleVertex 
        /// class with default values.
        /// </summary>
        public RectangleOneTriangleVertex()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RectangleOneTriangleVertex class
        /// with specified rectangle and triangle information.
        /// </summary>
        /// <param name="rectangleName">Name of the rectangle.</param>
        /// <param name="upperLeftCorner">Upper-left corner 
        /// of the rectangle.</param>
        /// <param name="lowerRightCorner">Lower-right corner 
        /// of the rectangle.</param>
        /// <param name="triangleName">Name of the triangle.</param>
        /// <param name="triangleCorner">Vertex point of the triangle.</param>
        public RectangleOneTriangleVertex(string rectangleName, 
            Point upperLeftCorner, Point lowerRightCorner, 
            string triangleName, Point triangleCorner)
        {
            RectangleName = rectangleName;
            UpperLeftCorner = upperLeftCorner;
            LowerRightCorner = lowerRightCorner;
            TriangleName = triangleName;
            TriangleCorner = triangleCorner;
        }

        /// <summary>
        /// Compares this instance with another 
        /// RectangleOneTriangleVertex object.
        /// The comparison is primarily by TriangleName, 
        /// then by RectangleName.
        /// </summary>
        /// <param name="other">The other object to compare to.</param>
        /// <returns>
        /// Less than zero if this instance precedes other, zero if equal, 
        /// greater than zero if it follows other.
        /// </returns>
        public int CompareTo(RectangleOneTriangleVertex other)
        {
            int rCompare = string.Compare(RectangleName, other.RectangleName);
            int tCompare = string.Compare(TriangleName, other.TriangleName);
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
        /// Determines whether the specified RectangleOneTriangleVertex
        /// is equal to the current instance.
        /// </summary>
        /// <param name="other">The other RectangleOneTriangleVertex 
        /// compare with.</param>
        /// <returns>Currently always returns false (consider 
        /// implementing equality logic here).</returns>
        public bool Equals(RectangleOneTriangleVertex other)
        {
            return false;
        }

        /// <summary>
        /// Returns a formatted string representation of this object 
        /// including rectangle and triangle details.
        /// </summary>
        /// <returns>A formatted string describing the object.</returns>
        public override string ToString()
        {
            string line = string.Format("| {0,10} | ({1,2},{2,2});" +
                "({3,2},{4,2}) | {5,10} | ({6,3},{7,3}) |",
                RectangleName, UpperLeftCorner.X, UpperLeftCorner.Y, 
                LowerRightCorner.X, LowerRightCorner.Y,
                TriangleName, TriangleCorner.X, TriangleCorner.Y);
            return line;
        }

        /// <summary>
        /// Returns a formatted header string for displaying a list
        /// of these objects in tabular form.
        /// </summary>
        /// <returns>A formatted string header.</returns>
        public static string Header()
        {
            string line = new string('-', 57) + "\r\n"
                + string.Format("| {0,10} | {1,15} | {2,10} | {3,9} |",
                "Rectangle", "Coordinates", "Triangle", "Corner") + "\r\n"
                + new string('-', 57) + "\r\n";
            return line;
        }

        /// <summary>
        /// Returns a formatted footer string to close the tabular display.
        /// </summary>
        /// <returns>A formatted string footer.</returns>
        public static string Footer()
        {
            return new string('-', 57);
        }
    }
}
