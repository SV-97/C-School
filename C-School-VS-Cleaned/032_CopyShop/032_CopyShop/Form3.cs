using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _032_CopyShop
{
    public partial class Form3 : Form
    {
        Kopierkarte copycard;
        public Form3(ref Kopierkarte cc)
        {
            copycard = cc;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            copycard.kopieren(Convert.ToInt32(textBox1.Text));
            if (copycard.Gueltig)
            {
                MessageBox.Show($"{copycard.getKopien()}");
            } else
            {
                MessageBox.Show("Karte ungültig!");
            }
            this.Close();
        }
    }
}
