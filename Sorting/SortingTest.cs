using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    public static class SortingTest
    {
        public static void Test()
        {
            TestSelectionSort();
            TestInsertionSort();
            TestShellSort();
        }

        private static void TestSelectionSort()
        {
            TestSort(new SelectionSort(), "selection");
        }

        private static void TestInsertionSort()
        {
            TestSort(new InsertionSort(), "insertion");
        }

        private static void TestShellSort()
        {
            TestSort(new ShellSort(), "shell");
        }

        private static void TestSort(ISortStrategy strategy, string sortName)
        {
            Console.WriteLine($"{sortName} sort test");
            Console.WriteLine("-------------------");

            IComparable[] array = GetTestCharArray();
            array.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            array.Sort(strategy);
            stopwatch.Stop();

            array.Print();

            Console.WriteLine("-------------------");
            Console.WriteLine("Time: " + stopwatch.Elapsed);
            Console.WriteLine("-------------------");

            Debug.Assert(array.IsSorted());
        }

        private static IComparable[] GetTestCharArray()
        {
            return "QUITEEXCELLENTSORTTESTWITHOUTREPEATINGLETTERS"
                .ToCharArray()
                .Distinct()
                .Select(e => e as IComparable)
                .Where(e => e != null)
                .ToArray();
        }
    }
}