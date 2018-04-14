using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSD
{
    class ArrayGraph<TEdge> : Graph<int, TEdge>
    {
        private MatrixArray<IArrayEntity> edgeMatrix;

        public ArrayGraph(IEnumerable<int> nodeValues) : base(nodeValues)
        {
            var iterated = nodeValues.ToArray();
            edgeMatrix = new MatrixArray<IArrayEntity>(iterated.Max() + 2);

            foreach (var index in iterated)
            {
                var node = new ArrayNode(this);
                edgeMatrix[index, index] = node;
                node.Value = index;
                _Nodes.Add(node);
            }
        }

        public override Node<int, TEdge> this[int key] => (ArrayNode)edgeMatrix[key, key];

        public override Edge<TEdge, int> this[int a, int b] => (ArrayEdge)edgeMatrix[a, b];

        private List<ArrayNode> _Nodes = new List<ArrayNode>();
        public override IEnumerable<Node<int, TEdge>> Nodes => _Nodes;

        class ArrayNode : Node<int, TEdge>, IArrayEntity
        {
            private MatrixArray<IArrayEntity> matrix;
            private ArrayGraph<TEdge> graph;
            public ArrayNode(ArrayGraph<TEdge> graph)
            {
                this.graph = graph;
                matrix = graph.edgeMatrix;
            }

            public override IEnumerable<Node<int, TEdge>> Neighbors
            {
                get
                {
                    for (int i = 0; i < Value; i++)
                    {
                        var item = matrix[Value, i];
                        if (item != null)
                            yield return (ArrayNode)matrix[i, i];
                    }

                    for (int i = Value + 1; i < matrix.Size - 1; i++)
                    {
                        var item = matrix[Value, i];
                        if (item != null)
                            yield return (ArrayNode)matrix[i, i];
                    }
                }
            }

            public override Edge<TEdge, int> Connect(int key) =>
                (Edge<TEdge, int>)(matrix[key, Value] = new ArrayEdge(graph, this, key));
        }

        private class ArrayEdge : Edge<TEdge, int>, IArrayEntity
        {         
            private ArrayGraph<TEdge> graph;
            public ArrayEdge(ArrayGraph<TEdge> graph, ArrayNode node, int target)
            {
                this.graph = graph;
                nodes[0] = node;
                nodes[1] = (ArrayNode)graph[target];
            }

            private ArrayNode[] nodes = new ArrayNode[2];
            public override IEnumerable<Node<int, TEdge>> Nodes => nodes;
        }

        interface IArrayEntity { }
    }
}
