using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _011_Statistik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] vals = new double[1000];
        int iterator = 0;
        double sum = 0.0;
        double max = 0.0;
        double min = 0.0;

        private void button1_Click(object sender, EventArgs e)
        {
            vals[iterator] = Convert.ToDouble(textBox1.Text);
            iterator++;

            sum = 0.0;
            for (int i = 0; i < iterator+1; i++)
            {
                sum += vals[i];
            }


            for (int i = 0; i < iterator+1; i++)
            {
                if (vals[i] > max)
                {
                    max = vals[i];
                }
                if (vals[i] < min)
                {
                    min = vals[i];
                }
            }

            Update_Output();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = 0.0;
            }
            Update_Output();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = 0;
            }
            sum = 0.0;
            iterator = 0;
            Update_Output();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Update_Output()
        {
            textBox2.Text = Convert.ToString(iterator);
            textBox3.Text = Convert.ToString(sum);
            textBox4.Text = Convert.ToString(sum / iterator);
            textBox5.Text = Convert.ToString(max);
            textBox6.Text = Convert.ToString(min);
            textBox7.Text = "";
            for (int i = 0; i < iterator + 1; i++)
            {
                textBox7.Text += Convert.ToString(vals[i]) + "\r\n";
            }
        }

        private void SortAscending()
        {
            double workval = 0;
            bool sorted = false;
            do
            {
                sorted = false;
                for (int i = 0; i < iterator; i++)
                {
                    if (vals[i + 1] < vals[i])
                    {
                        workval = vals[i];
                        vals[i] = vals[i + 1];
                        vals[i + 1] = workval;
                        sorted = true;
                    }
                }
            } while (sorted);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SortAscending();
            Update_Output();
        }
    }
}
