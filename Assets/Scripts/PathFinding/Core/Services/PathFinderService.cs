using System.Collections.Generic;
using System.Linq;
using PathFinding.Core.Interfaces;
using PathFinding.Core.Models;
using PathFinding.Core.Utils;
using UnityEngine;

namespace PathFinding.Core.Services
{
    public class PathFinderService : IPathFinder
    {
        /// <summary>
        /// Finds a path between two points if a valid path exists.
        /// </summary>
        public IEnumerable<Vector2> GetPath(
            Vector2 start, 
            Vector2 end,
            IEnumerable<Edge> edges
        )
        {
            if (edges == null || !edges.Any()) 
                return Enumerable.Empty<Vector2>();

            var rectangles = edges
                .SelectMany(edge => new[] { edge.First, edge.Second })
                .Distinct()
                .ToList();

            if (!IsPointInsideAnyRectangle(start, rectangles) || !IsPointInsideAnyRectangle(end, rectangles))
                return Enumerable.Empty<Vector2>();

            var graph = BuildGraph(rectangles);
            AddPointToGraph(start, rectangles, graph);
            AddPointToGraph(end, rectangles, graph);

            return FindPath(start, end, graph, rectangles);
        }

        /// <summary>
        /// Builds a graph of connected points based on rectangle edges.
        /// </summary>
        private Dictionary<Vector2, List<Vector2>> BuildGraph(List<Rectangle> rectangles)
        {
            var graph = new Dictionary<Vector2, List<Vector2>>();

            foreach (var rect in rectangles)
            {
                var points = PathUtils.GetRectangleEdges(rect)
                                      .SelectMany(edge => new[] { edge.start, edge.end })
                                      .Distinct();

                foreach (var point in points)
                {
                    if (!graph.ContainsKey(point))
                        graph[point] = new List<Vector2>();

                    foreach (var neighbor in points)
                    {
                        if (point != neighbor && PathUtils.IsDirectPathClear(point, neighbor, rectangles))
                            graph[point].Add(neighbor);
                    }
                }
            }

            return graph;
        }

        /// <summary>
        /// Adds a new point to the graph and connects it to accessible points.
        /// </summary>
        private void AddPointToGraph(
            Vector2 point,
            List<Rectangle> rectangles,
            Dictionary<Vector2, List<Vector2>> graph
        )
        {
            if (graph.ContainsKey(point))
                return;

            graph[point] = new List<Vector2>();

            foreach (var existingPoint in graph.Keys.ToList())
            {
                if (PathUtils.IsDirectPathClear(point, existingPoint, rectangles))
                {
                    graph[point].Add(existingPoint);
                    graph[existingPoint].Add(point);
                }
            }
        }

        /// <summary>
        /// Finds the shortest path from start to end using a breadth-first search algorithm.
        /// </summary>
        private IEnumerable<Vector2> FindPath(
            Vector2 start,
            Vector2 end,
            Dictionary<Vector2, List<Vector2>> graph,
            List<Rectangle> rectangles
        )
        {
            var queue = new Queue<PathNode>();
            queue.Enqueue(new PathNode(start, 0, new List<Vector2> { start }));

            var visited = new HashSet<Vector2> { start };

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (PathUtils.IsDirectPathClear(current.Position, end, rectangles))
                {
                    current.Path.Add(end);
                    return current.Path;
                }

                foreach (var neighbor in graph[current.Position])
                {
                    if (visited.Contains(neighbor)) 
                        continue;

                    var newTurnCount = current.TurnCount + PathUtils.CalculateTurnCount(current.PreviousPosition, current.Position, neighbor);
                    var newPath = new List<Vector2>(current.Path) { neighbor };

                    queue.Enqueue(new PathNode(neighbor, newTurnCount, newPath));
                    visited.Add(neighbor);
                }
            }

            return Enumerable.Empty<Vector2>();
        }

        /// <summary>
        /// Checks if a point is inside any of the provided rectangles.
        /// </summary>
        private bool IsPointInsideAnyRectangle(
            Vector2 point,
            List<Rectangle> rectangles
        )
            => rectangles.Any(rect => point.x >= rect.Min.x && point.x <= rect.Max.x && point.y >= rect.Min.y && point.y <= rect.Max.y);
    }
}
