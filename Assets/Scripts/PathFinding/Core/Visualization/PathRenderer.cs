using System.Collections.Generic;
using UnityEngine;

namespace PathFinding.Core.Visualization
{
    public class PathRenderer
    {
        private readonly List<GameObject> _lineObjects = new List<GameObject>();  

        public void RenderPath(List<Vector2> path, Color color, float width)
        {
            var lineRenderer = CreateLineRenderer(color, width); 

            lineRenderer.positionCount = path.Count;
            for (var i = 0; i < path.Count; i++)
            {
                lineRenderer.SetPosition(i, path[i]);
            }
        }
        
        private LineRenderer CreateLineRenderer(Color color, float width)
        {
            var lineObject = new GameObject("PathLine");
            var lineRenderer = lineObject.AddComponent<LineRenderer>();

            _lineObjects.Add(lineObject);

            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            return lineRenderer;
        }

        public void ClearPath()
        {
            foreach (var lineObject in _lineObjects)
            {
                Object.Destroy(lineObject);
            }

            _lineObjects.Clear();  
        }
    }
}