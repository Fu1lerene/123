using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Worker
    {
        public Worker()
        {

        }

        /// <summary>
        /// Создание нового сотрудника
        /// </summary>
        /// <param name="id">Уникальный номер сотрудника</param>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        /// <param name="position">Должность</param>
        /// <param name="lvl">Уровень в организации</param>
        /// <param name="age">Возраст</param>
        /// <param name="dept">Отдел</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="numberOfProjects">Количество проектов</param>
        public Worker(string firstname, string lastname, string position, int lvl, int age, string dept, double salary, int numberOfProjects)
        {
            Id = Worker.NextId();
            Firstname = firstname;
            Lastname = lastname;
            Position = position;
            Age = age;
            Dept = dept;
            Salary = salary;
            NumberOfProjects = numberOfProjects;
            Lvl = lvl;
        }

        /// <summary>
        /// Статический конструктор
        /// </summary>
        static Worker()
        {
            staticId = 0;
        }

        /// <summary>
        /// Статическое поле staticId
        /// </summary>
        private static int staticId;

        #region Свойства

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Отдел, закрепленный за рабочим
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// Уникальный номер рабочего
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public double Salary { get; set; }
        /// <summary>
        /// Количество проектов
        /// </summary>
        public int NumberOfProjects { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Уровень сотрудника в организации
        /// </summary>
        public int Lvl { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Вывод информации о рабочем
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            if (Position == "Специалист")
                return $"{Id,5} {Firstname,10} {Lastname,15} {Position, 15} {Lvl, 10} {Age,10} {Dept,15} {$"${Salary}/час",15} {NumberOfProjects,20}";
            else if (Position == "Интерн")
                return $"{Id,5} {Firstname,10} {Lastname,15} {Position,15} {Lvl,10} {Age,10} {Dept,15} {$"${Salary}",15} {NumberOfProjects,20}";
            else return $"{Id,5} {Firstname,10} {Lastname,15} {Position,15} {Lvl,10} {Age,10} {Dept,15} {$"${Salary}",15} {NumberOfProjects,20}";
        }

        /// <summary>
        /// Статический метод возвращающий следующие Id
        /// </summary>
        /// <returns></returns>
        private static int NextId()
        {
            staticId++;
            return staticId;
        }

        /// <summary>
        /// Метод, позволяющий получить текущее значение staticId
        /// </summary>
        /// <returns></returns>
        public int GetStaticId()
        {
            return staticId;
        }

        #endregion
    }
}
