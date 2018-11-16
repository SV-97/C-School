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
    public partial class Form2 : Form
    {
        Kopierkarte copycard;
        public Form2(ref Kopierkarte cc)
        {
            InitializeComponent();
            copycard = cc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(copycard.vergleichePinNr(Convert.ToInt32(textBox1.Text))))
            {
                MessageBox.Show("Falsche PIN!");
            } else
            {
                this.Visible = false;
                new Form3(ref copycard).ShowDialog();
                this.Close();
            }
        }
    }
}
