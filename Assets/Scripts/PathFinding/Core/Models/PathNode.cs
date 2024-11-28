using System.Collections.Generic;
using UnityEngine;

namespace PathFinding.Core.Models
{
    public class PathNode
    {
        public Vector2 Position { get; }
        public int TurnCount { get; }
        public List<Vector2> Path { get; }
        public Vector2 PreviousPosition { get; }

        public PathNode(Vector2 position, int turnCount, List<Vector2> path)
        {
            Position = position;
            TurnCount = turnCount;
            Path = path;
            PreviousPosition = path.Count > 1 
                ? path[path.Count - 2]
                : position;
        }
    }
}