using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsılİslemAlgoritmasi
{
   public class Solution:ICloneable
    {
        public double [] solutionString;
        public double objVal = 0;

        public Solution(int dim)
        {
            solutionString = new double[dim];
        }
    }
}
