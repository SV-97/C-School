using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _004_Körperberechnung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Quader
        {
            button1.Text = "Quader berechnen";
            label2.Text = "Länge";
            label3.Text = "Breite";
            label4.Text = "Höhe";
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Zylinder
        {

            button1.Text = "Zylinder berechnen";
            label2.Text = "Radius";
            label3.Text = "Höhe";
            label4.Text = "";
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//Kegel
        {

            button1.Text = "Kegel berechnen";
            label2.Text = "Radius";
            label3.Text = "Höhe";
            label4.Text = "";
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)//Kugel
        {

            button1.Text = "Kugel berechnen";
            label2.Text = "Radius";
            label3.Text = "";
            label4.Text = "";
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //Berechnen
        {
            string body = "";
            const double pi = Math.PI;
            double val1;
            double val2;
            double val3;
            double volumen;
            double flaeche;

            val1 = Convert.ToDouble(textBox1.Text);
            val2 = Convert.ToDouble(textBox1.Text);
            val3 = Convert.ToDouble(textBox1.Text);

            if (radioButton1.Checked == true)
            {
                body = "Quader";
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    body = "Zylinder";
                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        body = "Kegel";
                    }
                    else
                    {

                        if (radioButton4.Checked == true)
                        {
                            body = "Kugel";
                        }
                    }
                }
            };

            switch (body)
            {
                case "Quader":
                    volumen = val1 * val2 * val3;
                    flaeche = Math.Pow(val1, 2.0) + Math.Pow(val2, 2.0) + Math.Pow(val3, 2.0);
                    break;
                case "Zylinder":
                    volumen = Math.Pow(val1, 2.0) * val2 * pi;
                    flaeche = 2.0 * pi * val1 * val2 + 2.0 * pi * Math.Pow(val1, 2.0);
                    break;
                case "Kegel":
                    volumen = pi * Math.Pow(val1, 2.0) * ( val2/3.0);
                    flaeche = pi * val1 * (val1 + Math.Sqrt(Math.Pow(val1, 2.0) + Math.Pow(val2, 2.0)));
                    break;
                case "Kugel":
                    volumen = 4.0 * pi * (Math.Pow(val1, 3.0) / 3.0);
                    flaeche = 4.0 * pi * Math.Pow(val1, 2.0);
                    break;
                default:
                    volumen = 0.0;
                    flaeche = 0.0;
                    break;
            }
            label9.Text = Convert.ToString(volumen);
            label10.Text = Convert.ToString(flaeche);
        }
    }
}
