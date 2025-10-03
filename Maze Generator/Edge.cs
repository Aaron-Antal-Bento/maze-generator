using System.Collections.Generic;
using System.Drawing;

namespace Maze_Generator
{
    internal class Edge
    {
        Vertex start;
        Vertex end;
        List<Node> edge = new List<Node>();

        public Edge(Vertex start, Vertex end, List<Node> edge)
        {
            //defined by a start, end and list of nodes inbetween
            this.start = start;
            this.end = end;
            foreach(Node node in edge)
            {
                this.edge.Add(node);
            }
        }
        public Vertex GetStart()
        {
            return start;
        }
        public Vertex GetEnd()
        {
            return end;
        }
        public int Weight()
        {
            return edge.Count;
        }
        public void SolveEdge(Color c)
        {
            //displays solve line for this edge
            start.GetNode().ShowFullMazePath(c);
            foreach (Node node in edge)
            {
                node.ShowFullMazePath(c);
            }
            end.GetNode().ShowFullMazePath(c);
        }
        public List<Node> GetAllNodesInEdge()
        {
            //returns start, end and edge list nodes
            List<Node> nodes = new List<Node>();
            nodes.Add(start.GetNode());
            foreach(Node n in edge)
            {
                nodes.Add(n);
            }
            nodes.Add(end.GetNode());
            return nodes;
        }
    }
}
