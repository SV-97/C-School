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

namespace _023_Dateizugriff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"\File";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(123);
                sw.WriteLine("Example Text");
                sw.Write("On the same line");
            }
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine("");
                sw.WriteLine("Appended");
            }
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() != -1)
                {
                    textBox1.Text += sr.ReadLine() + "\r\n";
                }
            
            textBox2.Text = File.ReadAllText(path);
            
        }
    }
}
