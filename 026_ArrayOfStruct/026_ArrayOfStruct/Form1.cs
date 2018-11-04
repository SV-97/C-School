using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _026_ArrayOfStruct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Book
        {
            public decimal price;
            public string title;
            public string autor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Struct
            Book Lord_of_the_rings;
            Lord_of_the_rings.title = "The return of the King - Part 3";

            //Array of Struct
            Book[] LotR_series = new Book[3];
            LotR_series[2].title = Lord_of_the_rings.title;
        }
    }
}
