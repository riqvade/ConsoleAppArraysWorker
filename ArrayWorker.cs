using System;

namespace ConsoleAppArraysWorker
{
    internal class ArrayWorker
    {

        public ArrayWorker()
        {

        }

        /// <summary>
        /// Возвращает второй элемент массива, длина и значения которого задаются через консоль
        /// </summary>
        public int GetSecondMaxNumber()
        {
            int arrayLength = GetArrayLengthThroughConsole();
            int[] ArrayOfNumbers = GetArrayContentThroughConsole(arrayLength);
            return GetSecondMaxNumberFromArray(ArrayOfNumbers);
        }

        /// <summary>
        /// Возвращает необходимую длину массива, введенную через консоль
        /// </summary>
        private int GetArrayLengthThroughConsole()
        {
            while (true)
            {
                int number;
                Console.WriteLine("Введите длину массива:");
                string input = Console.ReadLine();
                Console.WriteLine();


                bool result = int.TryParse(input, out number);
                if (result == true)
                {
                    switch (number)
                    {
                        case 0:
                            Console.WriteLine("Ошибка. Введенное значение должно быть больше 0");
                            Console.WriteLine();
                            continue;
                        case 1:
                            Console.WriteLine("Ошибка. Введенное значение должно быть больше 1");
                            Console.WriteLine();
                            continue;
                    }

                    return number;
                }
                else
                {
                    Console.WriteLine("Операция не выполнена. Необходимо ввести целое число");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Возвращает массив целых чисел, введенные через консоль
        /// </summary>
        private int[] GetArrayContentThroughConsole(int arrayLength)
        {
            while (true)
            {
                Console.WriteLine($"Введите целые числа через пробел в колличестве {arrayLength} шт");

                string input = Console.ReadLine();
                Console.WriteLine();

                string[] Numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (Numbers.Length < arrayLength || Numbers.Length > arrayLength)
                {
                    Console.WriteLine($"Операция не выполнена. Колличество введенных чисел отличается от заданного");
                    continue;
                }

                int[] resultArray = new int[arrayLength];

                bool notNumbers = false;
                for (int i = 0; i < Numbers.Length; i++)
                {
                    int number;
                    bool result = int.TryParse(Numbers[i], out number);
                    if (result == true)
                    {
                        resultArray[i] = number;
                    }
                    else
                    {
                        Console.WriteLine($"Введено некорректное значение массива: {Numbers[i]}");
                        Console.WriteLine();
                        notNumbers = true;
                        continue;
                    }
                }
                if (notNumbers == true)
                {
                    continue;
                }

                int theSameNumbers = 1;
                for (int i = resultArray.Length - 1; i > 0; i--)
                {
                    if (resultArray[i - 1] == resultArray[i])
                    {
                        theSameNumbers++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (theSameNumbers == resultArray.Length)
                {
                    Console.WriteLine("Ошибка, в массив введены одинаковые числа");
                    Console.WriteLine();
                    continue;
                }

                return resultArray;
            }
        }

        /// <summary>
        /// Возвращает второе максимальное число из массива целых чисел
        /// </summary>
        private int GetSecondMaxNumberFromArray(int[] ArrayOfNumbers)
        {
            int temp;
            for (int i = 0; i < ArrayOfNumbers.Length - 1; i++)
            {
                for (int j = i + 1; j < ArrayOfNumbers.Length; j++)
                {
                    if (ArrayOfNumbers[i] > ArrayOfNumbers[j])
                    {
                        temp = ArrayOfNumbers[i];
                        ArrayOfNumbers[i] = ArrayOfNumbers[j];
                        ArrayOfNumbers[j] = temp;
                    }
                }
            }

            int offset = 2;
            for (int i = ArrayOfNumbers.Length - 1; i > 0 ; i--)
            {
                if (ArrayOfNumbers[i - 1] == ArrayOfNumbers[i])
                {
                    offset++;
                }
                else
                {
                    break;
                }
            }

            return ArrayOfNumbers[ArrayOfNumbers.Length - (offset)];
        }
    }
}