using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    /// <summary>
    /// Отдел
    /// </summary>
    public class Department
    {
        public Department()
        {

        }

        /// <summary>
        /// Создание нового отдела
        /// </summary>
        /// <param name="name">Название отдела</param>
        /// <param name="dateOfCreation">Дата создания</param>
        /// <param name="numberOfWorkers">Количество сотрудников</param>
        /// <param name="lvl">Уровень в организации</param>
        /// <param name="workers">Список сотрудников</param>
        public Department(string name, DateTime dateOfCreation, int numberOfWorkers, int lvl, List<Worker> workers)
        {
            Name = name;
            DateOfCreation = dateOfCreation;
            NumberOfWorkers = numberOfWorkers;
            Workers = workers;
            Lvl = lvl;
        }

        #region Свойства

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Количество рабочих
        /// </summary>
        public int NumberOfWorkers { get; set; }
        /// <summary>
        /// Список рабочих
        /// </summary>
        public List<Worker> Workers { get; set; }
        /// <summary>
        /// Уровень (глубина отделов в организации)
        /// </summary>
        public int Lvl { get; set; }


        #endregion

        #region Методы

        /// <summary>
        /// Вывод информации об отделе
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{Name,10} {DateOfCreation.ToString("d"),15} {NumberOfWorkers,25} {Lvl, 10}";
        }

        #endregion
    }
}
