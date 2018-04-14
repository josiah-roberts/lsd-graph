using System;
using System.Collections.Generic;
using System.Text;

namespace LSD
{
    abstract class Graph<TNode, TEdge>
    {
        public Graph(IEnumerable<TNode> nodeValues)
        {

        }

        public abstract IEnumerable<Node<TNode, TEdge>> Nodes { get; }

        public abstract Node<TNode, TEdge> this[TNode key] { get; }
        public abstract Edge<TEdge, TNode> this[TNode a, TNode b] { get; }
    }

    public abstract class Node<T, TEdge>
    {
        public abstract IEnumerable<Node<T, TEdge>> Neighbors { get; }
        public abstract Edge<TEdge, T> Connect(T key);
        public T Value { get; set; }
    }

    public abstract class Edge<T, TNode>
    {
        public abstract IEnumerable<Node<TNode, T>> Nodes { get; }
        public T Value {get;set;}
    }
}
