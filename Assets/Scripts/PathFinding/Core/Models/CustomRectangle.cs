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

        public CustomRectangle(Vector2 first, Vector2 second)
        {
            Min = new Vector2(Mathf.Min(first.x, second.x), Mathf.Min(first.y, second.y));
            Max = new Vector2(Mathf.Max(first.x, second.x), Mathf.Max(first.y, second.y));
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