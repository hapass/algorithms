using System;
using Xunit;

namespace Graphs
{
    public class  GraphsTest
    {
        [Fact]
        public void GraphSaysNodesAreConnectedWhenTheyAreConnected()
        {
            var graph = new Graph();
            graph.AddEdge("1", "2");

            var hasPath = graph.HasPath("1", "2");

            Assert.True(hasPath);
        }
    }
}