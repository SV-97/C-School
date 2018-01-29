using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _006_Bremswegrechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool road_state; // true = wet - false = dry

        private void button1_Click(object sender, EventArgs e)
        {
            recalculate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            road_state = false;
            recalculate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            road_state = true;
            recalculate();
        }

        private void recalculate()
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Wert eingeben";
                return;
            }
            double time1 = 1.0; //Reaktionszeit
            double time2 = 0.3; //Bremszeit
            double a; //Beschleunigung
            double s; //Bremsweg
            double v; // Geschwindigkeit

            try
            {
                v = Convert.ToDouble(textBox1.Text) / 3.6;
                if (v < 0)
                {
                    v = -v;
                }
            }
            catch (Exception)
            {
                textBox1.Text = "NaN";
                return;
            }

            if (road_state) //nass
            {
                switch (comboBox1.Text)
                {
                    case "Beton":
                        a = 5.0;
                        break;
                    case "Asphalt":
                        a = 3.0;
                        break;
                    case "Pflaster":
                        a = 3.0;
                        break;
                    case "Feldweg":
                        a = 2.0;
                        break;
                    case "Glatteis":
                        a = 0.5;
                        break;
                    default:
                        a = 3.0;
                        break;
                }
            }
            else // trocken
            {
                switch (comboBox1.Text)
                {
                    case "Beton":
                        a = 9.0;
                        break;
                    case "Asphalt":
                        a = 7.0;
                        break;
                    case "Pflaster":
                        a = 6.0;
                        break;
                    case "Feldweg":
                        a = 5.0;
                        break;
                    case "Glatteis":
                        a = 1.0;
                        break;
                    default:
                        a = 7.0;
                        break;
                }
            }

            s = Math.Pow(v, 2) / (2.0 * a) + v * (time1 + time2);
            textBox2.Text = String.Format("{0:F2}", s);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
