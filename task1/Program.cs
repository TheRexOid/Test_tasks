using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number_array = 0; // N - размерность кольцевого массива (По умолчанию равен нулю)
            int step_size = 0; // M - размер шага (По умолчанию равен нулю)

            // Проверяем наличие аргументов
            if (args.Length < 2)
            {
                Console.WriteLine("Arguments not found!");
                Environment.Exit(1);
            }
            else
            {
                // Переводим значения аргументов из строчного типа в цельночисловой
                number_array = Convert.ToInt16(args[0]);
                step_size = Convert.ToInt16(args[1]);
            }

            // Создаём и заполняем кольцевой массив
            RingArray array = new RingArray();
            for (int i = 0; i < number_array; i++)
            {
                array.AddLast(i + 1);
            }

            // Задаём выходное значение из цикла
            int exit_number = -1;

            // Задаём начальный элемент обхода и буффер обхода
            Cell current = array.Head;
            int[] step_list = new int[step_size];

            // Выполняем обход по массиву и выводим первый элемент из буффера каждого обхода
            while (exit_number != 1)
            {
                for(int i = 0; i < step_size; i++)
                {
                    step_list[i] = current.Data;
                    if (i != step_size-1)
                    {
                        current = current.Next;
                    }
                }
                exit_number = current.Data;
                Console.Write(step_list[0]);
            }
        }
    }

    // Класс элемента массива, объект которого хранит собственное значение и последующий эллемент
    public class Cell
    {
        public int Data { get; set; }
        public Cell Next { get; set; }

        public Cell(int data)
        {
            this.Data = data;
        }
    }

    // Класс кольцевого массива, объект которого будет хранить первый и последний элементы массива, а также количество элементов
    public class RingArray
    {
        public Cell Head = null; // Голова списка
        public Cell Tail = null; // Хвост списка

        // Создание нового элемента 
        public void AddLast(int data)
        {
            // Если первого эллемента ещё не существует, вызываем функцию AddFirst()
            if (Head == null)
                this.AddFirst(data);
            else
            {
                Cell newNode = new Cell(data);
                Tail.Next = newNode;
                newNode.Next = Head;
                Tail = newNode;
            }
        }

        // Создание первого элемента
        void AddFirst(int data)
        {
            Head = new Cell(data);
            Tail = Head;
            Head.Next = Tail;
        }
    }
}