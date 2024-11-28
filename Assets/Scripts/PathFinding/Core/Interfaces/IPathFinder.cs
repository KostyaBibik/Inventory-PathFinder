using System.Collections.Generic;
using PathFinding.Core.Models;
using UnityEngine;

namespace PathFinding.Core.Interfaces
{
    public interface IPathFinder
    {
        IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, IEnumerable<Edge> edges);
    }
}