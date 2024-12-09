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
            var width = .22f;
            _pathRenderer.RenderPath(path, color, width);
        }

        public void Clear()
        {
            _pathRenderer.ClearPath();
        }

        private void DrawRectangle(CustomRectangle customRectangle)
        {
            var corners = new Vector2[4];
            corners[0] = customRectangle.Min;
            corners[1] = new Vector2(customRectangle.Min.x, customRectangle.Max.y);
            corners[2] = customRectangle.Max;
            corners[3] = new Vector2(customRectangle.Max.x, customRectangle.Min.y);

            var color = Color.green;
            var width = .1f;
            
            _pathRenderer.RenderPath(new List<Vector2> { corners[0], corners[1], corners[2], corners[3], corners[0] }, color, width);
        }
    }
}