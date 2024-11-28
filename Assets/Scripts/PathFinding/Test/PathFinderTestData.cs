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
                new Rectangle(new Vector2(-15, 15), new Vector2(2, 25)),
                new Rectangle(new Vector2(-3, 25), new Vector2(17, 35)), 
                new Vector2(-3, 25),
                new Vector2(2, 25)),
            
            new Edge(
                new Rectangle(new Vector2(-3, 25), new Vector2(17, 35)),
                new Rectangle(new Vector2(17, 20), new Vector2(37, 30)),
                new Vector2(17, 25), 
                new Vector2(17, 30)),
        };
        
        public static (Vector2 start, Vector2 end, List<Edge> edges) TestCase =>
        (
            new Vector2(-6.5f, 15),
            new Vector2(37, 25),
            ExampleEdges
        );
    }
}