using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Singly
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        public SinglyLinkedListNode<T>? Head { get; set; }
        public SinglyLinkedListNode<T> _current { get; set; }

        public SinglyLinkedListEnumerator()
        {

        }

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
        }
        public T Current => _current.Value ?? default(T);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (Head is null)
                return false;

            if (_current is null)
            {
                _current = Head;
                return true;
            }

            if (_current.Next is not null)
            {
                _current = _current.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = null;
            Head = null;
        }
    }
}
