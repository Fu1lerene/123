using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    class Program
    {
        /// <summary>
        /// Возвращает факториал заданного числа
        /// </summary>
        /// <param name="n">Число, факториал которого необходимо найти</param>
        /// <returns></returns>
        public static float factorial(int n)
        {
            float i, x = 1;
            for (i = 1; i <= n; i++)
            {
                x *= i;
            }
            return x;
        }

        /// <summary>
        /// Производит умножение матрицы на число и отображает результат
        /// </summary>
        /// <param name="c">Число, на которое нужно умножить</param>
        /// <param name="matrix">Матрица, которую нужно умножить</param>
        public static void Matrix_task_1(double c, double[,] matrix)
        {
            Random rng = new Random(); /// выделением памяти для генератора случайных чисел

            for (int i = 0; i < matrix.GetLength(0); ++i) /// заполнение случайными числами и вывод матрицы
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = rng.Next(10);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); ++i) /// умножение матрицы на число и ее вывод
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] *= c;
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Производит суммирование двух матриц и отображает результат
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        public static void Matrix_task_2(double[,] matrix1, double[,] matrix2)
        {
            Random rng = new Random(); /// выделением памяти для генератора случайных чисел

            for (int i = 0; i < matrix1.GetLength(0); ++i) /// заполнение случайными числами и вывод первой матрицы
            {
                for (int j = 0; j < matrix1.GetLength(1); ++j)
                {
                    matrix1[i, j] = rng.Next(10);
                    Console.Write(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < matrix2.GetLength(0); ++i) /// заполнение случайными числами и вывод второй матрицы
            {
                for (int j = 0; j < matrix2.GetLength(1); ++j)
                {
                    matrix2[i, j] = rng.Next(10);
                    Console.Write(matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < matrix1.GetLength(0); ++i) /// сложение двух матриц и вывод результата
            {
                for (int j = 0; j < matrix1.GetLength(1); ++j)
                {
                        matrix1[i, j] += matrix2[i, j];
                    Console.Write(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Производит умножение двух матриц и отображает результат
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        public static void Matrix_task_3(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) == matrix2.GetLength(0)) /// проверка на согласованность матриц
            {
                double[,] matrix3 = new double[matrix1.GetLength(0), matrix2.GetLength(1)]; /// создание новой матрицы размерности m x k
                Random rng = new Random(); /// выделением памяти для генератора случайных чисел

                for (int i = 0; i < matrix1.GetLength(0); ++i) /// заполнение случайными числами и вывод первой матрицы
                {
                    for (int j = 0; j < matrix1.GetLength(1); ++j)
                    {
                        matrix1[i, j] = rng.Next(10);

                        Console.Write(matrix1[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                for (int i = 0; i < matrix2.GetLength(0); ++i) /// заполнение случайными числами и вывод второй матрицы
                {
                    for (int j = 0; j < matrix2.GetLength(1); ++j)
                    {
                        matrix2[i, j] = rng.Next(10);
                        Console.Write(matrix2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                for (int i = 0; i < matrix1.GetLength(0); ++i) /// перемножение матриц и вывод результата
                {
                    for (int j = 0; j < matrix2.GetLength(1); ++j)
                    {
                        for (int k = 0; k < matrix1.GetLength(1); ++k)
                        {
                            matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                        Console.Write(matrix3[i, j] + " ");

                    }
                    Console.WriteLine();
                }
            } else Console.WriteLine("Ошибка!"); /// сообщение об ошибке, если матрицы несогласованы
        }

        /// <summary>
        /// Возвращает слово(а), содержащее минимальное или максимальное количество букв
        /// </summary>
        /// <param name="text">Текст, в котором ищется минимальное или максимальное слово(а)</param>
        /// <param name="minOrmax">Переменная отвечающая за поиск минимального или максимального слова</param>
        /// <returns></returns>
        public static string Task_2(string text, string minOrmax)
        {
            string result = String.Empty; /// создание пустой строки
            string[] split = text.Split(' ', ',', '.'); /// разделение строки на каждое отдельное слово и записывание этих слов в массив
            int minLength = Int32.MaxValue; /// переменная для поиска минимума
            int maxLength = Int32.MinValue; /// переменная для поиска максимума

            if (minOrmax == "min") /// условия для поиска минимального слова
            {
                for (int i = 0; i < split.Length; i++)
                {
                    if (minLength == split[i].Length) /// запись нескольких слов в строчку, если таких слов несколько
                        result += " " + split[i] + " ";

                    if (split[i].Length < minLength) /// нахождение минимального слова
                    {
                        minLength = split[i].Length;
                        result = split[i];
                    }
                }
            }
            else /// поиск максимального слова
            {
                for (int i = 0; i < split.Length; i++)
                {
                    if (maxLength == split[i].Length) /// запись нескольких слов в строчку, если таких слов несколько
                        result += " " + split[i] + " ";

                    if (split[i].Length > maxLength) /// нахождение максимального слова
                    {
                        maxLength = split[i].Length;
                        result = split[i];
                    }
                }
            }
            return result;
        }
        
        /// <summary>
        /// Возвращает текст, в котором все повторяющиеся буквы подряд заменены одной
        /// </summary>
        /// <param name="text">Текст, который нужно обработать</param>
        /// <returns></returns>
        public static string Task_3(string text)
        {
            string result = text; /// запись текста в новую переменную

            for (int i = 0; i < result.Length-1; ++i)
            {
                if (result[i] == result[i + 1]) /// проверка на повторение следующей буквы
                {
                    result = result.Remove(i, 1); /// удаление этой буквы
                    i--;
                }
            }
            return result;
        }

        /// <summary>
        /// Показывает является или не является последовательность чисел арифметической или геометрической прогрессией
        /// </summary>
        /// <param name="a">Последовательность чисел</param>
        public static void Task_4(params int[] a)
        {
            int count_ap = 0; /// счетчик для арифметической прогрессии
            int count_gp = 0; /// счетчик для геометрической прогрессии

            for (int i = 1; i < a.Length-1; ++i)
            {
                if (a[i] == (a[i - 1] + a[i + 1]) / 2) /// условие проверки является ли последовательность арифметической прогрессией
                {
                    count_ap++;
                }
            }

            for (int i = 1; i < a.Length - 1; ++i)
            {
                if (Math.Abs(a[i]) == Math.Sqrt(a[i - 1] * a[i + 1])) /// условие проверки является ли последовательность геометрической прогрессией
                {
                    count_gp++;
                }
            }

                if (count_ap == a.Length-2) 
            Console.WriteLine("Это арифметическая прогрессия");

            else if (count_gp == a.Length-2)
                Console.WriteLine("Это геометрическая прогрессия");

            else Console.WriteLine("Не является арифметической или геометрической прогрессией");

        }

        /// <summary>
        /// Возвращает значение функции Аккермана
        /// </summary>
        /// <param name="n">Первое принимаемое значение</param>
        /// <param name="m">Второе принимаемое значение</param>
        /// <returns></returns>
        public static int Task_5(int n, int m)
        {
            int result = 0;

            if (n == 0) /// первое условие функции Аккермана
            {
                result = ++m;
            }

            else if (n > 0 && m==0) /// второе условие функции Аккермана
            {
                result = Task_5(n - 1, 1);
            }

            else if (n > 0 && m > 0) /// третье условие функции Аккермана
            {
                result = Task_5(n - 1, Task_5(n, m - 1));
            }

            return result;
        }


        static void Main(string[] args)
        {
            /// Код для проверки первого задания

            //int a, b;
            //double c;
            //a = int.Parse(Console.ReadLine());
            //b = int.Parse(Console.ReadLine());
            //c = double.Parse(Console.ReadLine());
            //double[,] matrix = new double[a, b];
            //double[,] matrix2 = new double[a, b];
            //Matrix_task_1(c, matrix);

            //Matrix_task_2(matrix, matrix2);
            //int m, n, k, l;
            //m = int.Parse(Console.ReadLine());
            //n = int.Parse(Console.ReadLine());
            //k = int.Parse(Console.ReadLine());
            //l = int.Parse(Console.ReadLine());
            //Console.WriteLine();
            //double[,] matrix = new double[m, n];
            //double[,] matrix2 = new double[k, l];

            //Matrix_task_3(matrix, matrix2);

            /// Код для проверки второго задания

            //string val = Console.ReadLine();
            //Console.WriteLine(Task_2("A F ББ ВВВ ГГГГ ДДДД ДД ЕЕ ЖЖ ЗЗЗ", val));

            /// Код для проверки третьего задания

            //Console.WriteLine(Task_3("ПППОООГГГООООДДДААА"));
            //Console.WriteLine(Task_3("ххххоооорррооошшшиий деееннннь"));

            /// Код для проверки четвертого задания

            //Task_4(1, 2, 4, 8, 16);
            //Task_4(1, 2, 3, 4, 5);
            //Task_4(1, 3, 4, 9, 18);

            /// Код для проверки пятого задания

            //Console.WriteLine(Task_5(1,1));
        }
    }
}
