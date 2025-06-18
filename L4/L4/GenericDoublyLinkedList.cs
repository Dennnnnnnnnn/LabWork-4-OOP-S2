//GenericDoublyLinkedList.cs
using System;
using System.Collections;
using System.Collections.Generic;

namespace L4
{
    /// <summary>
    /// A generic, doubly-linked list implementation.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in 
    /// the list. Must implement IComparable and IEquatable.</typeparam>
    public sealed class GenericDoublyLinkedList<T> : IEnumerable<T> 
        where T : IComparable<T>, IEquatable<T>
    {
        private MyNode<T> head;  // First node in the list
        private MyNode<T> tail;  // Last node in the list
        private MyNode<T> iP;    // Iterator pointer for custom iteration

        /// <summary>
        /// Represents a node in the doubly linked list.
        /// </summary>
        private sealed class MyNode<TNode> 
            where TNode : IEquatable<TNode>, IComparable<TNode>
        {
            public TNode Data { get; set; }
            public MyNode<TNode> Next { get; set; }
            public MyNode<TNode> Previous { get; set; }

            public MyNode(TNode data, MyNode<TNode> previous, 
                MyNode<TNode> next)
            {
                Data = data;
                Previous = previous;
                Next = next;
            }
        }

        /// <summary>
        /// Resets the internal pointer to the beginning of the list.
        /// </summary>
        public void Start()
        {
            iP = head;
        }

        /// <summary>
        /// Moves the internal pointer to the next node.
        /// </summary>
        public void Next()
        {
            iP = iP?.Next;
        }

        /// <summary>
        /// Checks whether the internal pointer points to a valid node.
        /// </summary>
        /// <returns>True if the internal pointer is not null.</returns>
        public bool Exists()
        {
            return iP != null;
        }

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        public int Count
        {
            get
            {
                int k = 0;
                for (MyNode<T> node = head; node != null; node = node.Next)
                    k++;
                return k;
            }
        }

        /// <summary>
        /// Adds an element to the front of the list.
        /// </summary>
        public void AddToFront(T element)
        {
            MyNode<T> newNode = new MyNode<T>(element, null, head);
            if (head != null)
            {
                head.Previous = newNode;
            }
            else
            {
                tail = newNode;
            }
            head = newNode;
        }

        /// <summary>
        /// Adds an element to the end of the list.
        /// </summary>
        public void AddToEnd(T element)
        {
            MyNode<T> newNode = new MyNode<T>(element, tail, null);
            if (tail != null)
            {
                tail.Next = newNode;
            }
            else
            {
                head = newNode;
            }
            tail = newNode;
        }

        /// <summary>
        /// Checks if the list contains a specific element.
        /// </summary>
        /// <param name="element">The element to find.</param>
        /// <returns>True if the element exists in the list.</returns>
        public bool Contains(IComparable<T> element)
        {
            for (MyNode<T> node = head; node != null; node = node.Next)
            {
                if (node.Data.Equals(element))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through
        /// the list from head to tail.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (MyNode<T> node = head; node != null; node = node.Next)
            {
                yield return node.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Enumerates the list in reverse order (tail to head).
        /// </summary>
        public IEnumerable<T> Reverse()
        {
            for (MyNode<T> node = tail; node != null; node = node.Previous)
            {
                yield return node.Data;
            }
        }

        /// <summary>
        /// Sorts the list using a selection sort algorithm.
        /// </summary>
        public void Sort()
        {
            for (MyNode<T> current = head; current != null;
                current = current.Next)
            {
                MyNode<T> min = current;
                for (MyNode<T> check = current; check != null; 
                    check = check.Next)
                {
                    if (check.Data.CompareTo(min.Data) < 0)
                    {
                        min = check;
                    }
                }
                
                T temp = current.Data;
                current.Data = min.Data;
                min.Data = temp;
            }
        }
    }
}
