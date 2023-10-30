using System;
using System.Drawing;
using System.Numerics;

namespace task0
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            jobNumbers(21, 5);
            
            task993();
            Console.WriteLine("\n------------------------------------");
            task1000();
            Console.WriteLine("\n------------------------------------");
            task903();
            Console.WriteLine("\n------------------------------------");
            task939();
            Console.WriteLine("\n------------------------------------");
            task1001();
        }

        /*
         * Дана целочисленная квадратная матрица. 
         * Найти в каждой строке наибольший элемент и поменять его местами с элементом главной диагонали.
        */
        public static void task993()
        {
            Console.WriteLine("Task 993.\n" + 
                "Enter the size of the square matrix");
            int length = inputNumber();
            int[,] matrix = new int[length, length];
            fillSquareMatrix(matrix);
            int temp;

            Console.WriteLine("Primordial Matrix: ");
            printSquarematrix(matrix);

            for (int i = 0; i < length; i++)
            {
                temp = matrix[i, i];
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i, j] > temp)
                    {
                        temp = matrix[i, j];
                        matrix[i, j] = matrix[i, i];
                        matrix[i, i] = temp;
                    }
                }
            }

            Console.WriteLine("Matrix with the largest elements of each row on the main diagonal: ");
            printSquarematrix(matrix);
        }
        /*
         * Дана вещественная квадратная матрица порядка n (n — нечетное), все элементы которой различны. 
         * Найти наибольший элемент среди стоящих на главной и побочной диагоналях и поменять его местами с элементом, стоящим на пересечении этих диагоналей.
         */
        public static void task1000()
        {
            Console.WriteLine("Task 1000.\n" +
                "Enter odd size square matrix");

            int length = inputOddNumber();
            double[,] matrix = new double[length, length];

            fillSquareMatrix(matrix);

            Console.WriteLine("Primordial Matrix: ");
            printSquarematrix(matrix);

            findAndSwapLargestDiagonalElement(matrix);

            Console.WriteLine("A matrix in which the maximum element on two diagonals is swapped with the element at the intersection of two diagonals: ");
            printSquarematrix(matrix);
        }

        /*
         * Задание 903 т.к. 902-го нет в списке.
         * Найти сумму всех четных элементов Двумерного массива целых чисел A[10, 10].
         */
        public static void task903()
        {
            Console.WriteLine("Task 903.");
            int length = 10;
            long result = 0;
            int[,] matrix = new int[length, length];
            fillSquareMatrix(matrix);
            Console.WriteLine("Initial matrix: ");
            printSquarematrix(matrix);
            foreach (var item in matrix)
            {
                if (item%2 == 0)
                {
                    result += item;
                }
            }
            Console.WriteLine("Sum of all even matrix elements: " + result);
        }

        /*
         * Известен номер столбца, на котором расположен элемент побочной диагонали массива. 
         * Вывести на экран значение этого элемента.
         */
        public static void task939()
        {
            Console.WriteLine("Task 939.\n" +
                "Enter the size of the square matrix:");
            int length = inputNumber();
            int[,] matrix = new int[length, length];
            fillSquareMatrix(matrix);

            Console.WriteLine("Initial matrix: ");
            printSquarematrix(matrix);

            Console.WriteLine("Enter column number:");
            int columnNumber = inputNumber() - 1;
            while (true)
            {
                if (columnNumber <= matrix.GetLength(0))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                    columnNumber = inputNumber() - 1;
                }
            }
            Console.WriteLine("Your number is on the side diagonal: " + matrix[matrix.GetLength(0) - columnNumber - 1, columnNumber]);
        }

        /*
         * Квадратная матрица, симметричная относительно главной диагонали, задана верхним треугольником в виде одномерного массива. 
         * Восстановить исходную матрицу и напечатать по строкам.
         */
        public static void task1001()
        {
            Console.WriteLine("Task 1001.");
            int[] upperTriangle = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int size = getMatrixSize(upperTriangle.Length);
            int[,] symmetricMatrix = restoreSymmetricMatrix(upperTriangle, size);

            printSquarematrix(symmetricMatrix);
        }

        // Метод для определения размерности матрицы по длине верхнего треугольника.
        static int getMatrixSize(int arrayLength)
        {
            return (int)(-0.5 + Math.Sqrt(0.25 + 2 * arrayLength));
        }

        // Метод для заполнения матрици с учетом симетрии.
        static int[,] restoreSymmetricMatrix(int[] upperTriangle, int size)
        {
            int[,] symmetricMatrix = new int[size, size];

            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    symmetricMatrix[i, j] = upperTriangle[index];
                    symmetricMatrix[j, i] = upperTriangle[index];
                    index++;
                }
            }

            return symmetricMatrix;
        }

        // Метод для нахождения максимального числа среди двух диагоналей и заменой его с элементом пересечения диагоналей.
        public static void findAndSwapLargestDiagonalElement(double[,] matrix)
        {
            int length = matrix.GetLength(0);

            double maxMainDiagonal = matrix[0, 0],
            maxSecondaryDiagonal = matrix[0, length - 1];

            for (int i = 1; i < length; i++)
            {
                if (matrix[i, i] > maxMainDiagonal)
                {
                    maxMainDiagonal = matrix[i, i];
                }
            }

            for (int i = 1; i < length; i++)
            {
                if (matrix[i, length - 1 - i] > maxSecondaryDiagonal)
                {
                    maxSecondaryDiagonal = matrix[i, length - 1 - i];
                }
            }

            double maxNumber = maxMainDiagonal > maxSecondaryDiagonal ? maxNumber = maxMainDiagonal : maxNumber = maxSecondaryDiagonal;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i, j] == maxNumber)
                    {
                        matrix[i, j] = matrix[length / 2, length / 2];
                        matrix[length / 2, length / 2] = maxNumber;
                        break;
                    }
                }
            }
        }

        //Метод для вывода треугольника в консоль
        public static void printSquarematrix<arr>(arr[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{ ");
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (j == matrix.GetLength(0) - 1)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + ", ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        // Метод для заполнения матрици типа int случайными числами
        public static int[,] fillSquareMatrix(int[,] matrix)
        {
            Random rand = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = rand.Next();
                }
            }
            return matrix;
        }

        // Метод для заполнения матрици типа double случайными и уникальными числами
        public static double[,] fillSquareMatrix(double[,] matrix)
        {
            Random rand = new Random();

            List<double> uniqueNumbers = Enumerable.Range(1, matrix.Length).Select(i => Convert.ToDouble(i)).ToList();

            int index;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    index = rand.Next(0, uniqueNumbers.Count);
                    matrix[i, j] = uniqueNumbers[index];
                    uniqueNumbers.RemoveAt(index);
                }
            }
            return matrix;
        }

        /*
         * Метод для определения номеров заданий по номеру студента в списке, количеству зданий. 
         * Номера заданий не будут повторятся
         */
        public static void jobNumbers(int studentNumber, int numberOfTasks)
        {
            int temp = 0;
            int[] result = new int[numberOfTasks];
            Console.WriteLine("Job numbers: ");
            for (int n = 0; n < result.Length; n++)
            {
                temp = (int)((Math.Pow(n + 1, 3) + Math.Pow(studentNumber, 2)) % 117) + 902;

                foreach (var item in result)
                {
                    if (temp != item)
                    {
                        result[n] = temp;
                    }
                    else
                    {
                        result[n] = temp + 1;
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /*
         * Метод для ввода числа с клавиатуры.
         * Число не может быть отрицательным и в числе не должны присутствовать сторонние символы.
         */
        public static int inputNumber()
        {
            string input = "";
            int number = 0;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    if (number > 0)
                    {
                        return number;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        /*
         * Метод для ввода числа с клавиатуры.
         * Число не может быть отрицательным и в числе не должны присутствовать сторонние символы.
         * Число не может быть четным
         */
        public static int inputOddNumber()
        {
            string input = "";
            int number = 0;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    if (number > 0 && number%2 != 0)
                    {
                        return number;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }
    }
}