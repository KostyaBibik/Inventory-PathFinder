using System.Collections.Generic;
using PathFinding.Core.Models;
using UnityEngine;

namespace PathFinding.Test
{
    public static class PathFinderTestData
    {
        public static List<Edge> ExampleEdges => new List<Edge>
        {
            new Edge(
                new CustomRectangle(new Vector2(0, 0), new Vector2(2, 2)),
                new CustomRectangle(new Vector2(2, 0), new Vector2(4, 3)),
                new Vector2(2, 0),
                new Vector2(2, 2)),

            new Edge(
                new CustomRectangle(new Vector2(4, 1), new Vector2(6, 5)),
                new CustomRectangle(new Vector2(6, 0), new Vector2(10, 2)),
                new Vector2(6, 1),
                new Vector2(6, 5)),
            new Edge(
                new CustomRectangle(new Vector2(8, 2), new Vector2(14, 5)),
                new CustomRectangle(new Vector2(12, 5), new Vector2(18, 7)),
                new Vector2(12, 5),
                new Vector2(14, 5)),
            new Edge(
                new CustomRectangle(new Vector2(7, 7), new Vector2(14, 14)),
                new CustomRectangle(new Vector2(0, 6), new Vector2(7, 9)),
                new Vector2(7, 7),
                new Vector2(7, 9)),
            new Edge(
                new CustomRectangle(new Vector2(-3, 4), new Vector2(0, 8)),
                new CustomRectangle(new Vector2(-15, 2), new Vector2(-3, 6)),
                new Vector2(-3, 4),
                new Vector2(-3, 6))
        };

        public static (Vector2 start, Vector2 end, List<Edge> edges) TestCase =>
        (
            new Vector2(0, 0), 
            new Vector2(-8, 3), 
            ExampleEdges
        );
    }
}