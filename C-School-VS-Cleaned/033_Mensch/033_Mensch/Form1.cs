using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _033_Mensch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mensch emil = new Mensch(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
            textBox4.Text = emil.Vorname + "\r\n";
            textBox4.Text += $"{emil.Name}\r\n{emil.Alter}";

            Adresse maier = new Adresse(emil);
            maier.Strasse = textBox9.Text;
            maier.HausNr = textBox10.Text;
            maier.PLZ = textBox11.Text;
            maier.Ort = textBox12.Text;
            textBox5.Text = $"{maier.Vorname}\r\n{maier.Name}\r\n{maier.Alter}\r\n{maier.Strasse}\r\n{maier.HausNr}\r\n{maier.PLZ}\r\n{maier.Ort}\r\n";

            Kunde kdschmidt = new Kunde(maier);
            kdschmidt.KdNr = textBox7.Text;
            kdschmidt.LetzterEinkauf = textBox8.Text;
            textBox6.Text = String.Join("\r\n", new string[] { kdschmidt.Vorname, kdschmidt.Name, $"{kdschmidt.Alter}", kdschmidt.Strasse, kdschmidt.HausNr, kdschmidt.PLZ, kdschmidt.Ort, kdschmidt.KdNr, kdschmidt.LetzterEinkauf});

        }
        
    }
}
