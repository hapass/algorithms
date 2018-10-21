using System;
using Xunit;

namespace Graphs
{
    public class  GraphsTest
    {
        [Fact]
        public void GraphSaysThereIsAPathFromNodeToNodeWhenThereIsAPath()
        {
            var graph = new Graph();
            graph.AddEdge("1", "2");

            var hasPath = graph.HasPath("1", "2");

            Assert.True(hasPath);
        }

        [Fact]
        public void GraphSaysThereIsNoPathFromNodeToNodeWhenThereIsNoPath()
        {
            var graph = new Graph();
            graph.AddEdge("1", "2");

            var hasPath = graph.HasPath("2", "1");

            Assert.False(hasPath);
        }
    }
}