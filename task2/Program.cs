using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Переменные, которые хранят пути к файлам
            string file_path_сircles = null;
            string file_path_points = null;

            // Проверяем наличие аргументов, если есть то записываем, если нет, завершаем программу
            if (args.Length < 2)
            {
                Console.WriteLine("Arguments not found!");
                Environment.Exit(1);
            }
            else
            {
                file_path_сircles = args[0];
                file_path_points = args[1];
            }

            // Создаём окружность и точки и считываем данные из файлов
            Circle circle = new Circle(file_path_сircles);
            Points points = new Points(file_path_points);

            // Расчитываем растояние от центра окружности до точки и сравниваем с радиусом окружности 
            for(int i = 0; i < points.count; i++)
            {
                double distance = Math.Sqrt(Math.Pow(circle.x - points.x[i], 2) + Math.Pow(circle.y - points.y[i], 2));
                if(distance == circle.radius) Console.WriteLine("0");
                else if(distance < circle.radius) Console.WriteLine("1");
                else Console.WriteLine("2"); 
            }
        }
    }
    public class Circle // Класс окружности, который хранит координаты центра и радиус, а также считывает данные из файла при создании объекта
    {
        public float x, y;
        public float radius;

        public Circle(string path)
        {
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();

            string[] splitLine = line.Split(' ');

            x = float.Parse(splitLine[0]);
            y = float.Parse(splitLine[1]);

            line = reader.ReadLine();

            radius = Convert.ToInt16(line);
            reader.Close();
        }
    }

    public class Points // Класс точек, который содержит массивы координат и кол-во точек, а также считывает данные из файла при создании объекта.
    {
        public float[] x, y;
        public int count;

        public Points(string path)
        {
            StreamReader reader = new StreamReader(path);
            count = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                count++;
            }
            x = new float[count];
            y = new float[count];
            reader.BaseStream.Position = 0;
            for (int i = 0; i < count; i++)
            {
                string line = reader.ReadLine();

                string[] splitLine = line.Split(' ');

                x[i] = Convert.ToSingle(splitLine[0]);
                y[i] = Convert.ToSingle(splitLine[1]);
            }
            reader.Close();
        }
    }
}