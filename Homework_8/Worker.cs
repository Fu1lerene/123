using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_8
{
    /// <summary>
    /// Работяга
    /// </summary>
    public class Worker
    {
        public Worker()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id">Уникальный номер рабочего</param>
        /// <param name="Firstname">Имя</param>
        /// <param name="Lastname">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Dept">Отдел, закрепленный за рабочим</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="NumberOfProjects">Количество проектов</param>
        public Worker(int id, string firstname, string lastname, int age, string dept, int salary, int numberOfProjects)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Dept = dept;
            this.Salary = salary;
            this.NumberOfProjects = numberOfProjects;
        }

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
        public int Salary { get; set; }
        /// <summary>
        /// Количество проектов
        /// </summary>
        public int NumberOfProjects { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Вывод информации о рабочем
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{Id,5} {Firstname,10} {Lastname,15} {Age,10} {Dept,15} {Salary,15} {NumberOfProjects,20}";
        }

        #endregion
    }
}
