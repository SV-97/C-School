using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _031_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bruch Objekt1 = new Bruch();
            Objekt1.Zaehler = 5;
            Objekt1.Nenner = 2;
            //Objekt1.SetNenner(5);
            //Objekt1.SetZaehler(1);
            //textBox1.Text += $"{Objekt1.GetDezWert()} = {Objekt1.GetZaehler()} / {Objekt1.GetNenner()}\r\n";
            Bruch Objekt2 = new Bruch(3, 4);
            //textBox1.Text += $"{Objekt2.GetDezWert()} = {Objekt2.GetZaehler()} / {Objekt2.GetNenner()}\r\n";
            textBox1.Text += $"{Objekt1.Dezimalwert} = {Objekt1.Zaehler} / {Objekt1.Nenner}\r\n";
            textBox1.Text += $"{Objekt2.Dezimalwert} = {Objekt2.Zaehler} / {Objekt2.Nenner}\r\n";
            UBoot boot1 = new UBoot();
            boot1.Abtauchen(10);
            boot1.Auftauchen(2);
            Console.WriteLine($"Tiefe = {boot1.Tiefe}");
            boot1.Fahren(2);
            boot1.Drehen(90);
            boot1.Fahren(3);
            Console.WriteLine($"X={boot1.XKoordinate}");
            Console.WriteLine($"Y={boot1.YKoordinate}");
        }
    }
}
