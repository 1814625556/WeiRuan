using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructure
{
    public class Graph
    {
        /// <summary>
        /// 图的相关节点
        /// </summary>
        public List<GraphNode> Nodes { get; set; }       
        
        /// <summary>
        /// 节点相关边
        /// </summary>
        public List<Edge> Edges { get; set; }

        /// <summary>
        /// 深度优先遍历查找
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="fromNode"></param>
        /// <param name="endNode"></param>
        public void Dfs(GraphNode fromNode, GraphNode endNode)
        {
            //条件检测
            if (!this.Nodes.Contains(fromNode) || !this.Nodes.Contains(endNode)) return;
            fromNode.IsSearched = true;
            Console.Write(fromNode.NodeName);
            foreach (var node in fromNode.AdjacentNodes.FindAll(x => !x.IsSearched))
            {
                Console.Write("-");
                if (node == endNode)
                {
                    Console.Write(node.NodeName);
                    return;
                }
                Dfs(node, endNode);
            }
        }

        //深度优先遍历查找所有路径--已验证
        //todo 查找最短路径
        public void DfsPath(GraphNode fromNode, GraphNode endNode,Stack<GraphNode> stack)
        {
            //条件检测
            if (!this.Nodes.Contains(fromNode) || !this.Nodes.Contains(endNode)) return;            

            fromNode.IsSearched = true;
            stack.Push(fromNode);

            if (fromNode.NodeName == endNode.NodeName) {
                Console.Write("router：");
                foreach (var node in stack.ToArray().Reverse())
                {
                    Console.Write($"{node.NodeName} ");
                }
                Console.WriteLine();
                stack.Pop();
            }
            else
            {
                var adjaNodesNoSearched = fromNode.AdjacentNodes.FindAll(x => !x.IsSearched 
                || x.NodeName == endNode.NodeName);
                
                //逐层弹出
                if (adjaNodesNoSearched.Count == 0)
                {
                    stack.Pop();
                    do
                    {
                        var temp = stack.Pop();
                        adjaNodesNoSearched = temp.AdjacentNodes.FindAll(x => !x.IsSearched 
                        || x.NodeName == endNode.NodeName);
                    } while ((adjaNodesNoSearched.Count == 0));
                }
                else
                {
                    foreach (var node in adjaNodesNoSearched)
                    {
                        DfsPath(node, endNode, stack);
                    }
                }
            }
        }



        /// <summary>
        /// 广度优先遍历查找,这里利用了队列的特性
        /// </summary>
        /// <param name="fromeNode"></param>
        /// <param name="endNode"></param>
        public void Bfs(GraphNode fromNode, GraphNode endNode)
        {
            //条件检测
            if (!this.Nodes.Contains(fromNode) || !this.Nodes.Contains(endNode)) return;
            var queue = new Queue<GraphNode>();
            queue.Enqueue(fromNode);
            while(queue.Count>0)
            {
                var isSuccess = queue.TryDequeue(out var node);
                if (!isSuccess) continue;
                node.IsSearched = true;
                if (node.NodeName == endNode.NodeName) {
                    Console.WriteLine("=========find it ===========");
                    break;
                }

                foreach (var nd in node.AdjacentNodes.FindAll(x=>!x.IsSearched))
                {
                    queue.Enqueue(nd);
                }
            }

        }

        /// <summary>
        /// 广度优先搜索查找所有路径--已验证
        /// </summary>
        /// <param name="fromNode"></param>
        /// <param name="endNode"></param>
        /// <param name="records"></param>
        public void BfsPath(GraphNode fromNode, GraphNode endNode)
        {
            //条件检测
            if (!this.Nodes.Contains(fromNode) || !this.Nodes.Contains(endNode)) return;

            var records = new Dictionary<GraphNode, GraphNode>
                {
                    { fromNode, null }
                };
            //路径保存
            var pathResult = new List<string>();
            //队列-先进先出，控制遍历顺序
            var queue = new Queue<GraphNode>();
            queue.Enqueue(fromNode);

            while (queue.Count > 0)
            {
                if(!queue.TryDequeue(out GraphNode node)) continue;

                //设置节点访问过了
                node.IsSearched = true;
                var adjacentNodes = node.AdjacentNodes.FindAll(x => !x.IsSearched || x.NodeName == endNode.NodeName);
                foreach (var nd in adjacentNodes.Where(x => x.NodeName != endNode.NodeName))
                {
                    //遍历节点先后顺序保存
                    records.Add(nd, node);
                    //未遍历的节点入队列
                    queue.Enqueue(nd);
                }

                //发现 要查找的节点
                var en = adjacentNodes.FirstOrDefault(x => x.NodeName == endNode.NodeName);
                if (en == null) continue;

                //找到查找的节点
                records.Add(en, node);
                var temp = en;
                var tempRs = "";
                while (records[temp] != null)
                {
                    tempRs += $"{temp.NodeName},";
                    temp = records[temp];
                }
                //表示起始节点
                if (records[temp] == null) tempRs += $"{temp.NodeName}";
                pathResult.Add(tempRs);
                //移除end节点
                records.Remove(en);
            }

            foreach (var rs in pathResult)
            {
                var arr = rs.Split(',', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
                for (var i = 0; i < arr.Count; i++)
                {
                    if (i == arr.Count() - 1) 
                        Console.Write($"{arr[i]}");
                    else
                        Console.Write($"{arr[i]}->");
                }
                Console.WriteLine();
            }

        }

    }

    /// <summary>
    /// 节点
    /// </summary>
    public class GraphNode
    {
        /// <summary>
        /// 节点的名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 节点的数组下标
        /// </summary>
        public int NodeIndex { get; set; }

        /// <summary>
        /// 是否被遍历过
        /// </summary>
        public bool IsSearched { get; set; }

        /// <summary>
        /// 节点的相邻节点
        /// </summary>
        public List<GraphNode> AdjacentNodes { get; set; }
    }

    /// <summary>
    /// 边
    /// </summary>
    public class Edge
    {
        public GraphNode FromNode { get; set; }
        public GraphNode EndNode { get; set; }
        public int EdgeWeight { get; set; }
    }
}
