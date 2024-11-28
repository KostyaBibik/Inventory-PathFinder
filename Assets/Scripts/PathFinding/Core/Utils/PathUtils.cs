using System.Collections.Generic;
using PathFinding.Core.Models;
using UnityEngine;

namespace PathFinding.Core.Utils
{
    public static class PathUtils
    {
        /// <summary>
        /// Returns a list of all edges of a rectangle.
        /// </summary>
        public static List<(Vector2 start, Vector2 end)> GetRectangleEdges(Rectangle rect)
        {
            return new List<(Vector2, Vector2)>
            {
                (new Vector2(rect.Min.x, rect.Min.y), new Vector2(rect.Max.x, rect.Min.y)), 
                (new Vector2(rect.Max.x, rect.Min.y), new Vector2(rect.Max.x, rect.Max.y)), 
                (new Vector2(rect.Max.x, rect.Max.y), new Vector2(rect.Min.x, rect.Max.y)),
                (new Vector2(rect.Min.x, rect.Max.y), new Vector2(rect.Min.x, rect.Min.y)) 
            };
        }

        /// <summary>
        /// Checks if a direct path between two points is clear (i.e., does not intersect with any rectangles).
        /// </summary>
        public static bool IsDirectPathClear(Vector2 start, Vector2 end, List<Rectangle> obstacles)
        {
            foreach (var rect in obstacles)
            {
                if (DoesLineIntersectRectangle(start, end, rect))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a line segment intersects with a rectangle.
        /// </summary>
        private static bool DoesLineIntersectRectangle(Vector2 start, Vector2 end, Rectangle rect)
        {
            var edges = GetRectangleEdges(rect);

            foreach (var (edgeStart, edgeEnd) in edges)
            {
                if (DoLinesIntersect(start, end, edgeStart, edgeEnd))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if two line segments intersect.
        /// </summary>
        private static bool DoLinesIntersect(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
        {
            var d1 = Cross(b2 - b1, a1 - b1);
            var d2 = Cross(b2 - b1, a2 - b1);
            var d3 = Cross(a2 - a1, b1 - a1);
            var d4 = Cross(a2 - a1, b2 - a1);

            return d1 * d2 < 0 && d3 * d4 < 0;
        }

        /// <summary>
        /// Calculates the number of turns between three points.
        /// </summary>
        public static int CalculateTurnCount(Vector2 previous, Vector2 current, Vector2 next)
        {
            var dir1 = (current - previous).normalized;
            var dir2 = (next - current).normalized;

            return Vector2.Dot(dir1, dir2) < 0.99f ? 1 : 0; // Returns 1 if there's an angle
        }

        private static float Cross(Vector2 v1, Vector2 v2)
            => v1.x * v2.y - v1.y * v2.x;
    }
}
