using System;
using System.Collections.Generic;
using Xunit;

namespace Graphs
{
    public class GraphsTest
    {
        [Fact]
        public void GraphSaysThereIsAPathFromNodeToNodeWhenThereIsAPath()
        {
            var graph = new Graph().AddEdge("1", "2");

            var hasPath = graph.HasPath("1", "2");

            Assert.True(hasPath);
        }

        [Fact]
        public void GraphSaysThereIsNoPathFromNodeToNodeWhenThereIsNoPath()
        {
            var graph = new Graph().AddEdge("1", "2");

            var hasPath = graph.HasPath("2", "1");

            Assert.False(hasPath);
        }

        [Fact]
        public void GraphReturnsShortestPathFromNodeToNodeCorrectly()
        {
            var graph = new Graph()
                .AddEdge("1", "2")
                .AddEdge("2", "3")
                .AddEdge("1", "3");

            var shortestPath = graph.GetShortestPath("1", "3");

            Assert.Equal(new List<string> {"1", "3"}, shortestPath);
        }
    }
}