using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsılİslemAlgoritmasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
