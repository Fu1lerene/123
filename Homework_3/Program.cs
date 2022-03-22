using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class Program
    {
        /// <summary>
        /// Запускает многопользовательскую игру
        /// </summary>
        /// <param name="nicknames">Никнеймы игроков</param>
        /// <param name="numberOfPlayers">Количество игроков</param>
        /// <param name="userTry_a">Нижняя граница вводимого числа</param>
        /// <param name="userTry_b">Верхняя граница вводимого числа</param>
        /// <param name="gameNumber_a">Верхняя граница случайного числа</param>
        /// <param name="gameNumber_b">Верхняя граница случайного числа</param>
        public static void Game(string[] nicknames, int numberOfPlayers, int userTry_a, int userTry_b, int gameNumber_a, int gameNumber_b)
        {
            Random rng = new Random(); /// выделение памяти для генератора случайных чисел
            string revenge; /// создание строки для реванша
            int gameNumber = rng.Next(gameNumber_a, gameNumber_b); /// случайное загаданное число в выбранном диапозоне
            int userTry; /// число вводимое пользователем
            int player = 0; /// номер игрока на котором закончилась игра

            Console.WriteLine($"Случайно загаданное число: {gameNumber}");

            while (gameNumber != 0) /// условие, при котором игра продолжается
            {
                for (int i = 0; i < numberOfPlayers; ++i) /// цикл для n-ого количества игроков
                {
                    player = i; /// запоминание номера ходящего игрока
                    Console.Write($"Ход игрока {nicknames[i]}: ");
                    userTry = int.Parse(Console.ReadLine()); /// число, которое вводит пользователь
                    while (userTry < userTry_a || userTry > userTry_b || gameNumber - userTry < 0) /// условие удовлетворяющее диапазону вводимых чисел
                    {
                        Console.Write("Давай другое число: ");
                        userTry = int.Parse(Console.ReadLine());
                    }
                    gameNumber -= userTry; /// вычитание введенного числа из загаданного (логика игры)
                    if (gameNumber == 0) break; /// условие выхода из цикла, чтобы gameNumber не стало < 0 из-за количества игроков
                    Console.WriteLine($"Новое значение числа: {gameNumber}");
                }
            }

            Console.WriteLine($"Поздравляем! Победил игрок: {nicknames[player]}");
            Console.WriteLine("Хотите взять реванш? ");
            revenge = Console.ReadLine(); /// реванш?

            if (revenge == "Да" || revenge == "да") /// условие для реванша
            {
                Game(nicknames, numberOfPlayers, userTry_a, userTry_b, gameNumber_a, gameNumber_b);
            }
        }

        /// <summary>
        /// Запускает однопользовательскую игру
        /// </summary>
        /// <param name="userTry_a">Нижняя граница вводимого числа</param>
        /// <param name="userTry_b">Верхняя граница вводимого числа</param>
        /// <param name="gameNumber_a">Верхняя граница случайного числа</param>
        /// <param name="gameNumber_b">Верхняя граница случайного числа</param>
        public static void Game_Solo(int userTry_a, int userTry_b, int gameNumber_a, int gameNumber_b)
        {
            string nickname; /// переменная для имени игрока
            Console.Write("Введите свой никнейм: ");
            nickname = Console.ReadLine();

            bool flag = true; /// ход игрока или компьютера
            string revenge; /// создание пустой строки для реванша
            int userTry; /// число вводимое пользователем
            int compTry; /// временная переменная необходимая для хода компьютера

            Random rng = new Random(); /// выделение памяти для генератора случайных чисел
            int gameNumber = rng.Next(gameNumber_a, gameNumber_b); /// случайное загаданное число в выбранном диапозоне

            Console.WriteLine($"Случайно загаданное число: {gameNumber}");

            while (gameNumber != 0) /// условие, при котором игра продолжается
            {
                if (flag) /// ход игрока
                {
                    Console.Write($"Ваш ход {nickname}: ");
                    userTry = int.Parse(Console.ReadLine()); /// число, которое вводит пользователь
                    while (userTry < userTry_a || userTry > userTry_b || gameNumber - userTry < 0) /// условие удовлетворяющее диапазону вводимых чисел
                    {
                        Console.Write("Давай другое число: ");
                        userTry = int.Parse(Console.ReadLine());
                    }
                    gameNumber -= userTry; /// вычитание введенного числа из загаданного (логика игры)
                    flag = false; /// переход хода
                    if (gameNumber == 0) continue; /// условие выхода из цикла, чтобы gameNumber не стало < 0 из-за количества игроков
                    Console.WriteLine($"Новое значение числа: {gameNumber}");
                }
                else /// ход компьютера
                {
                    compTry = userTry_a; /// минимальное значение вводимого числа
                    Console.Write("Ход компьютера: ");
                    if (gameNumber > userTry_b) /// если победить невозможно на данный ход, компьютер вводит случайное число, удовлетворяющее правилам
                    {
                        compTry = rng.Next(userTry_a, userTry_b + 1);
                        Console.WriteLine(compTry);
                    }
                    else /// иначе он введет число такое, что gameNumber станет равна нулю
                    {
                        for (int i = 0; i < userTry_b; ++i) /// цикл, который длится до максимального вводимого числа
                        {
                            if (gameNumber - compTry != 0 && compTry < userTry_b) /// перебор разности (gameNumber должна стать 0)
                            {
                                compTry++;
                            }
                            else /// вывод найденого числа и выход из цикла
                            {
                                Console.WriteLine(compTry);
                                break;
                            }
                        }
                    }
                     
                    gameNumber -= compTry; /// вычитание введенного числа из загаданного (логика игры)
                    flag = true; /// переход хода
                    if (gameNumber == 0) continue; /// условие выхода из цикла, чтобы gameNumber не стало < 0 из-за количества игроков
                    Console.WriteLine($"Новое значение числа: {gameNumber}");
                }
            }

            if (flag) /// вывод текста о победителе в зависимости от того на ком закончился ход и предложение реванша при поражении (те же правила)
            {
                Console.WriteLine("Победил компютер, к сожалению, вы проиграли :(");
                Console.WriteLine("Хотите взять реванш? ");

                revenge = Console.ReadLine(); /// реванш?

                if (revenge == "Да" || revenge == "да")
                {
                    Game_Solo(userTry_a, userTry_b, gameNumber_a, gameNumber_b);
                }
            }
            else /// поздравление с победой и предложение повторить матч (те же правила)
            {
                Console.WriteLine("Поздравляем! Вы победили!");
                Console.WriteLine("Хотите повторить реузльтат? ");
                revenge = Console.ReadLine(); /// реванш?

                if (revenge == "Да" || revenge == "да")
                {
                    Game_Solo(userTry_a, userTry_b, gameNumber_a, gameNumber_b);
                }
            }
        }


        static void Main(string[] args)
        {

            int numberOfPlayers; /// количество игроков

            Console.Write("Введите количество игроков: ");
            numberOfPlayers = int.Parse(Console.ReadLine());

            if (numberOfPlayers == 1) /// условие однопользовательской игры
            {
                Console.Write("Укажите диапазон вводимого числа: ");

                int userTry_a, userTry_b; /// нижний и верхний диапазон вводимого числа
                userTry_a = int.Parse(Console.ReadLine()); /// нижний
                userTry_b = int.Parse(Console.ReadLine()); /// верхний

                Console.Write("Укажите диапазон случайного числа: ");

                int gameNumber_a, gameNumber_b; /// нижний и верхний диапазон случайного числа
                gameNumber_a = int.Parse(Console.ReadLine()); /// нижний
                gameNumber_b = int.Parse(Console.ReadLine()); /// верхний

                Game_Solo(userTry_a, userTry_b, gameNumber_a, gameNumber_b); /// запуск однопользовательской игры с заданными правилами
            }
            else
            {
                while (numberOfPlayers < 2) /// условие для многопользовательской игры и избежание отрицательных значений
                {
                    Console.Write("Введите другое количество игроков: ");
                    numberOfPlayers = int.Parse(Console.ReadLine());
                }

                Console.Write("Укажите диапазон вводимого числа: ");

                int userTry_a, userTry_b; /// нижний и верхний диапазон вводимого числа
                userTry_a = int.Parse(Console.ReadLine()); /// нижний
                userTry_b = int.Parse(Console.ReadLine()); /// верхний

                Console.Write("Укажите диапазон случайного числа: ");

                int gameNumber_a, gameNumber_b; /// нижний и верхний диапазон случайного числа
                gameNumber_a = int.Parse(Console.ReadLine()); /// нижний
                gameNumber_b = int.Parse(Console.ReadLine()); /// верхний

                string[] nicknames = new string[numberOfPlayers]; /// динамический массив никнеймов

                for (int i = 0; i < numberOfPlayers; ++i) /// заполнение массива никнеймами игроков
                {
                    Console.Write($"Игрок {i + 1}, введите свои никнейм: ");
                    nicknames[i] = Console.ReadLine();
                }
                Game(nicknames, numberOfPlayers, userTry_a, userTry_b, gameNumber_a, gameNumber_b); /// запуск многопользовательской игры
            }
        }
    }
}
