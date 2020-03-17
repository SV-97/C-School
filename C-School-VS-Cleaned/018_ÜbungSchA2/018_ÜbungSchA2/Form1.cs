using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018_ÜbungSchA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double preis_fernseher = 999.99;
        double preis_handy = 750.00;
        double preis_tablet = 333.95;

        private void button1_Click(object sender, EventArgs e)
        {
            double[] preise = new double[3] { preis_fernseher, preis_handy, preis_tablet };
            bool[] state = new bool[3] { checkBox1.Checked, checkBox2.Checked, checkBox3.Checked };
            double rechnung = 0;
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i])
                {
                    rechnung += preise[i];
                }
            }
            if (checkBox4.Checked)
            {
                rechnung = rechnung * 0.9;
            }
            else
            {
                rechnung = rechnung;
            }
            textBox2.Text = String.Format("Endbetrag ist {0:f2}€", rechnung);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Changed(checkBox1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Changed(checkBox2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Changed(checkBox3);
        }

        private void checkBox_Changed(CheckBox box)
        {
            if (box.Checked == true)
            {
                if (box == checkBox2 && checkBox3.Checked == true || box == checkBox3 && checkBox2.Checked == true)
                {
                    MessageBox.Show("Zwei Geräte mit SIM-Karte gewählt");
                    box.Checked = false;
                    return;
                }
            }
            string[] str = new string[3] { String.Format("Fernseher {0}€ \r\n", preis_fernseher), String.Format("Handy {0}€ \r\n", preis_handy), String.Format("Tablet {0}€ \r\n", preis_tablet) };
            CheckBox[] boxes = new CheckBox[3] {checkBox1, checkBox2, checkBox3};
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].Checked)
                {
                    if (!textBox1.Text.Contains(str[i]))
                    {
                        textBox1.Text = textBox1.Text + str[i];
                    }
                }
                else
                {
                    textBox1.Text = textBox1.Text.Replace(str[i], "");
                }
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double kaufkosten;
            double restschuld;
            double monatliche_zins;
            int tilgung;
            double zinssatz = 0.02;
            int laufzeit = 24;

            kaufkosten = Convert.ToDouble(textBox2.Text);

        }
    }
}
