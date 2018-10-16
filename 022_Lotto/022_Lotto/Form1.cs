using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _022_Lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] bubblesort(int[] input)
        {
            List<int> list_1 = new List<int> { };
            list_1.AddRange(input);
            List<int> sortiert = new List<int> { };
            while (list_1.Count() > 1)
            {
                for (int i = list_1.Count()-1; i > 0; i--)
                {
                    int r = list_1[i];
                    int l = list_1[i - 1];
                    if (r < l)
                    {
                        list_1[i] = l;
                        list_1[i - 1] = r;
                    }
                    if (i == 1)
                    {
                        sortiert.Add(list_1[0]);
                        list_1.RemoveAt(0);
                    }
                }
            }
            sortiert.Add(list_1[0]);
            list_1.RemoveAt(0);
            int[] output = new int[sortiert.Count()];
            for (int i = 0; i < sortiert.Count(); i++)
            {
                output[i] = sortiert[i];
            }
            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Random rnd = new Random(); //0 - 49
            int[] zahlen = new int[6];
            for (int i = 0; i < zahlen.Length; i++)
            {
                do
                {
                    int zahl = rnd.Next(0, 49);
                    if (!zahlen.Contains(zahl))
                    {
                        zahlen[i] = zahl;
                        break;
                    }
                } while (true);
            }

            zahlen = bubblesort(zahlen);
            foreach (var zahl in zahlen)
            {
                textBox1.Text += zahl.ToString() + "\r\n";
            }
        }
    }
}
