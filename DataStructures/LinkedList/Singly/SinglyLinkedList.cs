using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Singly
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private int _count = 0;
        public SinglyLinkedListNode<T>? Head { get; set; }
        public int Count => _count;

        public SinglyLinkedList()
        {
            Head = null;
        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public void AddFirst(T item)
        {
            var node = new SinglyLinkedListNode<T>()
            {
                Value = item
            };

            if (Head is null)
            {
                Head = node;
                _count++;
                return;
            }

            node.Next = Head;
            Head = node;
            _count++;
            return;
        }
        public void AddLast(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);

            if (Head is null)
            {
                Head = node;
                _count++;
                return;
            }

            var current = Head;
            var prev = current;
            while (current != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = node;
            _count++;
            return;
        }
        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(item);

            var current = Head;
            var prev = current;

            while (current is not null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    _count++;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }
        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            SinglyLinkedListNode<T> new_node = new SinglyLinkedListNode<T>(item);

            if (Head is null)
            {
                AddFirst(item);
            }

            var current = Head;
            while (current is not null)
            {
                if (current.Equals(node))
                {
                    new_node.Next = current.Next;
                    current.Next = new_node;
                    _count++;
                    return;
                }

                current = current.Next;
            }

            throw new Exception("The node could not be found in the linked list.");
        }
        public T RemoveFirst()
        {
            if (Head is null)
            {
                throw new Exception("Linked list is empty!");
            }

            T item = Head.Value;
            Head = Head.Next;
            _count--;
            return item;
        }
        public T RemoveLast()
        {
            if (Head is null)
            {
                throw new Exception("Linked list is empty!");
            }

            var current = Head;
            if (current.Next is null)
            {
                T item = current.Value;
                Head = null;
                _count--;
                return item;
            }

            while (current is not null)
            {
                if (current.Next.Next is null)
                {
                    T item = current.Next.Value;
                    current.Next = null;
                    _count--;
                    return item;
                }

                current = current.Next;
            }

            throw new Exception();
        }
        public T Remove(SinglyLinkedListNode<T> node)
        {
            if (Head is null)
                throw new Exception("The linked list is empty!");

            if (Head.Value.Equals(node.Value))
                return RemoveFirst();

            var current = Head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(node.Value))
                {
                    T item = node.Value;
                    current.Next = current.Next.Next;
                    _count--;
                    return item;
                }
                current = current.Next;
            }
            throw new Exception("Node not found!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
