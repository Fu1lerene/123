using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Homework_7
{
    /// <summary>
    /// Записи в ежедневнике
    /// </summary>
    public struct Note : IComparable
    {
        /// <summary>
        /// Конструктор создания ежедневника для работы
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <param name="firstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="phone">Номер телефона</param>
        /// <param name="date">Дата записи</param>
        /// <param name="note">Заметка</param>
        /// <param name="check">Статус</param>
        public Note(int id, string lastName, string firstName, string phone, DateTime date, string notice, string check)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Phone = phone;
            this.Date = date;
            this.Notice = notice;
            this.Check = check;
        }

        #region Классы

        /// <summary>
        /// Класс для сортировки по имени по убыванию
        /// </summary>
        private class SortLastnameDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Note c1 = (Note)a;
                Note c2 = (Note)b;
                return String.Compare(c2.LastName, c1.LastName);
            }
        }

        /// <summary>
        /// Класс для сортировки по дате по возрастанию
        /// </summary>
        private class SortDateAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Note c1 = (Note)a;
                Note c2 = (Note)b;
                return -DateTime.Compare(c2.Date, c1.Date);
            }
        }

        /// <summary>
        /// Класс для сортировки по дате по убыванию
        /// </summary>
        private class SortDateDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Note c1 = (Note)a;
                Note c2 = (Note)b;
                return DateTime.Compare(c2.Date, c1.Date);
            }
        }

        /// <summary>
        /// Класс для сортировки, сначала выполненные записи
        /// </summary>
        private class SortCheckReadyHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Note c1 = (Note)a;
                Note c2 = (Note)b;
                return String.Compare(c2.Check, c1.Check);
            }
        }

        /// <summary>
        /// Класс для сортировки, сначала не выполненные записи
        /// </summary>
        private class SortCheckNotReadyHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Note c1 = (Note)a;
                Note c2 = (Note)b;
                return -String.Compare(c2.Check, c1.Check);
            }
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод, который сравнивает текущий экземпляр с другим объектом того же типа и возвращает целое число
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            Note c = (Note)obj;
            return String.Compare(this.LastName, c.LastName);
        }
        
        /// <summary>
        /// Метод для сортировки по имени по убыванию
        /// </summary>
        /// <returns></returns>
        public static IComparer SortLastnameDescending()
        {
            return (IComparer)new SortLastnameDescendingHelper();
        }

        /// <summary>
        /// Метод для сортировки по дате по возрастанию
        /// </summary>
        public static IComparer SortDateAscending()
        {
            return (IComparer)new SortDateAscendingHelper();
        }

        /// <summary>
        /// Метод для сортировки по дате по убыванию
        /// </summary>
        public static IComparer SortDateDescending()
        {
            return (IComparer)new SortDateDescendingHelper();
        }

        /// <summary>
        /// Метод для сортировки, сначала выполненные записи
        /// </summary>
        /// <returns></returns>
        public static IComparer SortCheckReady()
        {
            return (IComparer)new SortCheckReadyHelper();
        }

        /// <summary>
        /// Метод для сортировки, сначала не выполненные записи
        /// </summary>
        /// <returns></returns>
        public static IComparer SortCheckNotReady()
        {
            return (IComparer)new SortCheckNotReadyHelper();
        }

        /// <summary>
        /// Вывод записи из ежедневника
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.Id + 1,3} | {this.LastName,12} | {this.FirstName,12} | {this.Phone,15} | {this.Date.ToString("M"),15} {this.Date.ToString("ddd")} | {this.Notice,35} | {this.Check,5}";
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Дата и время записи
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Заметка
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// Статус выполенения
        /// </summary>
        public string Check { get; set; }

        #endregion

        
    }
}
