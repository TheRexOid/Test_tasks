using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.Json.Serialization;

namespace task3
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // Переменные, которые хранят пути к файлам
            string file_path_tests = null;
            string file_path_values = null;

            // Проверяем наличие аргументов, если есть то записываем, если нет, завершаем программу
            if (args.Length < 2)
            {
                Console.WriteLine("Arguments not found!");
                Environment.Exit(1);
            }
            else
            {
                file_path_tests = args[0];
                file_path_values = args[1];
            }

            // Десериализуем JSON-файлы, а после с помощью рекурсивной функции совершаем обход и подставляет значения
            string json_tests = File.ReadAllText(file_path_tests);
            string json_values = File.ReadAllText(file_path_values);

            RootobjectTests testsObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootobjectTests>(json_tests);
            RootobjectValues valuesObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootobjectValues>(json_values);

            var mainObj = new Program();
            mainObj.FindID(testsObject.tests, valuesObject.values);

            var jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            string json_report = JsonSerializer.Serialize(testsObject, jsonOptions);
            File.WriteAllText("report.json", json_report);
        }

        void FindID(Test[] arrayTests, Value[] arrayValues)
        {
            if (arrayTests != null && arrayValues != null)
            {
                for (int i = 0; i < arrayTests.Length; i++)
                {
                    for (int y = 0; y < arrayValues.Length; y++)
                    {
                        if (arrayValues[y].id == arrayTests[i].id)
                        {
                            arrayTests[i].value = arrayValues[y].value;
                            break;
                        }                        
                    }
                    if (arrayTests[i].values != null)
                    {
                        FindID(arrayTests[i].values, arrayValues);
                    }
                }
            }            
        }
    }
}