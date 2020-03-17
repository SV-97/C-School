using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _005_Alkomat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            globals.r = 0.7; //Verteilungsfaktor
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           globals.r = 0.6; //Verteilungsfaktor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double blutalc; //promille  - c
            double alc; //aufgenommene Menge Alkohol in g - A
            double gewicht; //Körpergewicht in kg - G
            double bier; //Menge Bier
            double wein; //Menge Wein
            double schnaps; //Menge Schnaps

            //Menge je Portion
            const double menge_bier = 0.5;
            const double menge_wein = 0.25;
            const double menge_schnaps = 0.5;

            //Promille
            const double pro_bier = 5;
            const double pro_wein = 11;
            const double pro_schnaps = 35;

            //Einlesen von Textboxen + Faktorisierung auf Liter
            bool exception = false;
            gewicht = 0.0;
            bier = 0.0;
            wein = 0.0;
            schnaps = 0.0;

            try
            {
                gewicht = Convert.ToDouble(textBox4.Text);
            }
            catch
            {
                textBox4.Text = "Zahl eingeben";
                exception = true;
            }
            try
            {
                bier = Convert.ToDouble(textBox1.Text) / (1.0 / menge_bier);
            }
            catch
            {
                textBox1.Text = "Zahl eingeben";
                exception = true;
            }
            try
            {
                wein = Convert.ToDouble(textBox2.Text) / (1.0 / menge_wein);
            }
            catch
            {
                textBox2.Text = "Zahl eingeben";
                exception = true;
            }
            try
            {
                schnaps = Convert.ToDouble(textBox3.Text) / (1.0 / menge_schnaps);
            }
            catch
            {
                textBox3.Text = "Zahl eingeben";
                exception = true;
            }

            if (exception)
            {
                return;
            }

            //Berechnung
            alc = 100.0 * 0.08 * (bier * pro_bier + wein * pro_wein + schnaps * pro_schnaps);
            blutalc = alc/(gewicht * globals.r);

            //Ausgabe
            if (blutalc < 0)
            {
                blutalc = blutalc * -1.0;
            }
            textBox5.Text = String.Format("{0:F2}", blutalc);
        }
        public static class globals
        {
            public static double r = 0.7;
        }
    }
}
