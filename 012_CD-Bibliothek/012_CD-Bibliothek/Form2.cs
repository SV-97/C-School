using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _012_CD_Bibliothek
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void activateForm1()
        {
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.language = "English";
            activateForm1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.language = "Deutsch";
            activateForm1();
        }
    }
}
