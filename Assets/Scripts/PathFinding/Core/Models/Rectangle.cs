using UnityEngine;

namespace PathFinding.Core.Models
{
    public struct Rectangle
    {
        /// <summary>
        /// The bottom-left corner of the rectangle.
        /// </summary>
        public Vector2 Min { get; }

        /// <summary>
        /// The top-right corner of the rectangle.
        /// </summary>
        public Vector2 Max { get; }

        public Rectangle(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }
    }
}