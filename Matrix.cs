using System;

namespace MatrixLibrary
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }
    }

    public class Matrix : ICloneable
    {
        /// <summary>
        /// Number of rows.
        /// </summary>


        public int Rows { get; private set; }

        /// <summary>
        /// Number of columns.
        /// </summary>
        /// 
        public int Columns { get; private set; }

        /// <summary>
        /// Gets an array of floating-point values that represents the elements of this Matrix.
        /// </summary>

        private double[,] elements;
        public double[,] Array
        {
            get { return elements; }
            set
            { 
                foreach (var element in value)
                {
                    if (!double.TryParse(element.ToString(), out _))
                    {
                        throw new MatrixException("Elements' type must be double.");
                    }
                    if (element > double.MaxValue || element < double.MinValue)
                    {
                        throw new MatrixException("The range of double type was exceed.");
                    }
                }

                elements = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows),"Rows and columns must be greater than 0.");
            }

            Rows = rows;
            Columns = columns;
            elements = new double[rows, columns];

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Input array cannot be null.");
            }

            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
            elements = array;
        }

        /// <summary>
        /// Allows instances of a Matrix to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException"></exception>
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= elements.GetLength(0) 
                    || column < 0 || column >= elements.GetLength(1))
                {
                    throw new ArgumentException("Invalid row or column index.");
                }

                return elements[row, column];
            }
            set
            {
                if (row < 0 || row >= elements.GetLength(0) 
                    || column < 0 || column >= elements.GetLength(1))
                {
                    throw new ArgumentException("Invalid row or column index.");
                }

                elements[row, column] = value;
            }
        }

        /// <summary>
        /// Creates a deep copy of this Matrix.
        /// </summary>
        /// <returns>A deep copy of the current object.</returns>


        public object Clone()
        {
            Matrix cloneMatrix = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    cloneMatrix[i, j] = this[i, j];
                }
            }

            return cloneMatrix;
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is sum of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix1), "Matrices cannot be null.");
            }

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException("Matrices must have the same dimensions for addition.");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is subtraction of two matrices</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix1), "Matrices cannot be null.");
            }

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException("Matrices must have the same dimensions for subtraction.");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is multiplication of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix1), "Matrices cannot be null.");
            }

            if (matrix1.Columns != matrix2.Rows)
            {
                throw new MatrixException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
    

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Add(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null.");
            }

            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new MatrixException("Matrices must have the same dimensions for addition.");
            }

            Matrix result = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] + matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix parameter cannot be null.");
            }

            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new MatrixException("Matrices are not compatible for subtraction.");
            }

            Matrix result = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] - matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix parameter cannot be null.");
            }

            if (Columns != matrix.Rows)
            {
                throw new MatrixException("Matrices are not compatible for multiplication.");
            }

            Matrix result = new Matrix(Rows, matrix.Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < Columns; k++)
                    {
                        sum += this[i, k] * matrix[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        /// <summary>
        /// Tests if <see cref="Matrix"/> is identical to this Matrix.
        /// </summary>
        /// <param name="obj">Object to compare with. (Can be null)</param>
        /// <returns>True if matrices are equal, false if are not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Matrix other = (Matrix)obj;

            if (Rows != other.Rows || Columns != other.Columns)
            {
                return false;
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (this[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode() => GetHashCode();
    }
}
