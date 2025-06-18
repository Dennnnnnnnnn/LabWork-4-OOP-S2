//REctangle.cs
using System;

namespace L4
{
    internal class Rectangle : IComparable<Rectangle>, 
        IEquatable<Rectangle>, IAreaMeasurable
    {
        // Name identifier for the rectangle
        public string RectangleName { get; set; }

        // Coordinates of the upper-left corner of the rectangle
        public Point UpperLeftCorner { get; set; }

        // Coordinates of the lower-right corner of the rectangle
        public Point LowerRightCorner { get; set; }

        /// <summary>
        /// Initializes a new instance of the Rectangle 
        /// class with default values.
        /// </summary>
        public Rectangle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle class 
        /// with specified name and corner points.
        /// </summary>
        /// <param name="name">Name of the rectangle.</param>
        /// <param name="upperLeftCorner">Upper-left corner point.</param>
        /// <param name="lowerRightCorner">Lower-right corner point.</param>
        public Rectangle(string name, Point upperLeftCorner, 
            Point lowerRightCorner)
        {
            this.RectangleName = name;
            this.UpperLeftCorner = upperLeftCorner;
            this.LowerRightCorner = lowerRightCorner;
        }

        /// <summary>
        /// Determines whether the specified object is equal 
        /// to the current rectangle.
        /// </summary>
        /// <param name="obj">The object to compare with 
        /// the current rectangle.</param>
        /// <returns>True if the rectangles are equal;
        /// otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            Rectangle rectangle = obj as Rectangle;
            return this.Equals(rectangle);
        }

        /// <summary>
        /// Determines whether the specified rectangle is equal 
        /// to the current rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to compare with 
        /// the current rectangle.</param>
        /// <returns>True if the upper-left and lower-right corners 
        /// are equal; otherwise, false.</returns>
        public bool Equals(Rectangle rectangle)
        {
            if (rectangle == null) return false;
            return this.UpperLeftCorner.Equals(rectangle.UpperLeftCorner) 
                && this.LowerRightCorner.Equals(rectangle.LowerRightCorner);
        }

        /// <summary>
        /// Returns a hash code for this rectangle.
        /// </summary>
        /// <returns>A hash code based on the rectangle's name 
        /// and corner points.</returns>
        public override int GetHashCode()
        {
            return RectangleName.GetHashCode() ^ UpperLeftCorner.GetHashCode()
                ^ LowerRightCorner.GetHashCode();
        }

        /// <summary>
        /// Compares the current rectangle with another rectangle 
        /// based on their names.
        /// </summary>
        /// <param name="other">The rectangle to compare with this 
        /// instance.</param>
        /// <returns>An integer that indicates the relative order 
        /// of the rectangles.</returns>
        public int CompareTo(Rectangle other)
        {
            return String.Compare(this.RectangleName, 
                other.RectangleName, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Returns a string representation of the rectangle including 
        /// its name and corner coordinates.
        /// </summary>
        /// <returns>A formatted string representing the rectangle.</returns>
        public override string ToString()
        {
            return string.Format("| {0,10} |     ({1,-3},{2,-3})     " +
                "|     ({3,-3},{4,-3})      |",
                RectangleName, UpperLeftCorner.X, UpperLeftCorner.Y, 
                LowerRightCorner.X, LowerRightCorner.Y);
        }

        /// <summary>
        /// Returns a formatted header string for displaying rectangle 
        /// information in tabular form.
        /// </summary>
        /// <returns>A formatted string header.</returns>
        public static string Header()
        {
            return "-------------------------------------------------------"
                + Environment.NewLine +
                   string.Format("| {0,10} | {1,-13} | {2,-13} |", "Rectangle",
                   "Upper left corner", "Lower right corner") + 
                   Environment.NewLine +
                   "-------------------------------------------------------"
                   + Environment.NewLine;
        }

        /// <summary>
        /// Returns a formatted footer string to close the rectangle 
        /// information table.
        /// </summary>
        /// <returns>A formatted string footer.</returns>
        public static string Footer()
        {
            return "--------------------------------------------------" +
                "-----" + Environment.NewLine;
        }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>The area computed as width multiplied by height.</returns>
        public double Area()
        {
            double sideA = Math.Abs(UpperLeftCorner.X - LowerRightCorner.X);
            double sideB = Math.Abs(UpperLeftCorner.Y - LowerRightCorner.Y);
            return sideA * sideB;
        }
    }
}
