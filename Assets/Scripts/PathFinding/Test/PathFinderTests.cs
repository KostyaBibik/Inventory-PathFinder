using System.Linq;
using PathFinding.Core.Interfaces;
using PathFinding.Core.Visualization;
using UnityEngine;
using Zenject;

namespace PathFinding.Test
{
    public class PathFinderTests : MonoBehaviour
    {
        [Inject] private readonly IPathFinder _pathFinder;
        [Inject] private readonly IDrawer _pathDrawer;

        private void Awake()
        {
            RunTest();
        }

        private void RunTest()
        {
            TestSimplePath();
        }

        private void TestSimplePath()
        {
            var (start, end, edges) = PathFinderTestData.TestCase;
            
            _pathDrawer.Clear();
            _pathDrawer.DrawRectangles(edges);
            
            var actualPath = _pathFinder.GetPath(start, end, edges);
            
            _pathDrawer.DrawPath(actualPath.ToList());
        }
    }
}