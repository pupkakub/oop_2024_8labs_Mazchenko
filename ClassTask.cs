using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Class
{
    public class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
        {
            sideA = a;
            sideB = b;
        }
        public Rectangle(double a)
        {
            sideA = a;
            sideB = 5;
        }
        public Rectangle()
        {
            sideA = 4;
            sideB = 3;
        }

        public double GetSideA()
        {
            return sideA;
        }

        public double GetSideB()
        {
            return sideB;
        }
        public double Area()
        {
            return sideA * sideB;
        }
        public double Perimeter()
        {
            return (sideA * 2) + (sideB * 2);
        }
        public bool IsSquare()
        {
            if (sideA == sideB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ReplaceSides()
        {
            double temp = sideA;
            sideA = sideB;
            sideB = temp;
        }
    }
    public class ArrayRectangles
    {
        private Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
        {
            rectangle_array = new Rectangle[n];
        }

        public bool AddRectangle(Rectangle rect)
        {
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] == null)
                {
                    rectangle_array[i] = rect;
                    return true; 
                }
            }

            return false;
        }
        public int NumberMaxArea()
        {
            if (rectangle_array.Length == 0)
            {
                return -1; 
            }

            double maxArea = double.MinValue;
            int maxIndex = -1; 

            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null) 
                {
                    double area = rectangle_array[i].Area();
                    if (area > maxArea)
                    {
                        maxArea = area;
                        maxIndex = i;
                    }
                }
            }

            return maxIndex;
        }
        public int NumberMinPerimeter()
        {
            if (rectangle_array.Length == 0)
            {
                return -1; 
            }

            double minPerimeter = double.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null) 
                {
                    double perimeter = rectangle_array[i].Perimeter();
                    if (perimeter < minPerimeter)
                    {
                        minPerimeter = perimeter;
                        minIndex = i;
                    }
                }
            }

            return minIndex;
        }

        public int NumberSquare()
        {
            int count = 0;

            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].IsSquare())
                {
                    count++;
                }
            }

            return count;
        }
    }
}
