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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kopierkarte copycard = new Kopierkarte();
            copycard.setKopien(Convert.ToInt32(textBox1.Text));
            copycard.PinNr = Convert.ToInt32(textBox2.Text);
            this.Visible = false;
            new Form2(ref copycard).ShowDialog();
            this.Close();
        }
    }
}
