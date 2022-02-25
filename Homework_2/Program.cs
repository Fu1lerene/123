using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name; /// объявление переменной для имени
            int age, heigh, points_rus, points_math, points_hist; /// объявление переменных для возраста, роста и баллов по каждому из предметов

            // присваивание значений каждой переменной
            name = "Александр";
            age = 21;
            heigh = 190;
            points_rus = 100;
            points_math = 100;
            points_hist = 100;

            double avg = (points_hist + points_math + points_rus) / 3; /// объявление и подсчет среднего балла по трем предметам

            string text = $"Имя: { name}\nВозраст: { age}\nРост: { heigh}\nБаллы по русскому языку: { points_rus}\n" +
                $"Баллы по математике: {points_math}\nБаллы по истории: {points_hist}\nСредний балл по трем предметам: {avg}"; /// полный текст

            Console.WriteLine(text); /// вывод в консоль

            /// Задание со звездочкой: вывод текста в центр консоли

            string[] lines = text.Split('\n'); /// Разбиваем текст на массив строк

            int left = 0; /// Отступ слева будет определяться для каждой строки отдельно

            int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1; /// Определяем отступ сверху для первой строки

            int center = Console.WindowWidth / 2; /// Находим центр консоли


            for (int i = 0; i < lines.Length; ++i)
            {
                left = center - (lines[i].Length / 2); /// Определяем отступ для текущей строки
                
                Console.SetCursorPosition(left, top); /// Меняем положение курсора
                
                Console.WriteLine(lines[i]); /// Выводим строку

                top = Console.CursorTop; /// Для каждой новой строки программа будет автоматически считать отступ сверху
            }
        }
    }
}
