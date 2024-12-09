using UnityEngine;

namespace PathFinding.Core.Models
{
    public struct Edge
    {
        public CustomRectangle First { get; }
        public CustomRectangle Second { get; }
        public Vector2 Start { get; }

        public Vector2 End { get; }
        
        public Edge(CustomRectangle first, CustomRectangle second, Vector2 start, Vector2 end)
        {
            First = first;
            Second = second;
            Start = start;
            End = end;
        }
    }
}