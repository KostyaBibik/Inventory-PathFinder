using System.Collections.Generic;
using PathFinding.Core.Models;
using UnityEngine;

namespace PathFinding.Core.Visualization
{
    public interface IDrawer
    {
        public void DrawRectangles(IEnumerable<Edge> edges);
        public void DrawPath(List<Vector2> path);
        public void Clear();
    }
}