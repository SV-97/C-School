using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _003_Zähler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 val;
            val = Convert.ToInt64(textBox1.Text);
            textBox1.Text = Convert.ToString(++val);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int64 val;
            val = Convert.ToInt64(textBox1.Text);
            textBox1.Text = Convert.ToString(--val);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!(textBox2.Text == "") && !(textBox3.Text == ""))
            {
                double val1;
                double val2;
                double val3;

                textBox2.Text.Replace(".", ",");
                textBox3.Text.Replace(".", ",");

                val1 = Convert.ToDouble(textBox2.Text);
                val2 = Convert.ToDouble(textBox3.Text);
                val3 = val1 / val2;
                label2.Text = "= " + val3.ToString("f3");
            }
            else
            {
                label2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!(textBox2.Text == "") && !(textBox3.Text == ""))
            {
                double val1;
                double val2;
                double val3;

                textBox2.Text.Replace(".", ",");
                textBox3.Text.Replace(".", ",");

                val1 = Convert.ToDouble(textBox2.Text);
                val2 = Convert.ToDouble(textBox3.Text);
                val3 = val1 / val2;
                label2.Text = "= " + val3.ToString("f3");
            }
            else
            {
                label2.Text = "";
            }
        }
    }
}
