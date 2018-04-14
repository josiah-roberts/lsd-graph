using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LSD
{
    class HashGraph<TNode, TEdge> : Graph<TNode, TEdge>
    {
        private Dictionary<TNode, HashNode> nodes;
        private Dictionary<int, HashEdge> edges;

        public HashGraph(IEnumerable<TNode> nodeValues) : base(nodeValues)
        {
            nodes = nodeValues.ToDictionary(x => x, x => new HashNode());
        }

        public override Node<TNode, TEdge> this[TNode key] => nodes[key];

        public override Edge<TEdge, TNode> this[TNode a, TNode b] => nodes[a].;

        public override IEnumerable<Node<TNode, TEdge>> Nodes => throw new NotImplementedException();

        private class HashNode : Node<TNode, TEdge>
        {
            public override IEnumerable<Node<TNode, TEdge>> Neighbors => throw new NotImplementedException();

            public override Edge<TEdge, TNode> Connect(TNode key)
            {
                throw new NotImplementedException();
            }
        }

        private class HashEdge : Edge<TEdge, TNode>
        {
            public override IEnumerable<Node<TNode, TEdge>> Nodes => throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int CombineHashCodes(TNode a, TNode b)
        {
            unchecked
            {
                return a.GetHashCode() ^ b.GetHashCode();
            }
        }
    }
}
