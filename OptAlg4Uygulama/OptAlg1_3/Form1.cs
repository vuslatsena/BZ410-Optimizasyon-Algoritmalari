using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptAlg1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double[] GradyentHesapla(double[] x)
        {
            double[] g = new double[2];
            g[0] = 2 * x[0] - 2 * x[1];
            g[1] = 2 * x[1] - 2 * x[0];
            return g;
        }

        public double GenlikHesapla(double[] g)
        {
            double genlik = Math.Sqrt(g[0] * g[0] + g[1] * g[1]);
            return genlik;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double[] x = new double[2];
            x[0] = Convert.ToDouble(textBox1.Text);
            x[1]= Convert.ToDouble(textBox2.Text);
            double alpha= Convert.ToDouble(textBox3.Text);
            double epsilon= Convert.ToDouble(textBox4.Text);
            double[] d = new double[2];
            double[] g = GradyentHesapla(x);

            int sayac = 0;

            while(GenlikHesapla(g) > epsilon)
            {
                d[0] = -1 * g[0];
                d[1] = -1 * g[1];

                x[0] = x[0] + alpha * d[0];
                x[1] = x[1] + alpha * d[1];

                sayac++;
                g = GradyentHesapla(x);
            }

            string sonuc = "x[1]= " + x[0].ToString() + "\r\nx[2]= " + x[1].ToString() + "\r\niterasyon= " + sayac.ToString();
            richTextBox1.Text = sonuc;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] x = new double[2];
            x[0] = Convert.ToDouble(textBox1.Text);
            x[1] = Convert.ToDouble(textBox2.Text);
            double alpha = Convert.ToDouble(textBox3.Text);
            double epsilon = Convert.ToDouble(textBox4.Text);
            double[] d = new double[2];
            double[] g = GradyentHesapla(x);
            double genlikOnceki = 0;
            int sayac = 0;

            while (GenlikHesapla(g) > epsilon)
            {
                if(sayac == 0)
                { 
                    d[0] = -1 * g[0];
                    d[1] = -1 * g[1];
                }
                else
                {
                    double beta = Math.Pow((GenlikHesapla(g) / genlikOnceki), 2);
                    d[0] = -1 * g[0] + beta * d[0];
                    d[1] = -1 * g[1] + beta * d[1];
                }
                

                x[0] = x[0] + alpha * d[0];
                x[1] = x[1] + alpha * d[1];

                sayac++;
                genlikOnceki = GenlikHesapla(g);
                g = GradyentHesapla(x);
            }

            string sonuc = "x[1]= " + x[0].ToString() + "\r\nx[2]= " + x[1].ToString() + "\r\niterasyon= " + sayac.ToString();
            richTextBox2.Text = sonuc;
        }
    }
}
