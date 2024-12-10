using System.Collections.Generic;
using PathFinding.Core.Models;
using UnityEngine;
using Zenject;

namespace PathFinding.Core.Visualization
{
    public class PathDrawer : IDrawer, IInitializable
    {
        private Transform _rectanglesParent;
        
       private readonly PathRenderer _pathRenderer = new PathRenderer();

       public void Initialize()
       {
           if(_rectanglesParent == null)
           {
               _rectanglesParent = new GameObject("Rectangles").transform;
           }
       }

       public void DrawRectangles(IEnumerable<Edge> edges)
        {
            foreach (var edge in edges)
            {
                DrawRectangle(edge.First);
                DrawRectangle(edge.Second);
            }
        }

        public void DrawPath(List<Vector2> path)
        {
            var color = Color.red;
            var width = .25f;
            _pathRenderer.RenderPath(path, color, width);
        }

        public void Clear()
        {
            _pathRenderer.ClearPath();
        }

        private void DrawRectangle(CustomRectangle rectangle)
        {
            var corners = new Vector2[4];
            corners[0] = rectangle.Min;
            corners[1] = new Vector2(rectangle.Min.x, rectangle.Max.y);
            corners[2] = rectangle.Max;
            corners[3] = new Vector2(rectangle.Max.x, rectangle.Min.y);

            var color = Color.green;
            var width = .1f;
            
            var renderer = _pathRenderer.RenderPath(new List<Vector2> { corners[0], corners[1], corners[2], corners[3], corners[0] }, color, width);
            
            if (_rectanglesParent == null)
            {
                Initialize();
            }
            
            renderer.transform.SetParent(_rectanglesParent);
        }
    }
}