using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _034_SchA1_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct datenpunkt
        {
            public double strom;
            public double spannung;
        }

        public class Person
        {
            protected string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            protected char geschlecht;
            public char Geschlecht
            {
                get { return geschlecht; }
                set { geschlecht = value; }
            }
            public Person()
            {
                name = "";
                geschlecht = 'n';
            }
            public Person (string name_in, char geschlecht_in)
            {
                name = name_in;
                geschlecht = geschlecht_in;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
