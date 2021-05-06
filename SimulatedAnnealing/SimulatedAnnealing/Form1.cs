using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatedAnnealing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            int dim = Convert.ToInt32(textBox1.Text);
            double lb = Convert.ToDouble(textBox2.Text);
            double ub = Convert.ToDouble(textBox3.Text);
            double t = Convert.ToDouble(textBox4.Text);
            double alpha = Convert.ToDouble(textBox5.Text);
            int maxIter = Convert.ToInt32(textBox6.Text);
            string result = "f(x)=\r\n";
            Solution current = new Solution(dim);
            for(int i=0;i<dim;i++)
            {
                current.solutionString[i] = lb + rn.NextDouble() * (ub - lb);
            }
            current.ObjValCalculate();
            result += "0: " + current.objVal.ToString() + "\r\n";
            for(int i=0;i<maxIter;i++)
            {
                Solution neighbor = current.GenerateNeighbor(rn, lb, ub);
                neighbor.ObjValCalculate();
                double delta = neighbor.objVal - current.objVal;
                if (delta < 0 || (rn.NextDouble()<=Math.Pow(Math.E,(-delta/t))))
                    current = (Solution)neighbor.Clone();
                result += (i+1).ToString()+ ": " + current.objVal.ToString() + "\r\n";
                t = t * alpha;
            }
            richTextBox1.Text = result;
        }
    }
}
