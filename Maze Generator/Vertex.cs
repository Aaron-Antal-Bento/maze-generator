using System.Collections.Generic;

namespace Maze_Generator
{
    internal class Vertex
    {
        Node node;
        List<int> exits = new List<int>();
        List<int> visitedExits = new List<int>();
        bool isStart;
        bool isEnd;
        int distance;
        bool deadEnd;
        List<Edge> edgesFromSource = new List<Edge>();

        public Vertex(Node node, List<int> exits, bool deadEnd)
        {
            this.node = node;
            this.exits = exits;
            this.deadEnd = deadEnd;
        }
        public Node GetNode()
        {
            //get the node to which this Vertex refers to
            return node;
        }

        public void SetIsStart(bool isStart)
        {
            this.isStart = isStart;
        }
        public void SetIsEnd(bool isEnd)
        {
            this.isEnd = isEnd;
        }
        public bool GetIsStart()
        {
            return isStart;
        }
        public bool GetIsEnd()
        {
            return isEnd;
        }

        public List<int> GetExits()
        {
            return exits;
        }
        public List<int> GetVisitedExits()
        {
            return visitedExits;
        }
        public void AddToVisitedExits(int exit)
        {
            visitedExits.Add(exit);
        }
        public bool GetIsDeadEnd()
        {
            return deadEnd;
        }

        public void SetDistance(int distance)
        {
            //distance from source node
            this.distance = distance;
        }
        public int GetDistance()
        {
            return distance;
        }
        public void SetEdgesFromSource(Edge edge)
        {
            //add to path from source node
            edgesFromSource.Add(edge);
        }
        public void SetEdgesFromSource(List<Edge> edges)
        {
            //path from source node
            foreach (Edge edge in edges)
            {
                edgesFromSource.Add(edge);
            }
        }
        public List<Edge> GetEdgesFromSource()
        {
            return edgesFromSource;
        }
        public void ClearEdgesFromSource()
        {
            edgesFromSource.Clear();
        }
    }
}
