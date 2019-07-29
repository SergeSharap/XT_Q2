using System;
using System.Collections.Generic;
using System.Text;

namespace T4_4
{
    public static class NumberHelper
    {
        public static int GetSum(this IEnumerable<int> array)
        {
            int sum = 0;

            foreach (int element in array)
                sum += element;

            return sum;
        }

        public static float GetSum(this IEnumerable<float> array)
        {
            float sum = 0;

            foreach (float element in array)
                sum += element;

            return sum;
        }

        public static long GetSum(this IEnumerable<long> array)
        {
            long sum = 0;

            foreach (long element in array)
                sum += element;

            return sum;
        }

        public static double GetSum(this IEnumerable<double> array)
        {
            double sum = 0;

            foreach (double element in array)
                sum += element;

            return sum;
        }

        public static decimal GetSum(this IEnumerable<decimal> array)
        {
            decimal sum = 0;

            foreach (decimal element in array)
                sum += element;

            return sum;
        }

        public static short GetSum(this IEnumerable<short> array)
        {
            short sum = 0;

            foreach (short element in array)
                sum += element;

            return sum;
        }

        public static uint GetSum(this IEnumerable<uint> array)
        {
            uint sum = 0;

            foreach (uint element in array)
                sum += element;

            return sum;
        }

        public static ulong GetSum(this IEnumerable<ulong> array)
        {
            ulong sum = 0;

            foreach (ulong element in array)
                sum += element;

            return sum;
        }

        public static ushort GetSum(this IEnumerable<ushort> array)
        {
            ushort sum = 0;

            foreach (ushort element in array)
                sum += element;

            return sum;
        }

        public static sbyte GetSum(this IEnumerable<sbyte> array)
        {
            sbyte sum = 0;

            foreach (sbyte element in array)
                sum += element;

            return sum;
        }

        public static byte GetSum(this IEnumerable<byte> array)
        {
            byte sum = 0;

            foreach (byte element in array)
                sum += element;

            return sum;
        }

        public static char GetSum(this IEnumerable<char> array)
        {
            char sum = ' ';

            foreach (char element in array)
                sum += element;

            return sum;
        }
    }
}
