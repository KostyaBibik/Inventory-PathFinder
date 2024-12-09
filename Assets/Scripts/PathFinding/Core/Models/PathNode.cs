using UnityEngine;

namespace PathFinding.Core.Models
{
    public class PathNode
    {
        public Vector2 Position { get; }
        public int Turns { get; } 
        public Vector2? Direction { get; } 

        public PathNode(Vector2 position, int turns, Vector2? direction)
        {
            Position = position;
            Turns = turns;
            Direction = direction;
        }
    }

}