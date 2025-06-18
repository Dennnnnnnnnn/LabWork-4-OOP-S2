//IOUtils.cs
using System;
using System.IO;

namespace L4
{
    static class IOUtils
    {
        /// <summary>
        /// Reads rectangles from a file and returns them in a linked list.
        /// </summary>
        /// <param name="filename">Path to the input file.</param>
        /// <returns>A GenericDoublyLinkedList containing 
        /// Rectangle objects.</returns>
        public static GenericDoublyLinkedList<Rectangle> 
            ReadRectangles(string filename)
        {
            GenericDoublyLinkedList<Rectangle> rectangles = 
                new GenericDoublyLinkedList<Rectangle>();
            string line = null;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    // Read each line until end of file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split line by semicolon separator
                        string[] parts = line.Split(';');
                        try
                        {
                            // Parse rectangle properties
                            string rectangleName = parts[0];
                            Point upperLeftCorner = new Point
                                (int.Parse(parts[1]), int.Parse(parts[2]));
                            Point lowerRightCorner = new Point
                                (int.Parse(parts[3]), int.Parse(parts[4]));
                            // Create new Rectangle object
                            Rectangle rectangle = new Rectangle(rectangleName, 
                                upperLeftCorner, lowerRightCorner);
                            // Add to list if not already contained
                            if (!rectangles.Contains(rectangle))
                            {
                                rectangles.AddToEnd(rectangle);
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Rethrow exception for handling upstream
                throw;
            }
            return rectangles;
        }

        /// <summary>
        /// Reads triangles from a file and returns them in a linked list.
        /// </summary>
        /// <param name="filename">Path to the input file.</param>
        /// <returns>A GenericDoublyLinkedList containing 
        /// Triangle objects.</returns>
        public static GenericDoublyLinkedList<Triangle> 
            ReadTriangles(string filename)
        {
            GenericDoublyLinkedList<Triangle> triangles = 
                new GenericDoublyLinkedList<Triangle>();
            string line = null;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    // Read each line until end of file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split line by semicolon separator
                        string[] parts = line.Split(';');
                        // Parse triangle properties
                        string triangleName = parts[0];
                        Point firstCorner = new Point
                            (int.Parse(parts[1]), int.Parse(parts[2]));
                        Point secondCorner = new Point
                            (int.Parse(parts[3]), int.Parse(parts[4]));
                        Point thirdCorner = new Point
                            (int.Parse(parts[5]), int.Parse(parts[6]));
                        // Create new Triangle object
                        Triangle triangle = new Triangle(triangleName, 
                            firstCorner, secondCorner, thirdCorner);
                        // Add to list if not already contained
                        if (!triangles.Contains(triangle))
                        {
                            triangles.AddToEnd(triangle);
                        }
                    }
                }
            }
            catch
            {
                // Rethrow exception for handling upstream
                throw;
            }
            return triangles;
        }
    }
}
