using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    public class MyList<T> : IList<T>
    {
        private int _size;
        private T[] _items;

        public T this[int index]
        {
            get { 
                return _items[index]; 
            }
            set 
            {
                _items[index] = value;
            }
        }

        static T[] _emptyArray = new T[2];

        // Capacity 
        public int Capacity
        {
            get { return _items.Length; }
            set
            {
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    if(_size > 0)
                    {
                        //copy array
                        Array.Copy(_items, 0, newItems, 0, _size);
                    }
                } 
                else
                {
                    _items = _emptyArray;
                }
            }
        }

        private void RiseCapacity(int minLength)
        {
            if (_items.Length < minLength)
            {
                Capacity = _items.Length * 2;
            }
        }

        // Construct
        public MyList()
        {
            _items = _emptyArray;
        }

        // Construct
        public MyList(int capacity)
        {
            if(capacity < 0)
            {
                // throw error                
            }

            if(capacity == 0)
            {
                _items = _emptyArray;
               
            } else if (capacity > 0)
            {
                _items = new T[capacity];
               
            }
        }

        // how many elements are in the list
        public int Count 
        {
            get { return _size; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        // Add
        public void Add(T item)
        {
            if(_size == _items.Length)
            {
                RiseCapacity(_size + 1);
            }
            _items[_size++] = item;
        }

        // Remove
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if(index > 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }


        //RemoveAt
        public void RemoveAt(int index)
        {
            for (int a = index; a < _items.Length - 1; a++)
            {
                // moving elements downwards, to fill the gap at [index]
                _items[a] = _items[a + 1];
            }
            //  let's decrement Array's size by one
            Array.Resize(ref _items, _items.Length - 1);
        }


        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                yield return this._items[i];
            }
        }

        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }


    }
}
