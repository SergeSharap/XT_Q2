using System;
using System.Collections;
using System.Collections.Generic;


namespace T3_3_4
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {

        #region Fields

        protected T[] _array;

        #endregion

        #region Constructors
        public DynamicArray() : this(8) { }

        public DynamicArray(IEnumerable<T> inArray) : this(8)
        {
            AddRange(inArray);
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "capacity cannot be negative");

            _array = new T[capacity];
            Length = 0;
        }

        #endregion

        #region Index

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    index += Length;

                if (index >= Length || index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), "Incorrect index");

                return _array[index];
            }
            set
            {
                if (index < 0)
                    index += Length;

                if (index >= Length || index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), "Incorrect index");

                _array[index] = value;
            }
        }

        #endregion

        #region Properties

        public int Length { get; private set; }
        public int Capacity => _array.Length;

        #endregion

        #region Methods

        public void Add(T newElement)
        {
            if (IsExtendNeeded(1))
                Extend(1);

            AddElement(newElement, Length);
        }

        private void AddElement(T newElement, int index)
        {
            _array[index] = newElement;
            Length++;
        }

        public void AddRange(IEnumerable<T> addArray)
        {
            if (addArray is null)
                throw new ArgumentException("Array cannot be null");

            int amount = 0;
            foreach (T element in addArray)
                amount++;

            if (IsExtendNeeded(amount))
                Extend(amount);

            foreach (T element in addArray)
                AddElement(element, Length);
        }

        public bool Insert(T newElement, int index)
        {
            if (newElement == null)
                return false;

            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index), "index cannot be negative or more than Length - 1");

            if (IsExtendNeeded(1))
                Extend(1);

            for (int i = Length; i > index; i--)
                _array[i] = _array[i - 1];
            AddElement(newElement, index);

            return true;
        }

        private bool IsExtendNeeded(int addLength)
        {
            return Length + addLength >= Capacity;
        }

        private void Extend(int addLength)
        {
            int newCapacity = (Length + addLength) * 2;

            T[] tempArray = new T[newCapacity];
            _array.CopyTo(tempArray, 0);

            _array = new T[newCapacity];
            tempArray.CopyTo(_array, 0);
        }

        public bool Remove(T key)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].Equals(key))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index), "index cannot be negative or more than Length - 1");

            for (int i = index; i < Length - 1; i++)
                _array[i] = _array[i + 1];

            _array[Length - 1] = default;
            Length--;
        }

        public void SetCapacity(int newCapacity)
        {
            if (newCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(newCapacity), "Capacity cannot be negative");

            T[] tempArray = new T[Capacity];
            _array.CopyTo(tempArray, 0);
            _array = new T[newCapacity];

            for (int i = 0; i < _array.Length && i < tempArray.Length; i++)
                _array[i] = tempArray[i];

            if (newCapacity < Length)
                Length = newCapacity;
        }

        public object Clone()
        {
            return new DynamicArray<T>(this);
        }

        public T[] ToArray()
        {
            T[] tempArray = new T[Length];

            for (int i = 0; i < Length; i++)
                tempArray[i] = _array[i];

            return tempArray;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return _array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
    

}
