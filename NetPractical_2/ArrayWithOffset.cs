using System;
using System.Collections;
using System.Collections.Generic;


namespace NetPractical_2
{
    class ArrayWithOffset<T>:IEnumerable<T>
    {
        T[] _array;
        int _startIndex;
        int _endIndex;

        public int GetStartIndex
        {
            get
            {
                return _startIndex;
            }
        }
        public int GetEndIndex
        {
            get
            {
                return _endIndex;
            }
        }

        public ArrayWithOffset(int _startIndex, int _endIndex)
        {
            int _tempLength = _endIndex - _startIndex;
            if (_tempLength < 0)
            {
                throw new ArgumentOutOfRangeException("End index cant be less than start index");
            } else
            {
                this._startIndex = _startIndex;
                this._endIndex = _endIndex;
            }
            _tempLength++;
            
            _array = new T[_tempLength];            
        }
        public T this[int index]
        {
            get
            {
                int _tempCurrent = index - _startIndex;
                if (_tempCurrent < 0)
                {
                    throw new ArgumentOutOfRangeException("index less than start index");
                }
                if (index > _endIndex)
                {
                    throw new ArgumentOutOfRangeException("index more than end index");
                }
               return _array[_tempCurrent];
            }
            set
            {
                int _tempCurrent = index - _startIndex;
                if (_tempCurrent < 0)
                {
                    throw new ArgumentOutOfRangeException("index less than start index");
                }
                if (index > _endIndex)
                {
                    throw new ArgumentOutOfRangeException("index more than end index");
                }
                _array[index - _startIndex] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }
    }
}
