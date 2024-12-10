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
                new CustomRectangle(new Vector2(-10,0), new Vector2(0,10)),
                new CustomRectangle(new Vector2(-10,10), new Vector2(0, 20)),
                new Vector2(-10,10),
                new Vector2(0,10)),

            new Edge(
                new CustomRectangle(new Vector2(-10,10), new Vector2(0, 20)),
                new CustomRectangle(new Vector2(-10,20), new Vector2(0, 30)),
                new Vector2(-10,20),
                new Vector2(0,20)),

            new Edge(
                new CustomRectangle(new Vector2(-10,20), new Vector2(0, 30)),
                new CustomRectangle(new Vector2(-10,30), new Vector2(0, 40)),
                new Vector2(-10,30),
                new Vector2(0,30)),

            new Edge(
                new CustomRectangle(new Vector2(-10,30), new Vector2(0, 40)),
                new CustomRectangle(new Vector2(0,30), new Vector2(10, 40)),
                new Vector2(0,30),
                new Vector2(0,40)),

            new Edge(
                new CustomRectangle(new Vector2(0,30), new Vector2(10, 40)),
                new CustomRectangle(new Vector2(10,30), new Vector2(20, 40)),
                new Vector2(10,30),
                new Vector2(10,40)),

            new Edge(
                new CustomRectangle(new Vector2(10,30), new Vector2(20, 40)),
                new CustomRectangle(new Vector2(20,30), new Vector2(30, 40)),
                new Vector2(20,30),
                new Vector2(20,40)),
            
            new Edge(
                new CustomRectangle(new Vector2(20,30), new Vector2(30, 40)),
                new CustomRectangle(new Vector2(30,30), new Vector2(40, 40)),
                new Vector2(30,30),
                new Vector2(30,40)),

            new Edge(
                new CustomRectangle(new Vector2(30,30), new Vector2(40, 40)),
                new CustomRectangle(new Vector2(30,30), new Vector2(40, 20)),
                new Vector2(30,30),
                new Vector2(40,30)),

            new Edge(
                new CustomRectangle(new Vector2(30,30), new Vector2(40, 20)),
                new CustomRectangle(new Vector2(30,20), new Vector2(40, 10)),
                new Vector2(30,20),
                new Vector2(40,20)),

            new Edge(
                new CustomRectangle(new Vector2(30,20), new Vector2(40, 10)),
                new CustomRectangle(new Vector2(30,10), new Vector2(40, 0)),
                new Vector2(30,10),
                new Vector2(40,10)),

            new Edge(
                new CustomRectangle(new Vector2(30,10), new Vector2(40, 0)),
                new CustomRectangle(new Vector2(20,0), new Vector2(30, 10)),
                new Vector2(30,0),
                new Vector2(30,10)),

            new Edge(
                new CustomRectangle(new Vector2(20,0), new Vector2(30, 10)),
                new CustomRectangle(new Vector2(10,0), new Vector2(20, 10)),
                new Vector2(20,0),
                new Vector2(20,10)),

            new Edge(
                new CustomRectangle(new Vector2(10,0), new Vector2(20, 10)),
                new CustomRectangle(new Vector2(10,10), new Vector2(20, 20)),
                new Vector2(10,10),
                new Vector2(20,10)),
        };
       
        public static (Vector2 start, Vector2 end, List<Edge> edges) TestCase =>
        (
            new Vector2(-5, 0),
            new Vector2(15, 20), 
            ExampleEdges
        );
    }
}