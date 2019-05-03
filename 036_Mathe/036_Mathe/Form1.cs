using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _036_Mathe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public override string ToString()
        {
            return $"Mein String ist: {base.ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ToString());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Mathe.Faculty(i)}");
            }
            Console.WriteLine($"{Mathe.Sum(1, 2, 3, 4, 5)}");
        }
    }
}
