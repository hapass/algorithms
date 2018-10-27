using System;
using System.Collections.Generic;

namespace Permutations
{
    class PermutationComparer : IEqualityComparer<IComparable[]>
    {
        public bool Equals(IComparable[] x, IComparable[] y)
        {
            if(x.Length != y.Length)
            {
                return false;
            }

            for(int i = 0; i < x.Length; i++)
            {
                if(x[i].CompareTo(y[i]) != 0) 
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(IComparable[] obj)
        {
            return obj.GetHashCode();
        }
    }
}