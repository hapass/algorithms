using System;
using System.Collections.Generic;

namespace Graphs 
{
    public class Graph
    {
        private Dictionary<String, List<String>> adjacentNodesMap;
        private HashSet<String> reachableNodes;
        private Dictionary<String, String> routeMap;

        public Graph()
        {
            this.adjacentNodesMap = new Dictionary<string, List<string>>();
            this.reachableNodes = new HashSet<string>();
            this.routeMap = new Dictionary<string, string>();
        }

        public Graph AddEdge(string fromNode, string toNode)
        {
            if(!this.adjacentNodesMap.ContainsKey(fromNode))
            {
                this.adjacentNodesMap.Add(fromNode, new List<string>());
            }

            if(!this.adjacentNodesMap.ContainsKey(toNode))
            {
                this.adjacentNodesMap.Add(toNode, new List<string>());
            }

            this.adjacentNodesMap[fromNode].Add(toNode);

            return this;
        }

        public bool HasPath(string node, string toNode)
        {
            DepthFirstSearch(node);
            return reachableNodes.Contains(toNode);
        }

        public List<string> GetShortestPath(string fromNode, string toNode)
        {
            BreadthFirstSearch(fromNode);

            if(reachableNodes.Contains(toNode))
            {
                return GetPath(toNode);
            }

            return new List<string>();
        }

        private List<string> GetPath(string node)
        {
            var result = new List<string>();

            while(this.routeMap.ContainsKey(node))
            {
                result.Add(node);
                node = this.routeMap[node];
            }

            result.Add(node);
            result.Reverse();

            return result;
        }

        private void DepthFirstSearch(string node)
        {
            reachableNodes.Add(node);
            foreach(var adjacentNode in this.adjacentNodesMap[node])
            {
                if(!reachableNodes.Contains(adjacentNode))
                {
                    this.routeMap.Add(adjacentNode, node);
                    DepthFirstSearch(adjacentNode);
                }
            }
        }

        private void BreadthFirstSearch(string node)
        {
            foreach(var adjacentNode in this.adjacentNodesMap[node])
            {
                if(!reachableNodes.Contains(adjacentNode))
                {
                    reachableNodes.Add(adjacentNode);
                    this.routeMap.Add(adjacentNode, node);
                }
            }

            foreach(var adjacentNode in this.adjacentNodesMap[node])
            {
                BreadthFirstSearch(adjacentNode);
            }
        }
    }
}
