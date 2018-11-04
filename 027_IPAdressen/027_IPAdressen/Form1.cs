using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _027_IPAdressen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void write_IP(IP ip)
        {
            string[] oktette = new string[ip.oktette.Length];
            for (int i = 0; i < oktette.Length; i++)
            {
                string oktett = Convert.ToString(ip.oktette[i], 2).PadLeft(8, '0');
                Convert.ToString(123, 2);
                oktette[i] = $"{oktett}";
            }
            string ip_string = String.Join(".", oktette);
            textBox6.Text = $"{ip_string}:{ip.subnetzmaske}";
        }

        public struct IP
        {
            public int[] oktette;
            public int subnetzmaske;
        }

        List<IP> ips = new List<IP>();

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] textboxen = { textBox1, textBox2, textBox3, textBox4 };
            IP new_IP;
            new_IP.oktette = new int[textboxen.Length];
            for (int i = 0; i < textboxen.Length; i++)
            {
                new_IP.oktette[i] = Convert.ToInt32(textboxen[i].Text);
            }
            new_IP.subnetzmaske = Convert.ToInt32(textBox5.Text);
            ips.Add(new_IP);
            write_IP(new_IP);
        }

        int index = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            int new_index = index + 1;
            if (new_index <= ips.Count - 1)
            {
                index = new_index;
            }
            else
            {
                index = 0;
            }
            write_IP(ips[index]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int new_index = index - 1;
            if (new_index >= 0)
            {
                index = new_index;
            }
            else
            {
                index = ips.Count - 1;
            }
            write_IP(ips[index]);
        }
    }
}
