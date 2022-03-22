using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organization org = new Organization(50, 5); /// Создаем новую организацию на 50 человек и 5 отделов
            Organization org2 = new Organization(50, 5);
            Organization org3 = new Organization(50, 5);

            org.PrintToConsoleWorkers(); /// выведим информацию о сотрудниках на экран
            Console.WriteLine('\n');
            org.PrintToConsoleDepts(); /// выведим информацию о департаментах на экран

            org.SerializeXml("Test.xml"); /// сериализация xml
            org.SerializeJson("Test2.json"); /// сериализация json

            org.Sort(); /// сортировка по полю или нескольким полям
            Console.WriteLine("\nОтсортированный список:\n");
            org.PrintToConsoleWorkers(); /// выведим отсортированный список
            
            org2.DeserializeXml("Test.xml"); /// десериализация xml
            Console.WriteLine("\nСписок взятый из xml файла:\n");
            org2.PrintToConsoleWorkers();   /// 
            Console.WriteLine('\n');        /// выведем всю информацию и увидим, что десериализация произошла успешна, иначе значения org2 отличались бы
            org2.PrintToConsoleDepts();     ///

            /// проделаем тоже самое для json
            org3.DeserializeXml("Test.xml"); /// десериализация json
            Console.WriteLine("\nСписок взятый из json файла:\n");
            org3.PrintToConsoleWorkers();   /// 
            Console.WriteLine('\n');        /// выведем всю информацию и увидим, что десериализация произошла успешна, иначе значения org3 отличались бы
            org3.PrintToConsoleDepts();     /// 
        }
    }
}
