using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Homework_8
{
    /// <summary>
    /// Организация
    /// </summary>
    internal class Organization
    {
        /// <summary>
        /// Конструктор создания организации
        /// </summary>
        /// <param name="NumberOfWorkersAll">Количество всех работников</param>
        /// <param name="NumberOfDepts">Количество отделов в организации</param>
        public Organization(int numberOfWorkersAll, int numberOfDepts)
        {
            this.NumberOfDepts = numberOfDepts;
            this.NumberOfWorkersAll = numberOfWorkersAll;
            depts = new List<Department>();
            workers = new List<Worker>();
            rng = new Random();
            CreateDepts();
        }

        #region Свойства

        /// <summary>
        /// Общее количество сотрудников
        /// </summary>
        public int NumberOfWorkersAll { get; set; }
        /// <summary>
        /// Количество отделов в организации
        /// </summary>
        public int NumberOfDepts { get; set; }

        #endregion

        #region Поля

        /// <summary>
        /// Список отделов
        /// </summary>
        private List<Department> depts;
        /// <summary>
        /// Список рабочих
        /// </summary>
        private List<Worker> workers;
        /// <summary>
        /// Случайное число
        /// </summary>
        private Random rng;

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает случайную дату в заданном диапазоне
        /// </summary>
        /// <returns></returns>
        private DateTime RandomDay()
        {
            DateTime start = new DateTime(2010, 1, 1); /// начальное время
            DateTime end = new DateTime(2022, 12, 31); /// конечное время
            int range = (end - start).Days; /// вычитаем и получаем необходимый диапазон
            return start.AddDays(rng.Next(range)); /// возвращаем случайную дату в заданном диапазоне
        }

        /// <summary>
        /// Создание отделов
        /// </summary>
        private void CreateDepts()
        {
            int index = 1; /// номер рабочего для корректного создания и вывода списка
            int numbWorkers = NumberOfWorkersAll / NumberOfDepts + NumberOfWorkersAll % NumberOfDepts; /// количество рабочих в одном отделе с остатком

            for (int i = 1; i < NumberOfDepts + 1; ++i)
            {
                depts.Add(new Department(
                            $"Отдел_{i}",
                            RandomDay(),
                            numbWorkers,
                            CreateWorkers(i, numbWorkers, index)));

                index += numbWorkers; /// увеличение номера на количество рабочих в отдном отделе
                numbWorkers = NumberOfWorkersAll / NumberOfDepts; /// количество рабочих в одном отделе без остатка
            }
        }

        /// <summary>
        /// Создание рабочих
        /// </summary>
        /// <param name="k">Номер отдела</param>
        /// <param name="numbWorkers">Количество рабочих в отделе</param>
        /// <param name="index">Номер рабочего</param>
        /// <returns></returns>
        private List<Worker> CreateWorkers(int k, int numbWorkers, int index)
        {
            for (int i = index; i < numbWorkers + index; ++i)
            {
                workers.Add(new Worker(
                    i,
                    $"Имя_{i}",
                    $"Фамилия_{i}",
                    rng.Next(20, 46),
                    $"Отдел_{k}",
                    rng.Next(50, 150) * 1000,
                    rng.Next(1, 6)));
            }

            return workers.GetRange(index - 1, numbWorkers); /// возвращаем список рабочих в необходимом диапазоне
        }

        /// <summary>
        /// Вывод информации об отделе
        /// </summary>
        public void PrintToConsoleDepts()
        {
            Console.WriteLine($"{"Название",10} {"Дата создания",15} {"Количество сотрудников",25}");
            foreach (var item in depts)
            {
                Console.WriteLine(item.Print());
            }
        }

        /// <summary>
        /// Вывод информации о рабочих
        /// </summary>
        public void PrintToConsoleWorkers()
        {
            Console.WriteLine($"{"№",5} {"Имя",10} {"Фамилия",15} {"Возраст",10} {"Департамент",15} {"Оплата труда",15} {"Количество проектов",20}");
            foreach (var item in workers)
            {
                Console.WriteLine(item.Print());
            }
        }

        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        private void SortByAge()
        {
            foreach (var item in workers)
                workers = workers.OrderBy(x => x.Age).ToList();
        }

        /// <summary>
        /// Сортировка по оплате труда
        /// </summary>
        private void SortBySalary()
        {
            foreach (var item in workers)
                workers = workers.OrderBy(x => x.Salary).ToList();
        }

        /// <summary>
        /// Сортировка по отделам
        /// </summary>
        private void SortByDept()
        {
            foreach (var item in workers)
                workers = workers.OrderBy(x => x.Dept).ToList();
        }

        /// <summary>
        /// Сортировка по количеству проектов
        /// </summary>
        private void SortByProject()
        {
            foreach (var item in workers)
                workers = workers.OrderBy(x => x.NumberOfProjects).ToList();
        }

        /// <summary>
        /// Сортировка на выбор
        /// </summary>
        public void Sort()
        {
            Console.WriteLine("\nВыберите вариант сортировки:\n" +
               "1. По возрасту\n" +
               "2. По оплате труда\n" +
               "3. По количеству проектов\n" +
               "4. По возрасту и оплате труда\n" +
               "5. По возрасту и оплате труда в рамках одного отдела\n" +
               "6. По возрасту, количеству проектов и оплате труда");
            int ans = Convert.ToInt32(Console.ReadLine());

            switch (ans) /// вызовы соотвествующих функций
            {
                case 1:
                    SortByAge();
                    break;
                case 2:
                    SortBySalary();
                    break;
                case 3:
                    SortByProject();
                    break;
                case 4:
                    SortBySalary();
                    SortByAge();
                    break;
                case 5:
                    SortBySalary();
                    SortByDept();
                    SortByAge();
                    break;
                case 6:
                    SortBySalary();
                    SortByProject();
                    SortByAge();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Сериализация Xml (экспорт)
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void SerializeXml(string path)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Department>));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write); /// Создаем поток для сохранения данных
             
            xmlSer.Serialize(fStream, depts); /// Запускаем процесс сериализации
            fStream.Close(); /// Закрываем поток
        }

        /// <summary>
        /// Десериализация Xml (импорт)
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public void DeserializeXml(string Path)
        {
            List<Department> tempD = new List<Department>();
            XmlSerializer xmlDeserD = new XmlSerializer(typeof(List<Department>));
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read); /// Создаем поток для чтения данных

            tempD = xmlDeserD.Deserialize(fStream) as List<Department>; /// Запускаем процесс десериализации
            fStream.Close(); /// Закрываем поток

            depts = tempD;

            /// Присваиваем значения workers из прочитанного файла
            int k = 0;
            for (int i = 0; i < depts.Count; ++i)
            {
                for (int j = 0; j < workers.Count / NumberOfDepts; ++j)
                {
                    workers[k] = depts[i].Workers[j];
                    k++;
                }
            }
        }

        /// <summary>
        /// Сериализация json (экспорт)
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void SerializeJson(string path)
        {
            string json = JsonConvert.SerializeObject(depts);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Десериализация Json (импорт)
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void DeserializeJson(string path)
        {
            string json = File.ReadAllText(path);
            depts = JsonConvert.DeserializeObject<List<Department>>(json);

            /// Присваиваем значения workers из прочитанного файла
            int k = 0;
            for (int i = 0; i < depts.Count; ++i)
            {
                for (int j = 0; j < workers.Count / NumberOfDepts; ++j)
                {
                    workers[k] = depts[i].Workers[j];
                    k++;
                }
            }
        }

        #endregion
    }
}
