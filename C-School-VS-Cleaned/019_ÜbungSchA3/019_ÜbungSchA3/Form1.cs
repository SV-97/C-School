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

namespace _019_ÜbungSchA3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader sr1;
        StreamReader sr2;
        StreamWriter sw1;
        StreamWriter sw2;
        string[] lines1;
        string[] lines2;
        string path1 = @"D:\Git Repos\C-School\019_ÜbungSchA3\MyFile.txt";
        string path2 = @"D:\Git Repos\C-School\019_ÜbungSchA3\MyFile_Copy.txt";

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sr1 = new StreamReader(path1);
            sr2 = new StreamReader(path2);
            string line1 = sr1.ReadToEnd();
            string line2 = sr2.ReadToEnd();
            lines1 = line1.Replace("\r", "").Split('\n');
            lines2 = line2.Replace("\r", "").Split('\n');
            sr1.Dispose();
            sr2.Dispose();
            int position = Convert.ToInt32(textBox2.Text);
            using (sw2 = new StreamWriter(new FileStream(path2, FileMode.Append)))
            {
                sw2.WriteLine(lines1[position]);
            }
            List<string> lines_new = new List<string>();
            for (int i = 0; i < lines1.Length; i++)
            {
                if(i != position)
                {
                    lines_new.Add(lines1[i]);
                }
            }
            using (sw1 = new StreamWriter(path1))
            {
                for (int i = 0; i < lines_new.Count; i++)
                {
                    sw1.WriteLine(lines_new[i]);
                }
            }
        }
            //sr2 = File.AppendText(@"Pfad: D:\Git Repos\C-School\019_ÜbungSchA3\MyFile_Copy.txt");
        private void button2_Click(object sender, EventArgs e)
        {
            sr1 = new StreamReader(path1);
            sr2 = new StreamReader(path2);
            string line1 = sr1.ReadToEnd();
            string line2 = sr2.ReadToEnd();
            lines1 = line1.Replace("\r", "").Split('\n');
            lines2 = line2.Replace("\r", "").Split('\n');
            sr1.Dispose();
            sr2.Dispose();
            int position = Convert.ToInt32(textBox3.Text);
            using (sw1 = new StreamWriter(new FileStream(path1, FileMode.Append)))
            {
                sw1.WriteLine(lines2[position]);
            }            
            List<string> lines_new = new List<string>();
            for (int i = 0; i < lines2.Length; i++)
            {
                if(i != position)
                {
                    lines_new.Add(lines2[i]);
                }
            }
            using (sw2 = new StreamWriter(path2))
            {
                for (int i = 0; i < lines_new.Count; i++)
                {
                    sw2.WriteLine(lines_new[i]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
