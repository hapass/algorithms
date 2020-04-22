// using System;
// using System.Collections.Generic;

// namespace Permutations
// {
//     class PermutationComparer<T> : IEqualityComparer<T[]> where T : IComparable
//     {
//         public bool Equals(T[] x, T[] y)
//         {
//             if(x.Length != y.Length)
//             {
//                 return false;
//             }

//             for(int i = 0; i < x.Length; i++)
//             {
//                 if(x[i].CompareTo(y[i]) != 0) 
//                 {
//                     return false;
//                 }
//             }

//             return true;
//         }

//         public int GetHashCode(T[] obj)
//         {
//             return obj.GetHashCode();
//         }
//     }
// }