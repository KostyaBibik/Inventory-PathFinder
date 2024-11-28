using UnityEngine;

namespace PathFinding.Core.Models
{
    public struct Edge
    {
        public Rectangle First { get; }
        public Rectangle Second { get; }
        public Vector2 Start { get; }

        public Vector2 End { get; }
        
        public Edge(Rectangle first, Rectangle second, Vector2 start, Vector2 end)
        {
            First = first;
            Second = second;
            Start = start;
            End = end;
        }
    }
}