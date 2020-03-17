using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _028_Kostenrechnung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Datensatz
        {
            public int ID;
            public DateTime Date;
            public int duration;
            public decimal wage;
        }

        private void Kostenrechnung(int ID, string file, ref int total_time, ref decimal total_cost, ref decimal avrg_wage)
        {
            string[] raw_data = File.ReadAllText(file).Replace("\r\n","").Split(';');
            Datensatz[] data = new Datensatz[(raw_data.Length - 1) / 4];
            int counter = 0;
            for (int i = 0; i < raw_data.Length - 1; i += 4, counter++)
            {
                Datensatz new_data = new Datensatz();
                new_data.ID = Convert.ToInt32(raw_data[i]);
                new_data.Date = Convert.ToDateTime(raw_data[i + 1]);
                new_data.duration = Convert.ToInt32(raw_data[i + 2]);
                new_data.wage = Convert.ToDecimal(raw_data[i + 3]);
                data[counter] = new_data;
            }
            counter = 0;
            foreach (var item in data)
            {
                if (item.ID == ID) counter++;
            }
            Datensatz[] data_of_id = new Datensatz[counter];
            counter = 0;
            foreach (var item in data)
            {
                if (item.ID == ID)
                {
                    data_of_id[counter] = item;
                    counter++;
                }
            }
            total_time = 0;
            total_cost = 0;
            avrg_wage = 0;
            foreach (var datapoint in data_of_id)
            {
                total_time += datapoint.duration;
                total_cost += datapoint.wage * datapoint.duration;
            }
            avrg_wage = total_cost / total_time;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = 127;
            int total_time = 0;
            decimal total_cost = 0;
            decimal avrg_wage = 0;
            Kostenrechnung(ID, @"C:\Users\volzs\Documents\GitHub\C-School\028_Kostenrechnung\028_Kostenrechnung\kosten.txt", ref total_time, ref total_cost, ref avrg_wage);
            Console.WriteLine($"{ID} worked for {total_time} hours with an average wage of {avrg_wage}€. This equals {total_cost}€");
        }
    }
}
