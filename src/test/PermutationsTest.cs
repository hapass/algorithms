// using System;
// using System.Linq;
// using Xunit;

// namespace Permutations
// {
//     public class PermutationsTest
//     {
//         [Fact]
//         public void GeneratesPermutationsCorrectly()
//         {
//             var testCollection = Permutation(0, 1, 2);

//             var permutations = testCollection.GeneratePermutations();

//             Assert.Equal(SimpleFactorial(testCollection.Length), permutations.Count);
//             Assert.Contains(Permutation(0, 1, 2), permutations, new PermutationComparer<int>());
//             Assert.Contains(Permutation(0, 2, 1), permutations, new PermutationComparer<int>());
//             Assert.Contains(Permutation(1, 0, 2), permutations, new PermutationComparer<int>());
//             Assert.Contains(Permutation(1, 2, 0), permutations, new PermutationComparer<int>());
//             Assert.Contains(Permutation(2, 0, 1), permutations, new PermutationComparer<int>());
//             Assert.Contains(Permutation(2, 1, 0), permutations, new PermutationComparer<int>());
//         }

//         private static T[] Permutation<T>(params T[] permutation)
//         {
//             return permutation;
//         }

//         private static int SimpleFactorial(int n)
//         {
//             return n <= 1 ? 1 : n * SimpleFactorial(--n);
//         }
//     }
// }