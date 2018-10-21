using System;
using System.Collections.Generic;

namespace Graphs 
{
    public class Graph
    {
        private Dictionary<String, List<String>> nodeConnections;

        public Graph()
        {
            this.nodeConnections = new Dictionary<string, List<string>>();
        }

        public Graph AddEdge(string fromNode, string toNode)
        {
            if(!this.nodeConnections.ContainsKey(fromNode))
            {
                this.nodeConnections.Add(fromNode, new List<string>());
            }

            this.nodeConnections[fromNode].Add(toNode);

            return this;
        }

        public bool HasPath(string node, string toNode)
        {
            return true;
        }
    }
}
