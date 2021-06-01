using System;
using System.Collections.Generic;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Graph graph = new Graph();
            graph.Nodes = new List<GraphNode>();
            //构建节点
            for (var i = 0; i < 9; i++)
            {
                graph.Nodes.Add(new GraphNode()
                {
                    NodeName = $"A{i}",
                    NodeIndex = i,
                }) ;
            }

            //构建关联节点

            graph.Nodes[0].AdjacentNodes = new List<GraphNode>() {graph.Nodes[3],graph.Nodes[7]};
            graph.Nodes[1].AdjacentNodes = new List<GraphNode>() { graph.Nodes[2], graph.Nodes[4],graph.Nodes[7] };
            graph.Nodes[2].AdjacentNodes = new List<GraphNode>() { graph.Nodes[1],graph.Nodes[6]};
            graph.Nodes[3].AdjacentNodes = new List<GraphNode>() { graph.Nodes[0],graph.Nodes[5],graph.Nodes[6] };
            graph.Nodes[4].AdjacentNodes = new List<GraphNode>() { graph.Nodes[1],graph.Nodes[6] };
            graph.Nodes[5].AdjacentNodes = new List<GraphNode>() { graph.Nodes[3] };
            graph.Nodes[6].AdjacentNodes = new List<GraphNode>() { graph.Nodes[4],graph.Nodes[3],graph.Nodes[2]};
            graph.Nodes[7].AdjacentNodes = new List<GraphNode>() { graph.Nodes[1],graph.Nodes[0],graph.Nodes[8]};
            graph.Nodes[8].AdjacentNodes = new List<GraphNode>() { graph.Nodes[7] };

            //graph.Dfs(graph.Nodes[5],graph.Nodes[1]);

            graph.BfsPath(graph.Nodes[5], graph.Nodes[1]);

            Console.ReadKey();
        }
    }
}
