using System.Collections.Generic;
using PathFinding.Core.Models;
using UnityEngine;

namespace PathFinding.Core.Visualization
{
    public class PathDrawer : IDrawer
    {
       private readonly PathRenderer _pathRenderer = new PathRenderer();

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
            var width = .3f;
            _pathRenderer.RenderPath(path, color, width);
        }

        public void Clear()
        {
            _pathRenderer.ClearPath();
        }

        private void DrawRectangle(Rectangle rectangle)
        {
            var corners = new Vector2[4];
            corners[0] = rectangle.Min;
            corners[1] = new Vector2(rectangle.Min.x, rectangle.Max.y);
            corners[2] = rectangle.Max;
            corners[3] = new Vector2(rectangle.Max.x, rectangle.Min.y);

            var color = Color.green;
            var width = .1f;
            
            _pathRenderer.RenderPath(new List<Vector2> { corners[0], corners[1], corners[2], corners[3], corners[0] }, color, width);
        }
    }
}