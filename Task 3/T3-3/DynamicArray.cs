using System;
using System.Collections;
using System.Collections.Generic;


namespace T3_3
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {

        #region Fields

        private T[] _array;

        #endregion

        #region Constructors
        public DynamicArray() : this(8) { }

        public DynamicArray(int amount)
        {
            _array = new T[amount];
            Length = 0;
        }

        public DynamicArray(IEnumerable<T> inArray) : this(8)
        {
            this.AddRange(inArray);
        }

        #endregion

        #region Index

        public T this[int index]
        {
            get
            {
                if (index >= Length)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be less than length");

                if (index < 0)
                    return _array[index + Length];

                return _array[index];
            }
            set
            {
                if (index >= Length)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be less than length");

                if (index < 0)
                    _array[index + Length] = value;

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
            if (Length >= Capacity)
                throw new InvalidOperationException("The Array have not got a free space for a new element");
            
            _array[index] = newElement;
            Length++;
        }

        public void AddRange(IEnumerable<T> addArray)
        {
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

            for (int i = index + 1; i < Length; i++)
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
                if (key.Equals(_array[i]))
                    index = i;
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

            for (int i = index; i < Length; i++)
                _array[i] = _array[i + 1];

            _array[Length - 1] = default;
            Length--;
        }

        public void SetCapacity(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Capacity cannot be negative");

            T[] tempArray = new T[Length];
            _array.CopyTo(tempArray, 0);
            _array = new T[amount * 2];

            for (int i = 0; i < _array.Length || i < tempArray.Length; i++)
                _array[i] = tempArray[i];

            Length = amount;
        }

        public object Clone()
        {
            return new DynamicArray<T>(this);
        }

        public T[] ToArray()
        {
            return _array;
        }

        #endregion

    }
}
