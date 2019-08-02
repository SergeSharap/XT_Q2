using System;

namespace _2._4
{
    public class MyString
    {
        private readonly char[] myString;
        public int Length => myString.Length;

        public MyString(char[] str)
        {
            if (str is null)
                throw new NullReferenceException("Char[] cannot be null");

            myString = new char[str.Length];
            str.CopyTo(myString, 0);
        }
        public MyString(string str)
        {
            if (str is null)
                throw new NullReferenceException("String cannot be null");

            myString = new char[str.Length];
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
            if (s1 is null && s2 is null)
                return null;
            else if (s1 is null)
                return s2;
            else if (s2 is null)
                return s1;
            
            int length = s1.Length + s2.Length;

            char[] newMyString = new char[length];
            s1.myString.CopyTo(newMyString, 0);
            s2.myString.CopyTo(newMyString, s1.Length);

            return new MyString(newMyString);
        }
        public static bool operator ==(MyString s1, MyString s2)
        {
            if (s1 is null || s2 is null)
                return false;
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
            if (obj is MyString myS)
                return myS == this;
            else
                return false;
        }
        public override string ToString()
        {
            return (string) this;
        }
        public static explicit operator MyString(string s)
        {
            return new MyString(s);
        }
        public static explicit operator String(MyString s)
        {
            return s is null ? null : new string(s.myString);
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
            MyString myNewString = new MyString(myString);
            for (int i = 0; i < myString.Length; i++)
                if (myNewString[i] == oldCh)
                    myNewString[i] = newCh;

            return myNewString;
        }
        public MyString Remove(int startIndex, int count)
        {
            if (startIndex < 0 || count < 0 || startIndex + count > Length)
                throw new ArgumentException("startIndex must be positive or zero and sum of startIndex and count must be greater than length of MyString");

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
            return Remove(startIndex, Length - startIndex);
        }
        public char[] ToCharArray()
        {
            return myString;
        }
    }
}
