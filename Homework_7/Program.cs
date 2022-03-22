using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"Diary.txt"; /// пути в котором хранятся записи ежедневника
            string path2 = @"Diary 3.txt";
            string path3 = @"Diary 4.txt";

            Diary diary = new Diary(path); /// создаем четыре ежедневника
            Diary diary2 = new Diary(path);
            Diary diary3 = new Diary(path);
            Diary diary4 = new Diary(path);
            
            /// Проверка всех методов по заданию

            diary.Create_diary(10); /// создаем 10 случайных записей в первом ежеденвнике
            diary.PrintToConsole(); /// выводим полученные записи в консоль
            
            diary.Add_note(new Note(10, "Сидоров", "Иван", "8-800-555-35-35", DateTime.Now, "Проверка добавления!", "Сделано")); /// добавление записи
            diary.Delete_note(5); /// удаление одной записи заданного номера
            diary.Change_note(2, date: Convert.ToDateTime("31 декабря"), notice: "Проверка изменений!"); /// изменение любых полей записи (телефон, дата, заметка, статус)
            Console.WriteLine("\n\nИзменненный ежедневник:\n");
            diary.PrintToConsole(); /// выводим измененный дневник для проверки

            diary.Unload_diary(path); /// выгружаем ежедневник в файл по указанному пути
            diary2.Load_diary(path); /// загружаем из файла по указанному ежедневник
            Console.WriteLine("\n\nВторой ежедневник с теми же данными:\n");
            diary2.PrintToConsole(); /// выводим новый ежедневник для проверки

            diary3.Create_diary(5); /// создаем третий ежедневник для новых данных
            diary3.Unload_diary(path2); /// и выгружаем данные в другой файл
            Console.WriteLine("\n\nТретий ежедневник со случайными данными:\n");
            diary3.PrintToConsole(); /// выводим данные третьего ежедневника

            diary2.Add_diary(path, path2); /// добавляем ко второму ежедневнику данные из третьего
            Console.WriteLine("\n\nВторой ежедневник с данными из третьего ежедневника:\n");
            diary2.PrintToConsole(); /// проверяем добавились ли записи из третьего ко второму

            diary4.LoadByDate(path, Convert.ToDateTime("15 января"), Convert.ToDateTime("15 июля")); /// загружаем данные из указанного файла по выбраному диапазону дат
            Console.WriteLine("\n\nЧетвертный ежедневник с данными из первого с 15 января по 15 июля:\n");
            diary4.PrintToConsole(); /// выводим четвертный ежедневник для проверки

            diary4.Sort(path3); /// сортировка записей по выбранному полю и выгрузка их в файл по указанному пути
            Console.WriteLine("\n\nЧетвертный отсортированный ежедневник:\n");
            diary4.PrintToConsole(); /// выводим полученный результат
        }
    }
}
