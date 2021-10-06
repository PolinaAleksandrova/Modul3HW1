using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW1.Collection
{
    public class MyList<T> : IEnumerable<T>, IComparer
    {
        private int _count;
        private T[] _finalArray;

        public MyList()
        {
            _finalArray = new T[10];
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public T this[int index]// индексатор
        {
            get
            {
                return _finalArray[index];
            }
            set
            {
                _finalArray[index] = value;
            }
        }

        public void Add(T itemToAdd)
        {
            CreateExtraArray(1);
            _finalArray[_count] = itemToAdd;
            _count++;
        }

        public int CompareTo(MyList<T> other)
        {
            if (Count == other.Count)
            {
                return 0;
            }
            else if (Count < other.Count)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public T[] Sort()
        {
            for (var i = 0; i < _count; i++)
            {
                for (var j = i + 1; j < _count; j++)
                {
                    if (_finalArray[i] > _finalArray[j])
                    {


                    }
                }

            }
        }
        public void CreateExtraArray(int length)
        {
            if (_count + length < _finalArray.Length)
            {
                T[] temporaryArray = new T[_count * 2];
                for (int i = 0; i < _count; i++)
                {
                    temporaryArray[i] = _finalArray[i];
                }

                _finalArray = temporaryArray;

                if (_count + length < _finalArray.Length)
                {
                    CreateExtraArray(length);
                }
            }
        }

        public bool Remove(T item)
        {
            var isExist = false;
            for (int i = 0; i < _count - 1; i++)
            {
                if (_finalArray[i].Equals(item))
                {
                    isExist = true;
                }

                if (isExist)
                {
                    _finalArray[i] = _finalArray[i + 1];
                }
            }

            if (isExist)
            {
                _finalArray[_count--] = default(T);
            }

            return isExist;
        }

        public void AddRange(T[] addArray)
        {
            CreateExtraArray(addArray.Length);
            for (int i = _count; i < _count + addArray.Length; i++)
            {
                _finalArray[i] = addArray[i - _count];
            }

            _count += addArray.Length;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < _count; i++)
            {
                _finalArray[i - 1] = _finalArray[i];
            }

            _finalArray[--_count] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
           for (int i = 0; i < _count; i++)
           {
                yield return _finalArray[i];
           }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _finalArray.GetEnumerator();
        }
    }
}
