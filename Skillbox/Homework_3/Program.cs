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
            string revenge = String.Empty; /// создание пустой строки для реванша
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
                    while (userTry < userTry_a || userTry > userTry_b) /// условие удовлетворяющее диапазону вводимых чисел
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

            if (revenge == "Да" || revenge == "да")
            {
                Game(nicknames, numberOfPlayers, userTry_a, userTry_b, gameNumber_a, gameNumber_b);
            }
        }

        public static void Game_Solo(int userTry_a, int userTry_b, int gameNumber_a, int gameNumber_b)
        {
            string nickname;

            Console.Write("Введите свой никнейм: ");
            nickname = Console.ReadLine();
            bool flag = true;
            string revenge = String.Empty; /// создание пустой строки для реванша
            Random rng = new Random(); /// выделение памяти для генератора случайных чисел
            int gameNumber = rng.Next(gameNumber_a, gameNumber_b); /// случайное загаданное число в выбранном диапозоне
            int userTry; /// число вводимое пользователем

            Console.WriteLine($"Случайно загаданное число: {gameNumber}");

            while (gameNumber != 0) /// условие, при котором игра продолжается
            {
                if (flag)
                {
                    Console.Write($"Ваш ход {nickname}: ");
                    userTry = int.Parse(Console.ReadLine()); /// число, которое вводит пользователь
                    while (userTry < userTry_a || userTry > userTry_b) /// условие удовлетворяющее диапазону вводимых чисел
                    {
                        Console.Write("Давай другое число: ");
                        userTry = int.Parse(Console.ReadLine());
                    }
                    gameNumber -= userTry; /// вычитание введенного числа из загаданного (логика игры)
                    if (gameNumber == 0) continue; /// условие выхода из цикла, чтобы gameNumber не стало < 0 из-за количества игроков
                    Console.WriteLine($"Новое значение числа: {gameNumber}");
                    flag = false;
                }
                else
                {
                    Console.Write("Ход компьютера: ");
                    //if (gameNumber == )
                }
            }

            revenge = Console.ReadLine(); /// реванш?

            if (revenge == "Да" || revenge == "да")
            {
                ;
            }
        }

    

        static void Main(string[] args)
        {

            int numberOfPlayers; /// количество игроков

            Console.Write("Введите количество игроков: ");
            numberOfPlayers = int.Parse(Console.ReadLine());

            if (numberOfPlayers == 1)
            {
                Console.Write("Укажите диапазон вводимого числа: ");

                int userTry_a, userTry_b; /// нижний и верхний диапазон вводимого числа
                userTry_a = int.Parse(Console.ReadLine()); /// нижний
                userTry_b = int.Parse(Console.ReadLine()); /// верхний

                Console.Write("Укажите диапазон случайного числа: ");

                int gameNumber_a, gameNumber_b; /// нижний и верхний диапазон случайного числа
                gameNumber_a = int.Parse(Console.ReadLine()); /// нижний
                gameNumber_b = int.Parse(Console.ReadLine()); /// верхний

                Game_Solo(userTry_a, userTry_b, gameNumber_a, gameNumber_b);
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







            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!
        }
    }
}
