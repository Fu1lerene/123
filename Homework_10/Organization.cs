using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace Homework_10
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        
        public Organization(string name = "Empty")
        {
            Name = name;
            depts = new List<Department>();
            workers = new List<Worker>();
            rng = new Random();
            Level = 1;
            /// создание организации как отдела с единственным директором
            depts.Add(new Department(
                Name,
                RandomDay(),
                1,
                0,
                CreateDirector()));

            CreateDepts();
        }

        public Organization() : this("")
        {
        }

        #region Свойства

        /// <summary>
        /// Название организации
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Уровень (глубина отделов в организации)
        /// </summary>
        private int Level { get; set; }
        /// <summary>
        /// Случайное число
        /// </summary>
        private Random rng { get; set; }
        /// <summary>
        /// Список отделов
        /// </summary>
        public List<Department> depts { get; set; }
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public List<Worker> workers { get; set; }

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
        /// Создание директора компании
        /// </summary>
        /// <returns></returns>
        private List<Worker> CreateDirector()
        {
            workers.Add(new Worker(
                "Александр",
                "Ковалев",
                "Директор",
                0,
                22,
                $"{Name}",
                0,
                100500));

            return workers.GetRange(0, 1);
        }

        /// <summary>
        /// Создание всех отделов
        /// </summary>
        private void CreateDepts()
        {
            int index = 1; /// индекс, показывающий с какого сотрудника стоит начать 
            int tempLevel = rng.Next(3, 6) + 1; /// случайное количество уровней в создании отделов

            for (int j = Level; j < tempLevel; Level++, j++) /// цикл идущий по уровням
            {
                int tempDept = rng.Next(2, 6) + 1; /// случайное количество отделов в каждом из уровней

                for (int i = 1; i < tempDept; ++i) /// цикл идущий по отделам
                {
                    int tempWorkers = rng.Next(3, 6); /// случайное количество сотрудников, числящихся в каждом из отделов

                    depts.Add(new Department(
                        $"Отдел_{Level}_{i}",
                        RandomDay(),
                        tempWorkers,
                        Level,
                        CreateWorkers(i, index, tempWorkers, Level)));

                    index += tempWorkers; /// добавляем к индексу количество сотрудников в каждом из отделов
                }
            }
        }

        /// <summary>
        /// Рассчет зарплаты начальникам каждого отдела
        /// </summary>
        /// <param name="tempWorkers">Количество рабочих в отделе</param>
        /// <param name="iDDept">Номер отдела</param>
        /// <param name="index">Индекс сотрудника, с которого начинаем</param>
        private void PaySalary(int tempWorkers, int iDDept, int index)
        {
            double salary = 0;
            int rngHours;

            for (int i = index; i < tempWorkers + index; ++i) /// цикл идущий по всем работникам в рамках одного отдела
            {
                if (workers[i].Dept == $"Отдел_{Level}_{iDDept}" && workers[i].Position == "Интерн") /// если сотрудник интерн
                {
                    salary += workers[i].Salary; /// запоминаем его зарплату
                    workers[0].Salary += workers[i].Salary; /// прибавляем эту зарплату директору
                }

                if (workers[i].Dept == $"Отдел_{Level}_{iDDept}" && workers[i].Position == "Специалист") /// если сотрудник специалист
                {
                    rngHours = rng.Next(160, 221); /// количество рабочих часов случайно 160-220
                    salary += workers[i].Salary * rngHours; /// рассчитываем зарплату за месяц (т.к. изначально она дана в виде $**/час)
                    workers[0].Salary += workers[i].Salary * rngHours; /// прибавляем эту зарплату директору
                }

                if (workers[i].Dept == $"Отдел_{Level}_{iDDept}" && workers[i].Position == "Начальник") /// если начальник
                {
                    if (salary * 0.3 <= 1300) /// если 30% от зарплат всех сотрудников в данном отделе меньше, чем $1300
                        workers[i].Salary = 1300; /// выдаем минимальную зарплату в $1300
                    else workers[i].Salary = salary * 0.3; /// иначе начальник получает эти 30%
                }
            }
        }

        /// <summary>
        /// Создание рабочих
        /// </summary>
        /// <param name="k">Номер отдела</param>
        /// <param name="numbWorkers">Количество рабочих в отделе</param>
        /// <param name="index">Номер рабочего</param>
        /// <returns></returns>
        private List<Worker> CreateWorkers(int IDDept, int index, int numbOfWorkers, int lvlDept)
        {
            
            for (int i = numbOfWorkers; i >= 1; --i) /// цикл для создания сотрудников в текущем отделе
            {
                string pos = i == 1 ? "Начальник" : (i <= numbOfWorkers/2+1 ? "Специалист" : "Интерн"); /// выдача должностей (всегда 1 начальник, и примерно поровну остальных)
                int salary = i == 1 ? 0 : (i <= numbOfWorkers / 2 + 1 ? rng.Next(10, 20) : rng.Next(500, 751)); /// выдача зарплат специалистам и интернам случайным образом
                int IDWorker = workers[0].GetStaticId(); /// текущий номер сотрудника

                workers.Add(new Worker(
                    $"Имя_{IDWorker}",
                    $"Фамилия_{IDWorker}",
                    pos,
                    lvlDept,
                    rng.Next(20, 46),
                    $"Отдел_{lvlDept}_{IDDept}",
                    salary,
                    rng.Next(1, 6)));
            }

            PaySalary(numbOfWorkers, IDDept, index);

            return workers.GetRange(index, numbOfWorkers); /// возвращаем список рабочих в необходимом диапазоне
        }

        /// <summary>
        /// Вывод информации об отделе
        /// </summary>
        public void PrintToConsoleDepts()
        {
            Console.WriteLine($"{"Название",10} {"Дата создания",15} {"Количество сотрудников",25} {"Уровень", 10}");
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
            Console.WriteLine($"{"№",5} {"Имя",10} {"Фамилия",15} {"Должность", 15} {"Уровень", 10} {"Возраст",10} {"Департамент",15} {"Оплата труда",15} {"Количество проектов",20}");
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
               "5. По возрасту, количеству проектов и оплате труда");
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
                    SortByProject();
                    SortByAge();
                    break;
                default:
                    break;
            }
        }

        public void DeleteWorker(int i)
        {
            
        }

        #endregion
    }
}
