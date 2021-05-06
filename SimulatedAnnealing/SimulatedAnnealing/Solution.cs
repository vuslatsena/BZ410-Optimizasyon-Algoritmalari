using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealing
{
   public class Solution:ICloneable
    {
        public double[] solutionString;
        public double objVal=0;
        public Solution(int dim)
        {
            solutionString = new double[dim];
        }
        public object Clone()
        {
            Solution i1 = new Solution(this.solutionString.Length);
            i1.objVal = this.objVal;
            for(int i=0;i<this.solutionString.Length;i++)
            {
                i1.solutionString[i] = this.solutionString[i];
            }
            return i1;
        }
        public void ObjValCalculate()
        {
            double sum = 0;
            for(int i=0;i<this.solutionString.Length;i++)
            {
                sum += this.solutionString[i] * this.solutionString[i];
            }
            this.objVal = sum;
        }
        public Solution GenerateNeighbor(Random rn, double lb, double ub)
        {
            double lbN = lb * 0.1;
            double ubN = ub * 0.1;
            Solution k = (Solution)this.Clone();
            for(int i=0;i<this.solutionString.Length;i++)
            {
                double r = lbN + rn.NextDouble() * (ubN - lbN);
                k.solutionString[i] = k.solutionString[i] + r;
                if (k.solutionString[i] < lb)
                    k.solutionString[i] = lb;
                else if (k.solutionString[i] > ub)
                    k.solutionString[i] = ub;
            }
            return k;
        }
    }
}
