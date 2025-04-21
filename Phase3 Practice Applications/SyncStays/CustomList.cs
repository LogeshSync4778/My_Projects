using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

namespace SyncStays
{
    public class CustomList<Type> : IEnumerable, IEnumerator
    {
        /// <summary>
        /// private field used to auto increment Count that uniquely Identify as <see cref="Count"/> Class Instance
        /// </summary>
        private int _count;

        /// <summary>
        /// private field used to auto increment Capacity that uniquely Identify as <see cref="Capacity"/> Class Instance
        /// </summary>
        private int _capacity;

        /// <summary>
        /// public property uses _count to store Count of the array that uniquely Identify as <see cref="Count"/> Class Instance
        /// </summary>
        public int Count { get { return _count; } }

        /// <summary>
        /// public property uses _capacity to store capacity of the array that uniquely Identify as <see cref="Capacity"/> Class Instance
        /// </summary>
        public int Capacity { get { return _capacity; } }

        /// <summary>
        /// public property use to store list of elements 
        /// </summary>
        public Type[] _array;

        //Indexer used to return array element in given index
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        //Default COnstructor
        public CustomList()
        {
            _count = 0;
            _capacity = 5;
            _array = new Type[_capacity];
        }

        //Constructor used to create array with a given capacity
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        /// <summary>
        /// Method used to add new element into array
        /// </summary>
        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }

        //Method used to increase the capacity of the array
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