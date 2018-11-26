using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    public class Graph
    {
        public HashSet<Node> Nodes = new HashSet<Node>();
        public HashSet<Edge> Edges = new HashSet<Edge>();
        public Dictionary<Node, HashSet<Node>> nodeToNodes = new Dictionary<Node, HashSet<Node>>();
        public Dictionary<Node, HashSet<Edge>> nodeToEdges = new Dictionary<Node, HashSet<Edge>>();


        public void AddNode(Node node)
        {
            Nodes.Add(node);
            if (!nodeToNodes.ContainsKey(node))
                nodeToNodes[node] = new HashSet<Node>();
            if (!nodeToEdges.ContainsKey(node))
                nodeToEdges[node] = new HashSet<Edge>();
        }

        public void AttachNode(Node node, Node nodeToAttach, int weight)
        {
            AddNode(node);
            AddNode(nodeToAttach);
            if (nodeToNodes.ContainsKey(node) && nodeToNodes[node].Contains(nodeToAttach))
            {
                return;
            }

            nodeToNodes[node].Add(nodeToAttach);
            nodeToNodes[nodeToAttach].Add(node);
            var edge = new Edge(node, nodeToAttach, weight);
            Edges.Add(edge);
            nodeToEdges[node].Add(edge);
            nodeToEdges[nodeToAttach].Add(edge);
        }
    }
}