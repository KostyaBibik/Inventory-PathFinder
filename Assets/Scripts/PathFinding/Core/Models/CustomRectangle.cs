using UnityEngine;

namespace PathFinding.Core.Models
{
    public struct CustomRectangle
    {
        /// <summary>
        /// The bottom-left corner of the rectangle.
        /// </summary>
        public Vector2 Min { get; }

        /// <summary>
        /// The top-right corner of the rectangle.
        /// </summary>
        public Vector2 Max { get; }

        public CustomRectangle(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }
        
        public static bool operator ==(CustomRectangle rect1, CustomRectangle rect2)
        {
            return rect1.Min == rect2.Min && rect1.Max == rect2.Max;
        }

        public static bool operator !=(CustomRectangle rect1, CustomRectangle rect2)
        {
            return !(rect1 == rect2);
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomRectangle)
            {
                var other = (CustomRectangle)obj;
                return this == other;
            }
            return false;
        }
    }
}