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
using System.Threading;

namespace _025_Versuchslabor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool state = false;
        Thread management;
        private static object lockObject = new object(); // not necessary because button_1 click can't execute while TimeManagement is running

        private void SwitchState()
        {
            button1.Enabled = !button1.Enabled;
            button2.Enabled = !button2.Enabled;
            textBox1.Enabled = !textBox1.Enabled;
        }
        
        private void TimeManagement(int manr, string path)
        {
            int duration = 0;
            DateTime t1 = DateTime.Now;
            while (state)
            {
                if (DateTime.Now.Subtract(t1).TotalSeconds >= 2)
                {
                    t1 = DateTime.Now;
                    duration++;
                }
            }

            Double time = Convert.ToDouble(duration * 0.5);
            string time_string = $"{time:0.0}".Replace(',', '.');
            lock (lockObject)
            {
                using (StreamWriter sw = new StreamWriter(path, append: true))
                {
                    sw.WriteLine($"{manr} {DateTime.Now.ToString("dd.mm.yyyy")} {time_string}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            state = true;
            SwitchState();
            int manr = Convert.ToInt32(textBox1.Text);
            double time_counter = 0.0;
            const string path = @"C:\Users\volzs\Documents\GitHub\C-School\025_Versuchslabor\025_Versuchslabor\dauer.txt";
            lock (lockObject)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        string[] elements = line.Split(' ');
                        if (Convert.ToInt32(elements[0]) == manr)
                        {
                            elements[2] = elements[2].Replace('.', ',');
                            time_counter += Convert.ToDouble(elements[2]);
                        }
                    }
                }
            }
            
            if (time_counter > 25.0)
            {
                textBox2.Text = "Zugang verweigert! Gehen Sie zum Betriebsarzt!";
            }
            else
            {
                textBox2.Text = $"Restaufenthaltsdauer: {25.0 - time_counter}";
            }
            management = new Thread(() => TimeManagement(manr, path));
            management.Start();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "MA-Nr.")
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            state = false;
            management.Join();
            SwitchState();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
