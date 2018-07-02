using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _017_ÜbungSchA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct DasStruct
        {
            public double[] dim1;
            public double[,] dim2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            textBox3.Text = Convert.ToString(Convert.ToInt32(a) + Convert.ToInt32(b));
            StreamReader sr = new StreamReader(@"D:\Git Repos\C-School\017_ÜbungSchA\017_ÜbungSchA\Archive.txt");
            string c = sr.ReadToEnd();
            sr.Dispose();
            using (StreamWriter sw = new StreamWriter(@"D:\Git Repos\C-School\017_ÜbungSchA\017_ÜbungSchA\Archive.txt"))
            {
                sw.Write(c);
                sw.WriteLine(string.Format("{0}+{1}={2}", a, b, textBox3.Text));
            }

            DasStruct strct = new DasStruct();
            strct.dim1 = new double[] { 1.0, 2.0, 4.0 };
            for (int i = 0; i < strct.dim1.Length; i++)
            {
                Console.WriteLine(strct.dim1[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
        }
    }
}
