using System;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static void ChangeElementsInArray(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums), "Масив не може бути нульовим.");
            }
            int numberOfElements = nums.Length;

            for (int i = 0; i < numberOfElements / 2; i++)
            {
                if (nums[i] % 2 == 0
                && nums[numberOfElements - 1 - i] % 2 == 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[numberOfElements - i - 1];
                    nums[numberOfElements - 1 - i] = temp;
                }
            }
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int max = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] >= max)
                {
                    max = nums[i];
                }
            }

            int firstIndex = Array.IndexOf(nums, max);
            int lastIndex = Array.LastIndexOf(nums, max);

            return Math.Abs(lastIndex - firstIndex);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static void ChangeMatrixDiagonally(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
          

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j < i) 
                    {
                        matrix[i, j] = 0;
                    }
                    else if (j > i) 
                    {
                        matrix[i, j] = 1;
                    }
                    else 
                    {
                        matrix[i, j] = matrix[i, j];
                    }
                }
            }
        }
    }
}
