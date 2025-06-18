//TaskUtils.cs
using System;

namespace L4
{
    static class TaskUtils
    {
        /// <summary>
        /// Finds all rectangles that contain exactly one vertex of 
        /// a triangle inside.
        /// </summary>
        /// <param name="rectangles">List of rectangles to check.</param>
        /// <param name="triangles">List of triangles to check.</param>
        /// <returns>List of rectangles with exactly one triangle vertex inside.</returns>
        public static GenericDoublyLinkedList<RectangleOneTriangleVertex> 
            OneTriangleVertexInside
            (GenericDoublyLinkedList<Rectangle> rectangles, 
            GenericDoublyLinkedList<Triangle> triangles)
        {
            GenericDoublyLinkedList<RectangleOneTriangleVertex> 
                oneTriangleVertexInside = new 
                GenericDoublyLinkedList<RectangleOneTriangleVertex>();

            foreach (Rectangle rect in rectangles)
            {
                foreach (Triangle tr in triangles)
                {
                    int insideCount = 0; 
                    Point insidePoint = new Point(); 

                    if (rect.UpperLeftCorner <= tr.FirstCorner && 
                        rect.LowerRightCorner >= tr.FirstCorner)
                    {
                        insideCount++;
                        insidePoint = tr.FirstCorner;
                    }
                    if (rect.UpperLeftCorner <= tr.SecondCorner && 
                        rect.LowerRightCorner >= tr.SecondCorner)
                    {
                        insideCount++;
                        insidePoint = tr.SecondCorner;
                    }
                    if (rect.UpperLeftCorner <= tr.ThirdCorner && 
                        rect.LowerRightCorner >= tr.ThirdCorner)
                    {
                        insideCount++;
                        insidePoint = tr.ThirdCorner;
                    }

                    if (insideCount == 1)
                    {
                        RectangleOneTriangleVertex add =
                            new RectangleOneTriangleVertex(rect.RectangleName, 
                            rect.UpperLeftCorner, rect.LowerRightCorner, 
                            tr.TriangleName, insidePoint);
                        oneTriangleVertexInside.AddToEnd(add);
                    }
                }
            }
            return oneTriangleVertexInside;
        }

        /// <summary>
        /// Finds all triangles that are fully inside rectangles.
        /// Returns a list of TriangleInsideRectangle objects representing 
        /// triangles fully contained in rectangles.
        /// </summary>
        /// <param name="rectangles">List of rectangles to check.</param>
        /// <param name="triangles">List of triangles to check.</param>
        /// <returns>List of triangles fully inside rectangles.</returns>
        public static GenericDoublyLinkedList<TriangleInsideRectangle> 
            TriangleInsideRectangle
            (GenericDoublyLinkedList<Rectangle> rectangles, 
            GenericDoublyLinkedList<Triangle> triangles)
        {
            GenericDoublyLinkedList<TriangleInsideRectangle> 
                trianglesInsideRectangle = 
                new GenericDoublyLinkedList<TriangleInsideRectangle>();

            foreach (Rectangle rect in rectangles)
            {
                foreach (Triangle tr in triangles)
                {
                    int insideCount = 0; 

                    if (rect.UpperLeftCorner <= tr.FirstCorner && 
                        rect.LowerRightCorner >= tr.FirstCorner)
                    {
                        insideCount++;
                    }
                    if (rect.UpperLeftCorner <= tr.SecondCorner && 
                        rect.LowerRightCorner >= tr.SecondCorner)
                    {
                        insideCount++;
                    }
                    if (rect.UpperLeftCorner <= tr.ThirdCorner && 
                        rect.LowerRightCorner >= tr.ThirdCorner)
                    {
                        insideCount++;
                    }

                    if (insideCount == 3)
                    {
                        TriangleInsideRectangle add = 
                            new TriangleInsideRectangle(rect.RectangleName, 
                            rect.UpperLeftCorner, rect.LowerRightCorner, 
                            tr.TriangleName, tr.FirstCorner, tr.SecondCorner,
                            tr.ThirdCorner);
                        trianglesInsideRectangle.AddToEnd(add);
                    }
                }
            }
            return trianglesInsideRectangle;
        }

        /// <summary>
        /// Finds the object with the largest area from a list of 
        /// objects that implement IAreaMeasurable.
        /// </summary>
        /// <typeparam name="T">Type of objects that must implement 
        /// IAreaMeasurable, IComparable, and IEquatable.</typeparam>
        /// <param name="data">The list of objects to search.</param>
        /// <returns>The object with the largest area.</returns>
        public static T LargestObject<T>(GenericDoublyLinkedList<T> data) 
            where T : IAreaMeasurable, IComparable<T>, IEquatable<T>
        {
            double largestArea = 0; // Tracks the largest area
            T largestObject = default;

            foreach (T obj in data)
            {
                if (obj.Area() > largestArea)
                {
                    largestArea = obj.Area();
                    largestObject = obj;
                }
            }

            return largestObject;
        }
    }
}
