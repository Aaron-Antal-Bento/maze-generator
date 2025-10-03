using System.Collections.Generic;

namespace Maze_Generator
{
    class MazeCellPath
    {
        Node startNode;
        Node endNode;

        List<Node> edgeNodes = new List<Node>();

        bool deadEnd;
        bool calculated;

        public MazeCellPath(Node startNode)
        {
            this.startNode = startNode;
            endNode = null;
        }
        public void AddNodesToEdge(Node node)
        {
            //adds nodes to node that make up this edge
            edgeNodes.Add(node);
        }
        public void AddEndNode(Node node)
        {
            endNode = node;
        }
        public void SetCalculated(bool c)
        {
            this.calculated = c;
        }
        public void SetDeadEnd(bool c)
        {
            this.deadEnd = c;
        }
        public bool IsDeadEnd()
        {
            return deadEnd;
        }
        public Node GetFirstCell()
        {
            return startNode;
        }
        public Node GetLastCell()
        {
            return endNode;
        }
        public void ClearEdge()
        {
            //removes solve line and sets all nodes in this edge as not part of solve line
            for (int i = 0; i < edgeNodes.Count; i++)
            {
                edgeNodes[i].DeleteMazePath();
                edgeNodes[i].SetPartOfEdge(false);
            }
            if (endNode != null)
            {
                endNode.DeleteMazePath();
                endNode.SetPartOfEdge(false);
            }
        }
        public Node GetEdgeSection(int index)
        {
            //returns specific node in edge
            if(edgeNodes.Count > index)
            {
                return edgeNodes[index];
            }
            else
            {
                //if index is too big return end node instead
                return endNode;
            }
        }
        public List<Node> GetNodesList()
        {
            //returns all nodes in edge
            return edgeNodes;
        }
        public List<Node> GetFullEdge()
        {
            //returns all nodes in edge, start and end
            List<Node> nodes = new List<Node>();

            nodes.Add(startNode);
            foreach(Node n in edgeNodes)
            {
                nodes.Add(n);
            }
            nodes.Add(endNode);

            return nodes;
        }
    }
}
