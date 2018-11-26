using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var input = reader.Read();
            var parser = new GraphParser();
            var graph = parser.ParseGraph(input);
            var spanningTree = GraphAlgorithms.YPD(graph);
            var res = parser.SerializeGraph(spanningTree);
            reader.Write(res);
        }
    }
}