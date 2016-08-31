using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon001.Dijkstra
{
    public class Graph
    {
        public List<Node> m_nodeList = null;
        public Graph()
        {
            m_nodeList = new List<Node>();
        }

        /// <summary>
        /// 获取图的节点集合
        /// </summary>
        public List<Node> NodeList
        {
            get { return this.m_nodeList; }
        }

        /// <summary>
        /// 初始化拓扑图
        /// </summary>
        public void Init()
        {
            //***************** B Node *******************

            var line = string.Empty;
            var mn = Console.ReadLine();
            var arr = mn.Split(' ');
            var m = int.Parse(arr[0]);
            var n = int.Parse(arr[1]);

            for (var i = 0; i < m; i++)
            {
                var ftc = Console.ReadLine();
                var ftcs = ftc.Split(' ');
                var f = int.Parse(ftcs[0]);
                var t = int.Parse(ftcs[1]);
                var c = int.Parse(ftcs[2]);
                var fNode = GetNode(f.ToString());
                var tNode = GetNode(t.ToString());
                Edge edge = new Edge()
                {
                    StartNodeID = fNode.ID,
                    EndNodeID = tNode.ID,
                    Weight = c
                };
                fNode.EdgeList.Add(edge);
            }
        }


        private bool IsNodeExits(string id)
        {
            return NodeList.Any(n => n.ID == id);
        }

        private Node GetNode(string id)
        {
            if (!IsNodeExits(id))
            {
                var node = new Node(id);
                NodeList.Add(node);
                return node;
            }

            return NodeList.FirstOrDefault(n => n.ID == id);
        }
    }
}
