using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Homework_8
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
        /// Конструктор
        /// </summary>
        /// <param name="Name">Название</param>
        /// <param name="DateOfCreation">Дата создания</param>
        /// <param name="NumberOfWorkers">Количество рабочих в отделе</param>
        /// <param name="Workers">Список рабочих</param>
        public Department(string name, DateTime dateOfCreation, int numberOfWorkers, List<Worker> workers)
        {
            this.Name = name;
            this.DateOfCreation = dateOfCreation;
            this.NumberOfWorkers = numberOfWorkers;
            this.Workers = workers;
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

        #endregion

        #region Методы

        /// <summary>
        /// Вывод информации об отделе
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.Name,10} {this.DateOfCreation.ToString("d"),15} {this.NumberOfWorkers,25}";
        }

        #endregion
    }
}
