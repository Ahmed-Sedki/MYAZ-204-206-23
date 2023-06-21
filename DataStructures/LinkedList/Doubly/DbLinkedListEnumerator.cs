using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Doubly
{
    public class DbLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DbNode<T> Head { get; set; }
        private DbNode<T> Tail { get; set; }
        public DbNode<T> current { get; set; }

        public DbLinkedListEnumerator()
        {

        }

        public DbLinkedListEnumerator(DbNode<T> head, DbNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }
        public T Current => current.Value ?? default(T);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
            Tail = null;
        }

        public bool MoveNext()
        {
            if (Head is null)
                return false;

            if (current is null)
            {
                current = Head;
                return true;
            }

            if (current.Next is not null)
            {
                current = current.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Head = null;
            Tail = null;
            current = null;
        }
    }
}
