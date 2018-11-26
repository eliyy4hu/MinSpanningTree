using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class GraphParser
    {
        public Graph ParseGraph(string input)
        {
            var lines = input.Split().Where(x => x != "").ToList();
            var nodesCount = int.Parse(lines[0]);
            var graphLines = lines.Skip(1).ToList();
            var graphMatrix = new int[nodesCount, nodesCount];
            for (int i = 0; i < nodesCount * nodesCount; i++)
            {
                graphMatrix[i / nodesCount, i % nodesCount] = int.Parse(graphLines[i]);
            }

            var nodes = new List<Node>();
            for (var i = 0; i < nodesCount; i++)
            {
                nodes.Add(new Node(i));
            }

            var graph = new Graph();
            for (var i = 0; i < nodesCount; i++)
            {
                for (var j = 0; j < nodesCount; j++)
                {
                    if (graphMatrix[i, j] != 32767)
                    {
                        graph.AttachNode(nodes[i], nodes[j], graphMatrix[i, j]);
                    }
                }
            }

            return graph;
        }

        public string SerializeGraph(Graph graph)
        {
            var nodes = graph.Nodes.OrderBy(x => x.Number).ToList();
            var arr = new int[nodes.Count, nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    arr[i, j] = 32767;
                }
            }

            foreach (var edge in graph.Edges)
            {
                arr[edge.FirstNode.Number, edge.SecondNode.Number] = edge.Weight;
                arr[edge.SecondNode.Number, edge.FirstNode.Number] = edge.Weight;
            }

            var result = new StringBuilder();
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    result.Append(arr[i, j].ToString());
                    result.Append(" ");
                }

                result.Append("0");
                result.Append("\r\n");
            }

            result.Append(graph.Edges.Sum(x => x.Weight).ToString());
            return result.ToString();
        }
    }
}