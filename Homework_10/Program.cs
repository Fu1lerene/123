using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Homework_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Создание организаций со случайным количеством отделов и сотрудников
            //Organization organization = new Organization("Excalibur");
            //Organization org2 = new Organization("Fullerene");
            //Organization org3 = new Organization("OAO Coding");

            // Вывод всей информации до сортировки и после
            //organization.PrintToConsoleDepts();
            //organization.PrintToConsoleWorkers();
            //organization.Sort();
            //organization.PrintToConsoleWorkers();

            /// Пример сериализации в json файл
            //string jsonString = JsonSerializer.Serialize(organization);
            //File.WriteAllText("Excalibur.json", jsonString);

            //string jsonString = JsonSerializer.Serialize(org2);
            //File.WriteAllText("Fullerene.json", jsonString);

            //string jsonString = JsonSerializer.Serialize(org3);
            //File.WriteAllText("OAO Coding.json", jsonString);

            /// Десериализация
            //string json = File.ReadAllText("Test.json");
            //Organization org = JsonSerializer.Deserialize<Organization>(json);
        }
    }
}
