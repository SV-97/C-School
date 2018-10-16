using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _020_Wochentagrechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string zellerscher_algorithmus(int tag, int monat, int jahr)
        {
            if (monat == 1 || monat == 2)
            {
                monat += 10;
                jahr--;
            }
            else
            {
                monat -= 2;
            }

            int jhd = jahr / 100;
            jahr %= 100;
            int k = jahr / 4 + jhd / 4 + (13 * monat - 1) / 5 + tag + jahr - 2 * jhd;
            int rest = k % 7;
            if (rest < 0)
            {
                rest += 7;
            }
            //string wochentag;
            string wochentag = new string[] { "Sonntag" , "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag"}[rest];
            /*
            switch (rest)
            {
                case 0:
                    wochentag = "Sonntag";
                    break;
                case 1:
                    wochentag = "Montag";
                    break;
                case 2:
                    wochentag = "Dienstag";
                    break;
                case 3:
                    wochentag = "Mittwoch";
                    break;
                case 4:
                    wochentag = "Donnerstag";
                    break;
                case 5:
                    wochentag = "Freitag";
                    break;
                case 6:
                    wochentag = "Samstag";
                    break;
                default:
                    wochentag = "Fehler";
                    break;
            }
            */
            return wochentag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(textBox1.Text);
            int monat = Convert.ToInt32(textBox2.Text);
            int jahr = Convert.ToInt32(textBox3.Text);
            
            if (tag <= 0 || tag > 31)
            {
                throw new ArgumentException("Für Tag muss gelten: 0 < Tag < 32");
            }
            if (monat < 0 || monat > 12)
            {
                throw new ArgumentException("Für Monat muss gelten: 0 < Monat < 13");
            }
            if (jahr < 1582)
            {
                throw new ArgumentException("Für Jahr muss gelten: 1582 <= Jahr");
            }
            string wochentag = zellerscher_algorithmus(tag, monat, jahr);
            button1.Text = wochentag;
        }
    }
}
