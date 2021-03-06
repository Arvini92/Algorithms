﻿namespace Queue.Array
{
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        T[] _items = new T[0];

        int _size = 0;

        int _head = 0;

        int _tail = -1;

        public void Enqueue(T item)
        {
            if(_size == _items.Length)
            {
                int newLenght = (_size == 0) ? 4 : _size * 2;

                T[] newArray = new T[newLenght];

                if(_size > 0)
                {
                    int targetIndex = 0;

                    if(_tail < _head)
                    {
                        for(int index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }

                        for (int index = 0; index < _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for (int index = _head; index < _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }

                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = - 1;
                }

                _items = newArray;

            }

            if (_tail == _items.Length -1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new System.InvalidOperationException("The stack is empty");
            }

            T value = _items[_head];

            if(_head == _items.Length-1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;

            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new System.InvalidOperationException("The stack is empty");
            }

            return _items[_head];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if(_tail < _head)
                {
                    for(int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }

                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    for (int index = _head; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

