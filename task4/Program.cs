using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Переменные, которые хранят пути к файлам
            string file_path_list = null;

            // Проверяем наличие аргументов, если есть то записываем, если нет, завершаем программу
            if (args.Length < 1)
            {
                Console.WriteLine("Arguments not found!");
                Environment.Exit(1);
            }
            else file_path_list = args[0];

            List list_nums = new List(file_path_list); // Создаём масссив и считываем данные из файла 
            list_nums.AverageCalc(); // Находим элемент к которому будем приводить все остальные
            list_nums.SearchMoves(); // Подсчитываем кол-во шагов и выводим
        } 
    }

    public class List // Класс массива, который хранит все элементы и их кол-во, а также считывает данные из файла при создании объекта
    {
        public int[] array; // Массив
        public int count; // Кол-во элементов в массиве
        int index_cell; // Индекс элемента, к которому нужно привести все остальные

        public List(string path) // Конструктор класса, который считывает исходный массив
        {
            StreamReader reader = new StreamReader(path);
            count = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                count++;
            }
            array = new int[count];
            reader.BaseStream.Position = 0;
            for (int i = 0; i < count; i++)
            {
                string line = reader.ReadLine();
                array[i] = Convert.ToInt16(line);
            }
            reader.Close();
        }

        public void AverageCalc() // Метод поиска среднего значения и вычисление самого близкого к нему элемента массива
        {
            float average = 0;
            for (int i = 0; i < count; i++)
            {
                average += array[i];
            }
            average /= count;
            float difference = Math.Abs(array[0] - average);
            index_cell = 0;
            for (int i = 1; i < count; i++)
            {
                if (Math.Abs(array[i] - average) < difference)
                {
                    difference = Math.Abs(array[i] - average);
                    index_cell = i;
                }
            }
        }

        public void SearchMoves() // Метод поиска минимального кол-ва шагов для приведения всех элементов к одному значению
        {
            bool sameness = false; // Одинаковость всех элементов
            int number_steps = 0;
            while (!sameness)
            {
                sameness = true;
                for (int i = 0; i < count; i++)
                {
                    if (array[i] > array[index_cell])
                    {
                        array[i]--;
                        number_steps++;
                    }
                    else if (array[i] < array[index_cell])
                    {
                        array[i]++;
                        number_steps++;
                    }
                    if (array[i] != array[index_cell]) sameness = false;
                }
            }
            Console.WriteLine(number_steps); // Выводим кол-во шагов 
        }
    }
}