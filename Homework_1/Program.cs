using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базы данных из 20 сотрудников
            Repository repository = new Repository(30);

            // Печать в консоль всех сотрудников
            repository.Print("База данных до преобразования");

            // Увольнение всех работников с именем "Агата"
            repository.DeleteWorkerByName("Агата");

            // Печать в консоль сотрудников, которые не попали под увольнение
            repository.Print("База данных после первого преобразования");

            // Увольнение всех работников с именем "Аделина"
            repository.DeleteWorkerByName("Аделина");

            // Печать в консоль сотрудников, которые не попали под увольнение
            repository.Print("База данных после второго преобразования");

            /// Задание 1

            //Repository repository = new Repository(20);

            /// Задание 2

            //Repository repository = new Repository(40);
            //repository.DeleteWorkerByName("Аделина");
            //repository.DeleteWorkerByName("Агата");
            //repository.DeleteWorkerByName("Алима");

            /// Задание 3
            
            //Repository repository = new Repository(50);
            //repository.DeleteWorkerBySalary(30_000);
        }
    }
}
