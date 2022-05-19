using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWork4
{
    internal class HomeWork4
    {
        // ls
        static List<int> ls0 = new List<int> { 999, 65, -58, 96, -666, -666, -61, -94, 62, 999 };
        static ArrayList arrLs = new ArrayList() { null, ls0 };
        static int arrLsInd = 1;
        static List<int> arrLsObj = (List<int>)arrLs[arrLsInd];
        // other
        static bool inLoop;
        static void Main(string[] args)
        {
            while (true)
            {
                inLoop = true;
                Console.Clear();
                Console.Write($"Values: ");
                arrLsObj = (List<int>)arrLs[arrLsInd];
                WriteValue(arrLsObj);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Set ArrayList index");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Get min");
                Console.WriteLine("4. Get max");
                Console.WriteLine("5. Get sum");
                Console.WriteLine("6. Get average");
                Console.WriteLine("7. ASC sort");
                Console.WriteLine("8. DESC sort");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Select an option number: ");
                var select = Console.ReadLine();

                switch (select)
                {
                    default:
                        {
                            InvalidValue();
                            break;
                        }
                    case "0": // Exit
                        {
                            Console.WriteLine();
                            Console.WriteLine("Closing...");
                            return;
                        }
                    case "1": // Set ArrayList index
                        {
                            while (inLoop)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Indexes count: {arrLs.Count - 1}");
                                Console.Write("Select an index number: ");
                                var indexStr = Console.ReadLine();
                                SetArrayListIndex(indexStr);
                            }
                            break;
                        }
                    case "2": // Search
                        {
                            while (inLoop)
                            {
                                Console.WriteLine();
                                Console.Write("Value to search: ");
                                var valueStr = Console.ReadLine();
                                SearchValue(valueStr);
                            }
                            break;
                        }
                    case "3": // Get min
                        {
                            Console.WriteLine();
                            var min = GetMinValue(arrLsObj);
                            Console.Write($"Min: {min}");
                            Console.ReadKey(true);
                            break;
                        }
                    case "4": // Get max
                        {
                            Console.WriteLine();
                            var max = GetMaxValue(arrLsObj);
                            Console.Write($"Max: {max}");
                            Console.ReadKey(true);
                            break;
                        }
                    case "5": // Get sum
                        {
                            Console.WriteLine();
                            var sum = GetSumValue(arrLsObj);
                            Console.Write($"Sum: {sum}");
                            Console.ReadKey(true);
                            break;
                        }
                    case "6": // Get average
                        {
                            Console.WriteLine();
                            var avg = GetAverageValue(arrLsObj);
                            var formated = string.Format("{0:0.00}", avg);
                            Console.Write($"Average: {formated}");
                            Console.ReadKey(true);
                            break;
                        }
                    case "7": // ASC sort
                        {
                            ASCsort(arrLsObj);
                            break;
                        }
                    case "8": // DESC sort
                        {
                            DESCsort(arrLsObj);
                            break;
                        }
                }
            }
        }
        static void WriteValue(List<int> list)
        {
            foreach (var value in list)
            {
                Console.Write($"{value}; ");
            }
        }
        static void InvalidValue()
        {
            Console.Write("Invalid value!");
            Console.ReadKey(true);
            Console.WriteLine();
        }
        static void SetArrayListIndex(string indexStr)
        {
            if (int.TryParse(indexStr, out int index) && index < arrLs.Count && index > 0)
            {
                arrLsInd = index;
                inLoop = false;
            }
            else
            {
                InvalidValue();
            }
        }
        static void SearchValue(string valueStr)
        {
            var count = 0;

            if (int.TryParse(valueStr, out int value))
            {
                for (var i = 0; i < arrLsObj.Count; i++)
                {
                    if (arrLsObj[i] == value)
                    {
                        count++;
                        Console.WriteLine($"({value}) matches index [{i}]");
                    }
                }
                if (count == 0)
                {
                    arrLsObj.Insert(0, value);
                    Console.Write($"No matches, ({value}) inserted index [0]!");
                }
                Console.ReadKey(true);
                inLoop = false;
            }
            else
            {
                InvalidValue();
            }
        }
        static int GetMinValue(List<int> list)
        {
            var min = list[0];

            foreach (var value in list)
            {
                if (value <= min)
                {
                    min = value;
                }
            }
            return min;
        }
        static int GetMaxValue(List<int> list)
        {
            var max = list[0];
            var count = 0;

            foreach (var value in list)
            {
                if (value >= max)
                {
                    max = value;
                    count++;
                }
            }
            return max;
        }
        static int GetSumValue(List<int> list)
        {
            var sum = 0;
            var count = 0;

            foreach (var value in list)
            {
                sum += value;
                count++;
            }
            return sum;
        }
        static float GetAverageValue(List<int> list)
        {
            float sum = 0;
            var count = 0;

            foreach (var value in list)
            {
                sum += value;
                count++;
            }
            return sum / count;
        }
        static void ASCsort(List<int> list)
        {
            for (var i = 1; i < list.Count; i++)
            {
                for (var j = i; j > 0 && list[j - 1] > list[j]; j--)
                {
                    (list[j - 1], list[j]) = (list[j], list[j - 1]);
                }
            }
        }
        static void DESCsort(List<int> list)
        {
            for (var i = 1; i < list.Count; i++)
            {
                for (var j = i; j > 0 && list[j - 1] < list[j]; j--)
                {
                    (list[j - 1], list[j]) = (list[j], list[j - 1]);
                }
            }
        }
    }
}