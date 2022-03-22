using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
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
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = rng.Next(10);
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine($"{"|",4}");
            }
            Console.WriteLine(); /// отступ в одну строчку

            for (int i = 0; i < matrix.GetLength(0); ++i) /// умножение матрицы на число и ее вывод
            {
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] *= c;
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine($"{"|",4}");
            }
        }

        /// <summary>
        /// Производит суммирование двух матриц и отображает результат
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <param name="sumOrdiff">Переменная, отвечающая за сложение или вычитание</param>
        public static void Matrix_task_2(double[,] matrix1, double[,] matrix2, char sumOrdiff)
        {
            Random rng = new Random(); /// выделением памяти для генератора случайных чисел

            for (int i = 0; i < matrix1.GetLength(0); ++i) /// заполнение случайными числами и вывод первой матрицы
            {
                Console.Write("|");
                for (int j = 0; j < matrix1.GetLength(1); ++j)
                {
                    matrix1[i, j] = rng.Next(10);
                    Console.Write($"{matrix1[i, j],4}");
                }
                Console.WriteLine($"{"|",4}");
            }
            Console.WriteLine(); /// отступ в одну строчку


            for (int i = 0; i < matrix2.GetLength(0); ++i) /// заполнение случайными числами и вывод второй матрицы
            {
                Console.Write("|");
                for (int j = 0; j < matrix2.GetLength(1); ++j)
                {
                    matrix2[i, j] = rng.Next(10);
                    Console.Write($"{matrix2[i, j],4}");
                }
                Console.WriteLine($"{"|",4}");
            }
            Console.WriteLine(); /// отступ в одну строчку

            for (int i = 0; i < matrix1.GetLength(0); ++i) /// сложение или вычитание двух матриц и вывод результата
            {
                Console.Write("|");
                for (int j = 0; j < matrix1.GetLength(1); ++j)
                {
                    if (sumOrdiff == '+')
                    {
                        matrix1[i, j] += matrix2[i, j];
                    }
                    else matrix1[i, j] -= matrix2[i, j];
                    Console.Write($"{matrix1[i, j],4}");
                }
                Console.WriteLine($"{"|",4}");
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
                    Console.Write("|");
                    for (int j = 0; j < matrix1.GetLength(1); ++j)
                    {
                        matrix1[i, j] = rng.Next(10);

                        Console.Write($"{matrix1[i, j],4}");
                    }
                    Console.WriteLine($"{"|",4}");
                }
                Console.WriteLine(); /// отступ в одну строчку

                for (int i = 0; i < matrix2.GetLength(0); ++i) /// заполнение случайными числами и вывод второй матрицы
                {
                    Console.Write("|");
                    for (int j = 0; j < matrix2.GetLength(1); ++j)
                    {
                        matrix2[i, j] = rng.Next(10);
                        Console.Write($"{matrix2[i, j],4}");
                    }
                    Console.WriteLine($"{"|",4}");
                }
                Console.WriteLine(); /// отступ в одну строчку

                for (int i = 0; i < matrix1.GetLength(0); ++i) /// перемножение матриц и вывод результата
                {
                    Console.Write("|");
                    for (int j = 0; j < matrix2.GetLength(1); ++j)
                    {
                        for (int k = 0; k < matrix1.GetLength(1); ++k)
                        {
                            matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                        Console.Write($"{matrix3[i, j],4}");
                    }
                    Console.WriteLine($"{"|",4}");
                }
            }
            else Console.WriteLine("Ошибка! Матрицы несогласованы"); /// сообщение об ошибке, если матрицы несогласованы
        }

        static void Main(string[] args)
        {
            #region Задание 1

            int[] cost = new int[12];       /// массив расходов
            int[] income = new int[12];     /// массив доходов
            int[] profit = new int[12];     /// массив прибыли
            int[] worst = new int[12];      /// массив для хранения месяцев худшей прибылью
            int count_pos = 0;              /// счетчик для подсчетов месяцев с положительной прибылью
            
            Random rng = new Random();      /// выделение памяти для генератора случайных чисел

            for (int i = 0; i < 12; ++i)    /// заполнение массивов расходов и доходов случайными числами
            {
                cost[i] = rng.Next(10, 100) * 1000;
                income[i] = rng.Next(50, 200) * 1000;
                profit[i] = income[i] - cost[i]; /// вычесление прибыли
                if (profit[i] >= 0)  /// подсчет месяцев с положительной прибылью
                {
                    count_pos++;
                }
            }

            Console.WriteLine($"{"Месяц",10} {"Доход, тыс. руб.",20} {"Расход, тыс. руб.",20} {"Прибыль, тыс. руб.",20}"); /// вывод шапки таблицы

            for (int i = 0; i < 12; ++i) /// вывод всех массивов и месяцев
            {
                Console.WriteLine($"{i + 1,10} {income[i].ToString("## ###"), 20} {cost[i].ToString("## ###"),20}" +
                    $" {profit[i].ToString("## ###"),20}");
            }

            for (int i = 0; i < 12; ++i) /// заполняем массив количеством месяцев (индексами)
            {
                worst[i] = i + 1;
            }

            int indx; /// переменная для хранения индекса минимального элемента массива

            for (int i = 0; i < 12; ++i) /// проходим по массиву с начала и до конца
            {
                indx = i; /// считаем, что минимальный элемент имеет текущий индекс
                for (int j = i; j < 12; ++j) /// ищем минимальный элемент в неотсортированной части
                {
                    if (profit[j] < profit[indx])
                    {
                        indx = j; /// нашли в массиве число меньше, чем profit[indx] - запоминаем его индекс в массиве
                    }
                }
                if (profit[indx] == profit[i]) /// если минимальный элемент равен текущему значению - ничего не меняем
                {
                    continue;
                }

                int temp = profit[i];     /// временная переменная, чтобы не потерять значение profit[i]
                profit[i] = profit[indx]; /// меняем местами минимальный элемент и первый в неотсортированной части
                profit[indx] = temp;

                temp = worst[i];          /// временная переменная, чтобы не потерять значение worst[i]
                worst[i] = worst[indx];   /// меняем местами индексы
                worst[indx] = temp;
            }

            Console.Write("Худшая прибыль в месяцах: ");
            int k = 0;
            for (int i = 0; profit[i] == profit[i-k] || i < 3; ++i) /// вывод худших месяцев
            {
                k = 1;
                Console.Write($"{worst[i]} ");
            }
            Console.WriteLine($"\nМесяцев с положительной прибылью: {count_pos}"); /// вывод месяцев с положительной прибылью

            #endregion
 
            #region Задание 2

            Console.WriteLine("\nВведите чило для построения треугольника Паскаля (N <= 15)");
            int N = int.Parse(Console.ReadLine()); /// количество строчек в треугольнике
            float var; /// переменная, в которую будет записываться каждый элемент в треугольнике

            while (N > 15) /// проверка условия
            {
                Console.WriteLine("Введите другое число (N <= 15)");
                N = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < N; ++i) /// построение треугольника (i - количество строчек)
            {
                for (int j = 0; j <= (N - i); j++) /// создаём после каждой строки n-i отступов от левой стороны консоли, чем ниже строка, тем меньше отступ
                {
                    Console.Write($"{" ", 3}");
                }
                for (int j = 0; j <= i; j++) /// создаём пробелы между элементами треугольника и вычисляем каждый элемент в строке
                {
                    Console.Write(" ");
                    var = factorial(i) / (factorial(j) * factorial(i - j)); /// формула вычисления элементов треугольника
                    Console.Write($"{var, 5}"); /// вывод элементов
                }
                Console.WriteLine(); /// после каждой строки с числами отступаем одну пустую строчку
            }

            #endregion

            #region Задание 3

            /// Первая часть задания 3

            int m, n; /// размерность матрицы
            double c; /// число на которое необходимо умножить
            Console.WriteLine("\nВведите размерность матрицы");
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            while (m < 1 || n < 1) /// проверка на существование такой матрицы
            {
                Console.WriteLine("Нельзя построить матрицу такой размерности, попробуйте еще раз: ");
                m = int.Parse(Console.ReadLine());
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите число на которое нужно умножить матрицу");
            c = double.Parse(Console.ReadLine());
            Console.WriteLine();
            double[,] matrix = new double[m, n]; /// создание матрицы заданных размеров

            Matrix_task_1(c, matrix); /// метод выполняющий умножение матрицы на число

            /// Вторая часть задания

            //int m, n; /// размерность матрицы
            //Console.WriteLine("Введите размерность матриц");
            //m = int.Parse(Console.ReadLine());
            //n = int.Parse(Console.ReadLine());
            //while (m < 1 || n < 1) /// проверка на существование такой матрицы
            //{
            //    Console.WriteLine("Нельзя построить матрицу такой размерности, попробуйте еще раз: ");
            //    m = int.Parse(Console.ReadLine());
            //    n = int.Parse(Console.ReadLine());
            //}
            //double[,] matrix = new double[m, n]; /// создание первой матрицы заданных размеров
            //double[,] matrix2 = new double[m, n]; /// создание второй матрицы таких же размеров
            //Console.WriteLine("Сложить или вычесть матрицы? (+/-)");
            //char sumOrdiff = char.Parse(Console.ReadLine());

            //Matrix_task_2(matrix, matrix2, sumOrdiff); /// метод вычисляющий сумму или разность двух матриц

            /// Третья часть задания

            //int m, n, a, b; /// размерность двух матриц
            //Console.WriteLine("Введите размерность первой матрицы");
            //m = int.Parse(Console.ReadLine());
            //n = int.Parse(Console.ReadLine());
            //while (m < 1 || n < 1) /// проверка на существование первой матрицы
            //{
            //    Console.WriteLine("Нельзя построить матрицу такой размерности, попробуйте еще раз: ");
            //    m = int.Parse(Console.ReadLine());
            //    n = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Введите размерность второй матрицы");
            //a = int.Parse(Console.ReadLine());
            //b = int.Parse(Console.ReadLine());
            //while (a < 1 || b < 1) /// проверка на существование второй матрицы
            //{
            //    Console.WriteLine("Нельзя построить матрицу такой размерности, попробуйте еще раз: ");
            //    a = int.Parse(Console.ReadLine());
            //    b = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine();
            //double[,] matrix = new double[m, n]; /// создание первой матрицы заданных размеров
            //double[,] matrix2 = new double[a, b]; /// создание второй матрицы заданных размеров

            //Matrix_task_3(matrix, matrix2);

            #endregion
        }
    }
}
