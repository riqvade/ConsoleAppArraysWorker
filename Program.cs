using System;

namespace ConsoleAppArraysWorker
{
    class Program
    {
        public static void Main(string[] args)
        {
            ArrayWorker arrayWorker = new ArrayWorker();

            int secondMaxNumber = arrayWorker.GetSecondMaxNumber();

            Console.WriteLine($"Наибольший второй элемент массива равен: {secondMaxNumber}");

            Console.ReadLine();
        }
    }
}
