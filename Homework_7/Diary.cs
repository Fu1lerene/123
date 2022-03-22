using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Homework_7
{
    /// <summary>
    /// Ежедневник
    /// </summary>
    internal class Diary
    {
        #region Конструкторы

        /// <summary>
        /// Статический конструктор, в котором "хранятся"
        /// данные о именах и фамилиях баз данных firstNames, lastNames и rng_notice
        /// </summary>
        static Diary()
        {
            randomize = new Random(); /// размещение в памяти генератора случайных чисел

            firstNames = new string[] /// размещение имен в базе данных firstNames
            {
                "Агата",
                "Агнес",
                "Аделаида",
                "Аделина",
                "Алдона",
                "Алима",
                "Аманда",
                "Александра",
                "Анастасия",
                "Анна",
                "Екатерина",
                "Светлана",
                "Елена",
                "Ирина",
                "Татьяна",
                "Ольга",
                "Любовь",
                "Витория",
                "Антонина",
                "Нина",
                "Кира"
            };

            lastNames = new string[] /// размещение фамилий в базе данных lastNames
            {
                "Иванова",
                "Петрова",
                "Васильева",
                "Кузнецова",
                "Ковалёва",
                "Попова",
                "Пономарёва",
                "Дьячкова",
                "Коновалова",
                "Соколова",
                "Лебедева",
                "Соловьёва",
                "Козлова",
                "Волкова",
                "Зайцева",
                "Ершова",
                "Карпова",
                "Щукина",
                "Виноградова",
                "Цветкова",
                "Калинина"
            };

            rng_notice = new string[] /// размещение случайных заметок в базе данных rng_notice
            {
                "Приятная внешность",
                "Оставила положительный отзыв",
                "Оставила чаевые",
                "Пришла с собачкой",
                "Грубо разговаривает",
                "Любит поболтать",
                "Перезвонить",
                "Просит включить свою музыку",
                "Странная девушка",
                "Любит покушать",
                "Назначила мне встречу в кафе",
                "Очень понравился наш сервис",
                "Предложила рекламу, нужно подумать",
                "Постоянный клиент",
                "Приятный смех",
                "Постоянно говорит по телефону",
                "Попросила сфотографироваться",
            };

            rng_check = new string[] /// размещение случайного check
            {
                "Сделано",
                "Не сделано"
            };
        }

        /// <summary>
        /// Конструктор создания дневника
        /// </summary>
        /// <param name="Path">Путь к имени файла</param>
        /// <param name="count">Количество записей в ежедневнике</param>
        public Diary(string path = null)
        {
            this.Count = 0;
            this.Path = path;
            this.index = 0;
            this.notes = new Note[2]; /// создаем изначально массив для 2 записей
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Число записей в ежедневнике (количество)
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Поля

        /// <summary>
        /// Массив всех записей
        /// </summary>
        private Note[] notes;
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string Path;
        /// <summary>
        /// Порядковый номер записи
        /// </summary>
        int index;
        /// <summary>
        /// База данных имён
        /// </summary>
        static readonly string[] firstNames;
        /// <summary>
        /// База данных фамилий
        /// </summary>
        static readonly string[] lastNames;
        /// <summary>
        /// База данных случайных заметок
        /// </summary>
        static readonly string[] rng_notice;
        /// <summary>
        /// Готовность записи
        /// </summary>
        static readonly string[] rng_check;
        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random randomize;

        #endregion

        #region Методы

        /// <summary>
        /// Добавление записи в ежедневник
        /// </summary>
        /// <param name="new_note">Новая запись в ежедневник</param>
        public void Add_note(Note new_note)
        {
            this.Resize(index >= this.notes.Length); /// проверка на необходимость увеличения массива
            this.notes[index] = new_note; /// добавляем новую запись в ежедневник
            this.index++; /// увеличиваем индекс
        }

        /// <summary>
        /// Удаление записи по заданному id (номеру заметки)
        /// </summary>
        /// <param name="id">Порядковый номер заметки</param>
        public void Delete_note(int id)
        {
            List<Note> noteList = new List<Note>(this.notes); /// представляем запись в виде списка
            noteList.Remove(notes[id - 1]); /// удаляем запись
            this.notes = noteList.ToArray(); /// преобразуем запись обратно в массив
            this.index--; /// уменьшаем индекс

        }

        /// <summary>
        /// Изменение в записи телефона, даты, заметки и статуса
        /// </summary>
        /// <param name="id">Номер записи</param>
        /// <param name="phone">Номер телефона</param>
        /// <param name="date">Дата записи</param>
        /// <param name="notice">Заметка</param>
        /// <param name="check">Статус</param>
        public void Change_note(int id, string phone = "", DateTime date = default(DateTime), string notice = "", string check = "")
        {
            if (phone != "")
            this.notes[id-1].Phone = phone;
            if (date != default(DateTime))
            this.notes[id-1].Date = date;
            if (notice != "")
            this.notes[id-1].Notice = notice;
            if (check != "")
            this.notes[id-1].Check = check;
        }

        /// <summary>
        /// Увеличения массива с записями в ежедневнике
        /// </summary>
        /// <param name="Flag">Проверка на необходимость</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.notes, this.notes.Length * 2); /// увеличиваем в два раза
            }
        }

        /// <summary>
        /// Возвращает случайную дату в заданном диапазоне
        /// </summary>
        /// <returns></returns>
        private DateTime RandomDay()
        {
            DateTime start = new DateTime(2022, 1, 1); /// начальное время
            DateTime end = new DateTime(2022, 12, 30); /// конечное время
            int range = (end - start).Days; /// вычитаем и получаем необходимый диапазон
            return start.AddDays(randomize.Next(range)); /// возвращаем случайную дату в заданном диапазоне
        }

        /// <summary>
        /// Создание всех записей в дневнике
        /// </summary>
        /// <param name="Path">Путь к имени файла</param>
        public void Create_diary(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                /// создаем необходимое количество случайных записей в ежедневник
                this.Add_note(new Note(
                        i,
                        lastNames[Diary.randomize.Next(Diary.lastNames.Length)],
                        firstNames[Diary.randomize.Next(Diary.firstNames.Length)],
                        $"8-9{randomize.Next(1, 999999999).ToString("00-000-00-00")}",
                        RandomDay(),
                        rng_notice[Diary.randomize.Next(Diary.rng_notice.Length)],
                        rng_check[Diary.randomize.Next(Diary.rng_check.Length)]
                        ));
            }
        }

        /// <summary>
        /// Печатает в консоле все записи из ежедневника
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{"№",3} | {"Фамилия",12} | {"Имя",12} | {"Номер телефона",15} | {"Дата",18} | {"Заметка",35} | {"Готовность",5}");

            for (int i = 0; i < 122; ++i)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            for (int i = 0; i < index; ++i)
            {
                Console.WriteLine(this.notes[i].Print());
            }
        }

        /// <summary>
        /// Возвращает все записи
        /// </summary>
        /// <returns></returns>
        private string GetAllNotes()
        {
            string allNotes = String.Empty;

            for (int i = 0; i < index; ++i)
            {
                allNotes += $"{this.notes[i].Print()}\n"; /// заполняем строчку записями
            }

            allNotes = allNotes.TrimEnd(); /// удаляем последний переход на новую строчку
            return allNotes;
        }

        /// <summary>
        /// Выгрузка всех записей в файл
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public void Unload_diary(string Path)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine($"{"№",3} | {"Фамилия",12} | {"Имя",12} | {"Номер телефона",15} | {"Дата",18} | {"Заметка",35} | {"Готовность",5}");

                for (int i = 0; i < 122; ++i)
                {
                    sw.Write("-");
                }
                sw.Write("\n" + GetAllNotes());
            }
        }

        /// <summary>
        /// Импорт записей по выбранному диапазону дат
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        public void LoadByDate(string Path, DateTime startDate, DateTime endDate)
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                sr.ReadLine();
                sr.ReadLine(); /// пропускаем первые две строчки

                while (!sr.EndOfStream)
                {
                    char[] separators = new char[] { '|' };
                    string[] args = sr.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries); /// читаем и разделяем строку, а также убираем пустые строчки из массива

                    for (int i = 0; i < args.Length; ++i)
                    {
                        args[i] = args[i].Trim(); /// удаляем ненужные пробелы
                    }
                     
                    args[0] = Convert.ToString(Count); /// номер записи
                    DateTime date = Convert.ToDateTime(args[4]);

                    if (date >= startDate && date <= endDate) /// проверка по датам
                    {
                        this.Add_note(new Note(Convert.ToInt32(args[0]), args[1], args[2], args[3], Convert.ToDateTime(args[4]), args[5], args[6])); /// добавляем новую запись
                        Count++;
                    }
                }
            }
        }

        /// <summary>
        /// Загрузка записей из файла
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public void Load_diary(string Path)
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                sr.ReadLine();
                sr.ReadLine(); /// пропускаем первые две строчки

                while (!sr.EndOfStream)
                {
                    char[] separators = new char[] { '|' }; /// знаки разделители
                    string[] args = sr.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries); /// читаем и разделяем строку, а также убираем пустые строчки из массива

                    for (int i = 0; i < args.Length; ++i)
                    {
                        args[i] = args[i].Trim(); /// удаляем ненужные пробелы
                    }

                    args[0] = Convert.ToString(Count); /// номер записи
                    this.Add_note(new Note(Convert.ToInt32(args[0]), args[1], args[2], args[3], Convert.ToDateTime(args[4]), args[5], args[6])); /// добавляем новую запись
                    Count++;
                }
            }
        }

        /// <summary>
        /// Добавление к существующему ежедневнику всех записей из другого ежедневника по указанному пути
        /// </summary>
        /// <param name="Path">Путь к исходному ежедневнику</param>
        /// <param name="choosePath">Путь к ежедневнику откуда нужно взять записи</param>
        public void Add_diary(string Path, string choosePath)
        {
            this.Count = Count; /// даем значение счетчику, чтобы нумерация записей была верной
            //Load_diary(Path); /// загржуаем данные из исходного ежедневника
            Load_diary(choosePath); /// загружаем и добавляем данные из второго ежедневника 
            Unload_diary(Path); /// выгружаем новые данные в исходный ежедневник
        }

        /// <summary>
        /// Сортировка записей по желанию
        /// </summary>
        /// <param name="path">Путь выгрузки файла</param>
        public void Sort(string path)
        {
            Console.WriteLine("\nВыберите вариант сортировки:\n" +
                "1. Фамилии по возрастанию\n" +
                "2. Фамилии по убыванию\n" +
                "3. Дата по возрастанию\n" +
                "4. Дата по убыванию\n" +
                "5. Сначала сделанные дела\n" +
                "6. Сначала не сделанные дела");
            int ans = Convert.ToInt32(Console.ReadLine());

            switch (ans) /// вызовы соотвествующих функций
            {
                case 1:
                    Array.Sort(notes);
                    break;
                case 2:
                    Array.Sort(notes, Note.SortLastnameDescending());
                    break;
                case 3:
                    Array.Sort(notes, Note.SortDateAscending());
                    break;
                case 4:
                    Array.Sort(notes, Note.SortDateDescending());
                    break;
                case 5:
                    Array.Sort(notes, Note.SortCheckReady());
                    break;
                case 6:
                    Array.Sort(notes, Note.SortCheckNotReady());
                    break;
                default:
                    break;
            }

            for (int i = notes.Length - 1; i >= 0; i--) /// удаление лишних строк (исправление багов)
            {
                if (notes[i].LastName == null)
                {
                    Delete_note(i + 1);
                    index++;
                }
            }
            Unload_diary(path);
        }

        #endregion
    }
}
