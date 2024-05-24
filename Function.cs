using System;

namespace Functions
{
    public enum SortOrder { Ascending, Descending }
    public static class DemoFunction
    {
        public static bool IsSorted(int[] array, SortOrder order)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            int length = array.Length;

            if (length == 0
               || length == 1)
            {
                return true;
            }
            if (order != SortOrder.Ascending
                && order != SortOrder.Descending)
            {
                throw new ArgumentException("Invalid SortOrder value.", nameof(order));
            }

            bool isAscending = order == SortOrder.Ascending;

            for (int i = 0; i < length - 1; i++)
            {
                int current = array[i];
                int next = array[i + 1];

                if (isAscending)
                {
                    if (current > next)
                    {
                        return false;
                    }
                }
                else
                {
                    if (current < next)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static void Transform(int[] array, SortOrder order)
        {
            if (array == null
               || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null or empty.");
            }
            if (order != SortOrder.Ascending
                && order != SortOrder.Descending)
            {
                throw new ArgumentException("Invalid SortOrder value.", nameof(order));
            }

            if (IsSorted(array, order))
            {

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i] + i;
                }
            }
        }
        public static double MultArithmeticElements(double a, double t, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n should be greater than 0.", nameof(n));
            }

            if (t == 0)
            {
                return a;
            }
            if (a == 0)
            {
                return 0;
            }
            double multiplication = a;

            for (int i = 1; i < n; i++)
            {
                double currentElement = a + (i * t);
                multiplication *= currentElement;
            }

            return multiplication;
        }
        public static double SumGeometricElements(double a, double t, double alim)
        {
            double sum = a;
            double currentElement = a;

            if (a <= 0)
            {
                return 0.0d;
            }

            if (t <= 0 || t >= 1)
            {
                throw new ArgumentException("t should be in range 0 < t < 1.", nameof(t));
            }

            while (currentElement * t > alim)
            {
                currentElement *= t;
                sum += currentElement;
            }


            return sum;
        }
    }
}
