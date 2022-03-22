using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Homework_6
{
    class Program
    {
        /// <summary>
        /// Создает и заполняет группы числами неделящимся друг на друга в каждой из групп
        /// </summary>
        /// <param name="N">Числа от 1 до N</param>
        /// <returns></returns>
        public static string[] FillGroups(int N)
        {
            string[] groups = new string[(int)Math.Log(N, 2) + 1];   /// создание массива размером равным количеству групп
            int group = 1;                                           /// номер группы, в которой мы работаем

            groups[0] = "1";                                         /// в нулевой группе всегда будет только единица

            DateTime startTime = DateTime.Now;                       /// переменная для вычисления времени работы программы

            for (int i = 2; i <= N; i++)                             /// перебор всех чисел от 2 до N
            {
                string temp = groups[group];                         /// переменная для проверки на пустую группы

                if (temp == null)                                    /// проверка на пустую строку
                {
                    groups[group] = Convert.ToString(i);             /// записываем число без отступа
                    group = 1;                                       /// возвращаемся к первой группе 
                }                                                    /// (для создание в первой группе ряд простых чисел)
                else                                                 // если строка не пустая
                {
                    string[] split_group = groups[group].Split(' '); /// делим строку на массив чисел

                    if (Check(i, split_group))                       /// проверка на делимость всех чисел в данной группе
                    {
                        groups[group] += $" {i}";                    /// записываем число через отступ
                        group = 1;                                   /// возвращаемся к первой группе (для создание в первой группе ряд простых чисел)
                    }
                    else                                             /// если число делится хотя бы на одно в строке 
                    {
                        group++;                                     /// прибавляем группу
                        i--;                                         /// отнимаем наше число, чтобы начать новую итерацию с тем же числом 
                    }                                                // и проверить новую группу, является ли она пустой
                }
            }

            TimeSpan timeSpan = DateTime.Now.Subtract(startTime);   /// переменная дающая время работы программы
            Console.WriteLine($"Время выполения программы в миллисекундах = {timeSpan.TotalMilliseconds}");
 
            return groups;
        }

        /// <summary>
        /// Возвращает true если все числа в строке не делятся друг на друга или false если делится хотя бы 1 число
        /// </summary>
        /// <param name="i">Число которое делится на все числа в строке</param>
        /// <param name="split_group">Строка чисел</param>
        /// <returns></returns>
        public static bool Check(int i, string[] split_group)
        {
            for (int j = 0; j < split_group.Length; ++j) /// цикл от 0 до длины действующей группы
            {
                int t = Convert.ToInt32(split_group[j]); /// конвертируем значение из string в int
                if (i % t == 0)                          /// проверка делимости нацело
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Архивация файла в zip расширение
        /// </summary>
        /// <param name="nameOfFile">Имя файла</param>
        public static void Compressed(string nameOfFile)
        {
            string nameOfFileCompressed = "Result compressed.zip"; /// имя для заархивированного файла

            using (FileStream ss = new FileStream(nameOfFile, FileMode.OpenOrCreate)) /// поток для чтения изначального файла 
            {
                using (FileStream ts = File.Create(nameOfFileCompressed))   /// поток для записи сжатого файла
                {
                    using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress)) /// поток архивации
                    {
                        ss.CopyTo(cs); /// копируем байты из одного потока в другой
                        Console.WriteLine($"Сжатие файла {nameOfFile} завершено. Было: {ss.Length}  стало: {ts.Length}."); /// размер в байтах
                    }
                }
            }
        }

        /// <summary>
        /// Разархивация файла из zip в txt
        /// </summary>
        /// <param name="nameOfFileCompressed">Имя заархивированного файла</param>
        public static void Unzip(string nameOfFileCompressed)
        {
            string newname = "Result unzip.txt"; /// новое имя для разахивированного файла

            using (FileStream ss = new FileStream(nameOfFileCompressed, FileMode.OpenOrCreate))  /// поток для чтения из сжатого файла
            {
                using (FileStream ts = File.Create(newname)) /// поток для записи восстановленного файла
                {
                    using (GZipStream ds = new GZipStream(ss, CompressionMode.Decompress)) /// поток разархивации
                    {
                        ds.CopyTo(ts);
                        Console.WriteLine($"Восстановление файла Result.txt завершено. Было: {ss.Length}  стало: {ts.Length}."); /// размер в байтах
                    }
                }
            }
        }

        static void Main()
        {
            if (File.Exists(@"Data.txt")) /// проверка на существования файла в корневой папке
            {
                int N = Convert.ToInt32(File.ReadAllText(@"Data.txt")); /// считывание числа N из файла

                if (N < 1_000_000_000 && N > 1) /// проверка N на допустимые значения
                {
                    Console.WriteLine($"Полученное число N = {N}\nВыберите дальнейший вариант работы: " +
                        $"\n1 - Получить количество групп\n2 - Заполнить и записать полученные группы"); /// вывод информации и режимы работы программы

                    int mode = int.Parse(Console.ReadLine()); /// переменная отвечающая за режим работы программы

                    while (mode == 1 || mode == 2) /// условие при котором программа продолжает свою работу
                    {
                        switch (mode) /// режим работы
                        {
                            case 1:
                                Console.WriteLine($"Количество групп = {(int)Math.Log(N, 2) + 1}"); /// вывод количество групп для заданного N
                                break;

                            case 2:
                                string[] result = FillGroups(N); /// запись полученных групп в переменную
                                string nameOfFile = "Result.txt"; /// имя файла
                                File.WriteAllLines(nameOfFile, result); /// запись полученных данных в файл с заданным названием

                                Console.WriteLine("Желаете заархивировать данные (да/нет)?"); /// вопрос об архивации
                                string ans = Console.ReadLine(); /// переменная для ответа на вопрос

                                if (ans == "да") /// если "да" происходит архивация файла
                                {
                                    Compressed(nameOfFile); /// архивация файла

                                    Console.WriteLine("Хотите разархивировать полученный результат (да/нет)?"); /// вопрос о разархивации
                                    ans = Console.ReadLine();

                                    if (ans == "да")
                                    {
                                        Unzip("Result compressed.zip"); /// разархивация файла
                                    }
                                }
                                else Console.WriteLine("Программа завершила свою работу"); /// уведомление об успешном завершении программы
                                break;

                            default:
                                break;
                        }
                        if (mode == 2) break; /// программа завершит свою работу после создания всех групп и записи данных в файл

                        mode = int.Parse(Console.ReadLine()); /// режим работы программы
                    }
                }
                else Console.WriteLine("Число N неверно!"); /// вывод ошибки если N не удовлетворяет заданным условиям
            }
            else /// если файл не был обнаружен в корневой папке
            {
                Console.Write("Файл не был найден, создан новый файл Data.txt со значением ");
                File.WriteAllText(@"Data.txt", Convert.ToString(50)); /// создается новый файл с N равным по умолчанию 50
                Main(); /// повторный запуск программы
            }
        }
    }
}
