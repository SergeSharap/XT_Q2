using System;
using System.Collections.Generic;
using System.Text;

namespace T3_3_4
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        #region Constructors
        public CycledDynamicArray() : base(8) { }

        public CycledDynamicArray(int amount) : base(amount) { }

        public CycledDynamicArray(IEnumerable<T> inArray) : base(inArray) { }


        #endregion
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];

                if (i == Length - 1)
                    i = -1;
            }
        }
    }
}
