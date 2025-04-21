using System;
using System.Collections;

namespace MyList
{
    public  class CustomVaccinationList<Type> : IEnumerable, IEnumerator
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }
        private Type[] _array;

        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public CustomVaccinationList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }

        public CustomVaccinationList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }

        void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

               int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (position < _count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current { get { return _array[position]; } }
    }
}