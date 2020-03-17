using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _009_BruchKürzen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int zaehler_in = Convert.ToInt32(textBox1.Text);
            int nenner_in = Convert.ToInt32(textBox2.Text);
            int zaehler_out;
            int nenner_out;
            int ggt = 0;
            bool zaehler_vz;
            bool nenner_vz;
            bool vz_out;
            int i = 0;


            //Groessten gemeinsamen Teiler bestimmen
            //Vorzeichen für GGT festlegen und Beträge der Eingangswerte setzen
            if (zaehler_in < 0)
            {
                zaehler_vz = true;
                zaehler_in *= -1;
            }
            else
            {
                zaehler_vz = false;
            }

            if (nenner_in < 0)
            {
                nenner_vz = true;
                nenner_in *= -1;
            }
            else
            {
                nenner_vz = false;
            }

            //Betrag des GGT berechnen
            if (zaehler_in == nenner_in)
            {
                ggt = zaehler_in;
            }
            else
            {
                if (zaehler_in > nenner_in)
                {
                    while (zaehler_in != nenner_in)
                    {
                        zaehler_in -= nenner_in;
                        i++;
                    }
                    ggt = zaehler_in;
                    zaehler_in += nenner_in * i;
                }
                else
                {
                    while (zaehler_in != nenner_in)
                    {
                        nenner_in -= zaehler_in;
                        i++;
                    }
                    ggt = nenner_in;
                    nenner_in += zaehler_in * i;
                }
            }

            //Vorzeichen des GGT schreiben
            /*
            if (zaehler_vz)
            {
                if (nenner_vz)
                {
                    ggt *= -1;
                }
            }
            */

            if (zaehler_vz == nenner_vz)
            {
                vz_out = false;
            }
            else
            {
                vz_out = true;
            }

            //Ausgangsbruch erstellen
            nenner_out = nenner_in / ggt;
            zaehler_out = zaehler_in / ggt;

            textBox3.Text = Convert.ToString(zaehler_out);
            textBox4.Text = Convert.ToString(nenner_out);

            if (vz_out)
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }
    }
}
