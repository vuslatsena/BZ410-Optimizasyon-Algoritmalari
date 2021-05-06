using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DE4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int FindBest(Individual[] pop)
        {
            double k = pop[0].objVal;
            int index = 0;
            for(int i=0;i<pop.Length;i++)
            {
                if(k>pop[i].objVal)
                {
                    k = pop[i].objVal;
                    index = i;
                }
            }
            return index;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            int NP = Convert.ToInt32(textBox1.Text);
            int MaxGen = Convert.ToInt32(textBox2.Text);
            double LB = Convert.ToDouble(textBox3.Text);
            double UB = Convert.ToDouble(textBox4.Text);
            double F = Convert.ToDouble(textBox5.Text);
            double CR = Convert.ToDouble(textBox6.Text);
            int runNum = Convert.ToInt32(textBox7.Text);
            int dim = Convert.ToInt32(textBox8.Text);

            double[] runBests = new double[runNum];
            for(int i=0;i<runNum;i++)
            {
                Individual[] pop = new Individual[NP];
                Individual[] popNext = new Individual[NP];

                for(int k=0;k<NP;k++)
                {
                    Individual i1 = new Individual(dim);
                    for(int j=0;j<dim;j++)
                    {
                        i1.solString[j] = LB + rn.NextDouble() * (UB - LB);
                    }
                    i1.ObjValCalculate();
                    popNext[k] =(Individual) i1.Clone();
                }
                for(int c=0;c<MaxGen;c++)
                {
                    for(int k=0;k<NP;k++)
                    {
                        pop[k] = (Individual) popNext[k].Clone();
                    }
                    for(int k=0;k<NP;k++)
                    {
                        Individual uInd = (Individual) pop[k].Clone();
                        uInd.MutAndRecomb(pop, k, rn, LB, UB, CR, F);
                        uInd.ObjValCalculate();
                        if (uInd.objVal <= pop[k].objVal)
                            popNext[k] = (Individual)uInd.Clone();
                        else
                            popNext[k] = (Individual) pop[k].Clone();
                    }

                }
                int indis = FindBest(popNext);
                runBests[i] = popNext[indis].objVal;

            }

            richTextBox1.Text += "**************\r\n";
            for(int i=0;i<runNum;i++)
            {
                richTextBox1.Text += runBests[i] + "\r\n";
            }
        }
    }
}
