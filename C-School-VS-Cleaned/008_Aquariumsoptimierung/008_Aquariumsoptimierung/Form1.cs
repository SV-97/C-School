using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _008_Aquariumsoptimierung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double a = 0.0;
            double a_squared = 0.0;
            double current_val = 0.0;
            double next_val = 0.0;

            do
            {
                a += 0.001 * l;
                a_squared = Math.Pow(a,2.0);
                current_val = next_val;
                next_val = -2.0 * a_squared * (-2.0 * a + l + b) + l * b * a;
                //next_val = (l-2.0*a)*(b-2.0*a)*a;
            } while (next_val > current_val);

            label1.Text = Convert.ToString(Math.Round(current_val));
            label2.Text = " mit a= " + Convert.ToString(Math.Round(a));

            current_val = 0.0;
            a = 0.0;
            double i_squared;
            int iterationen_durch = 0;
            int iterationen_max = 1000;
            bool first_max = true;

            for (double i = 0; i < (b+l)/2; i+=(b+l)/(2*iterationen_max))
            {
                i_squared = Math.Pow(i, 2.0);
                next_val = -2.0 * i_squared * (-2.0 * i + l + b) + l * b * i;
                if (next_val >= current_val)
                {
                    if (first_max)
                    {
                        current_val = next_val;
                        a = i;
                        iterationen_durch++;
                    }
                }
                else
                {
                    first_max = false;
                }
            }

            label3.Text = Convert.ToString(Math.Round(current_val));
            label4.Text = " mit a= " + Convert.ToString(Math.Round(a));
            label5.Text = " nach " + Convert.ToString(iterationen_durch) + " von " + Convert.ToString(iterationen_max) + " Iterationen"

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
