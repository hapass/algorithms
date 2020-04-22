// using System;
// using System.Linq;
// using Xunit;
// using Tools;

// namespace Sorting
// {
//     public class SortingTest
//     {
//         [Fact]
//         public void InsertionSortSortsArray()
//         {
//             var testCollection = GetTestCharArray();
//             var sort = new InsertionSort();

//             sort.Sort(testCollection);

//             Assert.True(testCollection.IsSorted());
//         }

//         [Fact]
//         public void ShellSortSortsArray()
//         {
//             var testCollection = GetTestCharArray();
//             var sort = new ShellSort();
//             sort.Sort(testCollection);

//             Assert.True(testCollection.IsSorted());
//         }

//         private static IComparable[] GetTestCharArray()
//         {
//             return "QUITEEXCELLENTSORTTESTWITHOUTREPEATINGLETTERS"
//                 .ToCharArray()
//                 .Distinct()
//                 .Select(e => e as IComparable)
//                 .Where(e => e != null)
//                 .ToArray();
//         }
//     }
// }