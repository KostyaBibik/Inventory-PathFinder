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
        /// Calculates an optimized path between start and end points.
        /// </summary>
        public IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
        {
            var graph = PathUtils.BuildGraph(edges);

            var startNode = PathUtils.HasPointInGraph(start, graph);
            var endNode = PathUtils.HasPointInGraph(end, graph);

            if (startNode == null || endNode == null)
                return Enumerable.Empty<Vector2>();

            var path = FindPathAStar(graph, startNode.Value, endNode.Value);

            if (path == null)
                return Enumerable.Empty<Vector2>();

            var optimizedPath = OptimizePath(path, edges, start, end);

            return optimizedPath;
        }

        /// <summary>
        /// Finds the path between start and end using A* algorithm.
        /// </summary>
        private IEnumerable<Vector2> FindPathAStar(List<Vector2> graph, Vector2 start, Vector2 end)
        {
            var openSet = new SortedSet<PathNode>(Comparer<PathNode>.Create((a, b) =>
            {
                var aCost = a.Turns + Vector2.Distance(a.Position, end);
                var bCost = b.Turns + Vector2.Distance(b.Position, end);
                return aCost.CompareTo(bCost);
            }));

            var cameFrom = new Dictionary<Vector2, PathNode>();

            var gScore = graph.ToDictionary(point => point, _ => float.MaxValue);
            gScore[start] = 0;

            openSet.Add(new PathNode(start, 0, null));

            while (openSet.Any())
            {
                var current = openSet.First();
                openSet.Remove(current);

                if (current.Position == end)
                    return ReconstructPath(cameFrom, current.Position);

                foreach (var neighbor in GetNeighbors(graph, current.Position))
                {
                    var direction = (neighbor - current.Position).normalized;
                    var turns = current.Direction.HasValue && current.Direction.Value != direction
                        ? current.Turns + 1 
                        : current.Turns;

                    var tentativeGScore = gScore[current.Position] + Vector2.Distance(current.Position, neighbor);

                    if (!(tentativeGScore < gScore[neighbor]))
                    {
                        continue;
                    }
                    
                    gScore[neighbor] = tentativeGScore;
                    var neighborNode = new PathNode(neighbor, turns, direction);

                    cameFrom[neighbor] = current;
                    openSet.Add(neighborNode);
                }
            }

            return new List<Vector2>();
        }

        /// <summary>
        /// Gets neighboring points of a given point within a distance.
        /// </summary>
        private IEnumerable<Vector2> GetNeighbors(List<Vector2> graph, Vector2 point)
            => graph.Where(other => Vector2.Distance(point, other) <= PathUtils.PointSpacing + 0.01f);

        /// <summary>
        /// Reconstructs the path from the goal to the start.
        /// </summary>
        private IEnumerable<Vector2> ReconstructPath(Dictionary<Vector2, PathNode> cameFrom, Vector2 current)
        {
            var totalPath = new List<Vector2> { current };

            while (cameFrom.TryGetValue(current, out var node))
            {
                current = node.Position;
                totalPath.Add(current);
            }

            totalPath.Reverse();
            return totalPath;
        }

        /// <summary>
        /// Optimizes the given path by removing unnecessary points.
        /// </summary>
        private IEnumerable<Vector2> OptimizePath(IEnumerable<Vector2> path, IEnumerable<Edge> edges, Vector2 start, Vector2 end)
        {
            var points = path.ToList();
            if (points.Count <= 1)
            {
                return null;
            }
            
            var optimizedPath = new List<Vector2> { points[0] };

            var index = 0;
            while (index < points.Count - 1)
            {
                var iterator = index + 1;
                var pathFound = false;

                while (iterator < points.Count && PathUtils.CanConnect(points[index], points[iterator], edges))
                {
                    pathFound = true;
                    iterator++;
                }

                if (pathFound)
                {
                    optimizedPath.Add(points[iterator - 1]);
                    index = iterator - 1;
                }
                else
                {
                    optimizedPath.Add(points[index + 1]);
                    index++;
                }
            }

            optimizedPath = PathUtils.RemoveCollinearPoints(optimizedPath, edges);
            optimizedPath = PathUtils.RemoveCollinearAndUnnecessaryPoints(optimizedPath, edges);
            optimizedPath = PathUtils.OptimizeStartAndEnd(optimizedPath, start, end, edges).ToList();

            return optimizedPath;
        }
    }
}
