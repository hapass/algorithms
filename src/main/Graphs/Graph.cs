using System;
using System.Collections.Generic;

namespace Graphs 
{
    public class Graph
    {
        private Dictionary<String, List<String>> adjacentNodesMap;
        private HashSet<String> reachableNodes;

        public Graph()
        {
            this.adjacentNodesMap = new Dictionary<string, List<string>>();
            this.reachableNodes = new HashSet<string>();
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

        private void DepthFirstSearch(string node)
        {
            var adjacentNodes = this.adjacentNodesMap[node];
            foreach(var adjacentNode in adjacentNodes)
            {
                if(!reachableNodes.Contains(adjacentNode))
                {
                    reachableNodes.Add(adjacentNode);
                    DepthFirstSearch(adjacentNode);
                }
            }
        }
    }
}
