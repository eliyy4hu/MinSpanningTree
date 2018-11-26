using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    public static class GraphAlgorithms
    {
        public static Graph YPD(Graph graph)
        {
            var growingTree = new Graph();
            growingTree.AddNode(graph.Nodes.First());
            while (growingTree.Nodes.Count != graph.Nodes.Count)
            {
                YPD_AddNodeToTree(graph, growingTree);
            }

            return growingTree;
        }

        private static void YPD_AddNodeToTree(Graph graph, Graph growingTree)
        {
            var edgesIncidentToTree = new HashSet<Edge>();
            foreach (var growingTreeNode in growingTree.Nodes)
            {
                foreach (var edge in graph.nodeToEdges[growingTreeNode])
                {
                    if (!(growingTree.Nodes.Contains(edge.FirstNode) && growingTree.Nodes.Contains(edge.SecondNode)))
                        edgesIncidentToTree.Add(edge);
                }
            }

            var maxWeight = edgesIncidentToTree.Min(x => x.Weight);
            var newEdge = edgesIncidentToTree.First(x => x.Weight == maxWeight);
            growingTree.AttachNode(newEdge.FirstNode, newEdge.SecondNode, newEdge.Weight);
        }
    }
}