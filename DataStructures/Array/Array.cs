
using System.Collections.Generic;
using System.Linq;

namespace Array
{
    public class Array<T> : IEnumerable<T>
    {
        private T[] _innerArray;
        private int _index = 0;

        public int Count => _index;
        public int Capacity => _innerArray.Length;

        public Array()
        {
            _innerArray = new T[4];
        }

        public Array(params T[] init)
        {
            var newArray = new T[init.Length];
            Array.Copy(init, newArray, init.Length);
            _innerArray = newArray;
            _index = init.Length;
        }

        private void DoubleArray()
        {
            var newArray = new T[_innerArray.Length * 2];
            Array.Copy(_innerArray, newArray, _innerArray.Length);
            _innerArray = newArray;
        }

        public void Add(T item)
        {
            if (_index == _innerArray.Length)
            {
                DoubleArray();
            }

            _innerArray[_index] = item;
            _index++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public T GetItem(int position)
        {
            if (position < 0 || position >= _innerArray.Length)
                throw new IndexOutOfRangeException();

            return _innerArray[position];
        }

        public void SetItem(int position, T item)
        {
            if (position < 0 || position >= _innerArray.Length)
                throw new IndexOutOfRangeException();

            _innerArray[position] = item;
        }

        private void Swap(int p1, int p2)
        {
            var temp = _innerArray[p1];
            _innerArray[p1] = _innerArray[p2];
            _innerArray[p2] = temp;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (_innerArray[i].Equals(item))
                {
                    _innerArray[i] = default;
                    for (int j = i; j < _innerArray.Length - 1; j++)
                    {
                        Swap(j, j + 1);
                    }

                    _index--;
                    if (_index == _innerArray.Length / 2)
                        HalfList();

                    return true;
                }
            }

            return false;
        }

        private void HalfList()
        {
            var newList = new T[_innerArray.Length / 2];
            Array.Copy(_innerArray, newList, newList.Length);
            _innerArray = newList;
        }

        public T RemoveItem(int position)
        {
            var item = GetItem(position);
            SetItem(position, default);

            for (int i = position; i < Count - 1; i++)
            {
                Swap(i, i + 1);
            }

            _index--;

            if (_index == _innerArray.Length / 2)
            {
                var newArray = new T[_innerArray.Length / 2];
                Array.Copy(_innerArray, newArray, newArray.Length);
                _innerArray = newArray;
            }

            return item;
        }

        public int Find(T item)
        {
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (item.Equals(_innerArray[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public T[] Copy(int v1, int v2)
        {
            var newArray = new T[v2 - v1];
            int j = 0;

            for (int i = v1; i < v2; i++)
            {
                newArray[j] = GetItem(i);
                j++;
            }

            return newArray;
        }

        public T[] Intersect(IEnumerable<T> collection)
        {
            T[] newList = new T[_innerArray.Length];
            int i = 0;

            foreach (T item in _innerArray.Intersect(collection).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }

        public T[] Union(IEnumerable<T> collection)
        {
            T[] newList = new T[_innerArray.Length + collection.Count()];
            int i = 0;

            foreach (T item in _innerArray.Union(collection).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }

        public T[] Except(IEnumerable<T> collection)
        {
            T[] newList = new T[_innerArray.Length];
            int i = 0;

            foreach (T item in _innerArray.Except(collection).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _innerArray.Take(_index).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
