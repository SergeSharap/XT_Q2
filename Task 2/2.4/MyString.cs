using System;

namespace Task2
{
    class MyString
    {
        private char[] myString; 
        public int Length { get; }

        public MyString(char[] str)
        {
            this.Length = str.Length;
            myString = new char[Length];
            str.CopyTo(myString, 0);
        }
        public MyString(string str)
        {
            this.Length = str.Length;
            myString = new char[Length];
            str.CopyTo(0, myString, 0, Length);
        }

        public char this[int index]
        {
            get
            {
                if (index < Length || index >= 0)
                    return myString[index];
                else
                    throw new ArgumentException("Index must be positive and less than length");
            }
            set
            {
                if (index < Length || index >= 0)
                    myString[index] = value;
                else
                    throw new ArgumentException("Index must be positive and less than length");
            }
        }

        public static MyString operator +(MyString s1, MyString s2)
        {
            int length = s1.Length + s2.Length;

            char[] newMyString = new char[length];
            s1.myString.CopyTo(newMyString, 0);
            s2.myString.CopyTo(newMyString, s1.Length);

            return new MyString(newMyString);
        }
        public static bool operator ==(MyString s1, MyString s2)
        {
            if (s1.Length != s2.Length)
                return false;
            else
            {
                for (int i = 0; i < s1.Length; i++)
                    if (s1[i] != s2[i])
                        return false;
            }
            return true;
        }
        public static bool operator !=(MyString s1, MyString s2)
        {
            return !(s1 == s2);
        }
        public override bool Equals(object obj)
        {
            if (obj is MyString)
                return (MyString)obj == this;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "MyString";
        }
        public static implicit operator MyString(string s)
        {
            return new MyString(s);
        }
        public static implicit operator String(MyString s)
        {
            return new string(s.myString);
        }
        public int IndexOf(char symb)
        {
            for (int i = 0; i < myString.Length; i++)
                if (symb == myString[i])
                    return i;

            return -1;
        }
        public MyString Replace(char oldCh, char newCh)
        {
            MyString myNewString = new MyString(this.myString);
            for (int i = 0; i < myString.Length; i++)
                if (myNewString[i] == oldCh)
                    myNewString[i] = newCh;

            return myNewString;
        }
        public MyString Remove(int startIndex, int count)
        {
            if (startIndex < 0 || count < 0 || startIndex + count > Length)
                throw new ArgumentException("startIndex must be positive or zero and sum of startIndex and count must be greater or equal length of MyString");

            char[] myNewString = new char[Length - count];
            int newIndex = 0;

            for (int i = 0; i < startIndex; i++, newIndex++)
                myNewString[newIndex] = myString[i];

            for (int i = startIndex + count; i < myString.Length; i++, newIndex++)
                myNewString[newIndex] = myString[i];

            return new MyString(myNewString);
        }
        public MyString Remove(int startIndex)
        {
            return Remove(startIndex, this.Length - startIndex);
        }
        public char[] ToCharArray()
        {
            return myString;
        }
    }
}
