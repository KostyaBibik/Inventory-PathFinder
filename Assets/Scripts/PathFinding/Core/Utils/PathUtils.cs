using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PathFinding.Core.Models;

namespace PathFinding.Core.Utils
{
    public static class PathUtils
    {
        public const float PointSpacing = 0.2f;

        /// <summary>
        /// Builds a graph from given edges.
        /// </summary>
        public static List<Vector2> BuildGraph(IEnumerable<Edge> edges)
        {
            var points = new List<Vector2>();

            foreach (var edge in edges)
            {
                AddRectanglePoints(edge.First, points);
                AddRectanglePoints(edge.Second, points);
            }

            return points.Distinct().ToList();
        }

        /// <summary>
        /// Adds points within a rectangle to the graph.
        /// </summary>
        public static void AddRectanglePoints(CustomRectangle rectangle, List<Vector2> points)
        {
            var min = rectangle.Min;
            var max = rectangle.Max;

            for (var x = min.x; x <= max.x; x += PointSpacing)
            {
                for (var y = min.y; y <= max.y; y += PointSpacing)
                {
                    points.Add(new Vector2(x, y));
                }
            }
        }

        /// <summary>
        /// Finds the closest point to the target in the graph.
        /// </summary>
        public static Vector2? GetClosestPoint(Vector2 target, List<Vector2> points)
        {
            if (!points.Any())
                return null;

            return points.OrderBy(point => Vector2.Distance(point, target)).First();
        }

        /// <summary>
        /// Removes collinear points from the path.
        /// </summary>
        public static List<Vector2> RemoveCollinearPoints(List<Vector2> path, IEnumerable<Edge> edges)
        {
            var result = new List<Vector2> { path[0] };

            for (int i = 1; i < path.Count - 1; i++)
            {
                var prev = result.Last();
                var current = path[i];
                var next = path[i + 1];

                if (CanSkipPoint(prev, current, next, edges))
                {
                    continue;
                }

                result.Add(current);
            }

            result.Add(path.Last());
            return result;
        }

        /// <summary>
        /// Removes unnecessary points by connecting distant points.
        /// </summary>
        public static List<Vector2> RemoveCollinearAndUnnecessaryPoints(List<Vector2> path, IEnumerable<Edge> edges)
        {
            bool changesMade;
            var optimizedPath = new List<Vector2>(path);

            do
            {
                changesMade = false; 

                for (int i = 0; i < optimizedPath.Count - 1; i++)
                {
                    for (int j = i + 2; j < optimizedPath.Count; j++) 
                    {
                        if (CanConnect(optimizedPath[i], optimizedPath[j], edges))
                        {
                            optimizedPath.RemoveRange(i + 1, j - i - 1);
                            changesMade = true; 
                            break; 
                        }
                    }
                }
            } while (changesMade); 

            return optimizedPath;
        }

        private static bool CanSkipPoint(Vector2 prev, Vector2 current, Vector2 next, IEnumerable<Edge> edges)
        {
            if (IsCollinear(prev, current, next))
                return true;

            if (CanConnect(prev, next, edges))
                return true;

            return false; 
        }

        private static bool IsCollinear(Vector2 a, Vector2 b, Vector2 c)
        {
            return Mathf.Abs((b.y - a.y) * (c.x - b.x) - (b.x - a.x) * (c.y - b.y)) < 0.0001f;
        }

        public static bool CanConnect(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (IsLineInsideRectangle(start, end, edge.First) || IsLineInsideRectangle(start, end, edge.Second))
                    return true;
            }

            return false;
        }

        private static bool IsLineInsideRectangle(Vector2 start, Vector2 end, CustomRectangle rectangle)
        {
            return IsPointInsideRectangle(start, rectangle) && IsPointInsideRectangle(end, rectangle);
        }

        private static bool IsPointInsideRectangle(Vector2 point, CustomRectangle rectangle)
        {
            return point.x >= rectangle.Min.x && point.x <= rectangle.Max.x &&
                   point.y >= rectangle.Min.y && point.y <= rectangle.Max.y;
        }

        /// <summary>
        /// Optimizes start and end points of the path.
        /// </summary>
        public static IEnumerable<Vector2> OptimizeStartAndEnd(List<Vector2> path, Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            var firstPoint = path.First();
            var lastPoint = path.Last();

            if (CanConnect(start, firstPoint, edges))
            {
                path[0] = start; 
            }

            if (CanConnect(lastPoint, end, edges))
            {
                path[path.Count - 1] = end; 
            }

            return path;
        }
    }
}
