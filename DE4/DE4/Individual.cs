using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE4
{
    public class Individual:ICloneable
    {
        public double[] solString;
        public double objVal = 0;
        public Individual(int dim)
        {
            solString = new double[dim];
        }
        public object Clone()
        {
            Individual i1 = new Individual(this.solString.Length);
            i1.objVal = this.objVal;
            for(int i=0;i<this.solString.Length;i++)
            {
                i1.solString[i] = this.solString[i];
            }

            return i1;
        }

        public void ObjValCalculate()
        {
            double total = 0;
            for(int i = 0; i < this.solString.Length; i++)
            {
                total += this.solString[i] * this.solString[i];
            }

            this.objVal = total;
        }

        public void MutAndRecomb(Individual[] pop, int current, Random rn, double LB, double UB, double CR, double F)
        {
            int r1 = rn.Next(0, pop.Length);
            while(r1==current)
            {
                r1 = rn.Next(0, pop.Length);
            }
            int r2 = rn.Next(0, pop.Length);
            while (r2 == current || r2==r1)
            {
                r2 = rn.Next(0, pop.Length);
            }
            int r3 = rn.Next(0, pop.Length);
            while (r3 == current || r3==r1 || r3==r2)
            {
                r3 = rn.Next(0, pop.Length);
            }

            int indJ = rn.Next(0, this.solString.Length);

            for (int i = 0; i < this.solString.Length;i++)
            {
                if(rn.NextDouble()<CR || indJ==i)
                {
                    this.solString[i] = pop[r3].solString[i] + F * (pop[r1].solString[i] - pop[r2].solString[i]);
                    if (this.solString[i] < LB)
                        this.solString[i] = LB;
                    else if (this.solString[i] > UB)
                        this.solString[i] = UB;
                }
            }
        }
    }
}
