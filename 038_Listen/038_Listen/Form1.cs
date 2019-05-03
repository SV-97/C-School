using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _038_Listen
{
    public partial class Form1 : Form
    {
        private Schulklasse TSE2;

        public Form1()
        {
            InitializeComponent();
            TSE2 = new Schulklasse();
        }

        private void Form1_Load(object sender, EventArgs e) {}

        private void showList()
        {
            liSchueler.Items.Clear();
            for (int i = TSE2.AnzahlSchueler - 1; i >= 0; i--)
            {
                var schueler = TSE2.GetSchueler(i);
                var item = new IndexedListViewItem(schueler.Uid, schueler.Name);
                item.SubItems.Add(schueler.Vorname);
                item.SubItems.Add($"{schueler.Strasse} {schueler.Hausnummer}");
                item.SubItems.Add(schueler.PLZ);
                item.SubItems.Add(schueler.Ort);
                item.SubItems.Add(schueler.Telefon);
                item.SubItems.Add(schueler.GebDatum.ToString());

                liSchueler.Items.Add(item);
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (IndexedListViewItem item in liSchueler.SelectedItems)
            {
                textBox1.Text = item.Text;
                textBox2.Text = item.SubItems[1].Text;
                textBox3.Text = item.SubItems[2].Text;
                textBox4.Text = item.SubItems[3].Text;
                textBox5.Text = item.SubItems[4].Text;
                textBox6.Text = item.SubItems[5].Text;
                textBox7.Text = item.SubItems[6].Text;
            }
        }

        private Schueler SelectedSchueler()
        {
            var schueler = new Schueler();
            SelectedSchueler(ref schueler);
            return schueler;
        }
        private void SelectedSchueler(ref Schueler schueler)
        {
            schueler.Name = textBox1.Text;
            schueler.Vorname = textBox2.Text;
            var StrasseHNr = textBox3.Text.Split(' ');

            var letzter_index = StrasseHNr.Length - 1; // ^0 doesn't work yet
            schueler.Hausnummer = StrasseHNr[letzter_index];
            schueler.Strasse = String.Join(" ", StrasseHNr.Take(StrasseHNr.Length - 1));

            schueler.PLZ = textBox4.Text;
            schueler.Ort = textBox5.Text;
            schueler.Telefon = textBox6.Text;
            schueler.GebDatum = Convert.ToDateTime(textBox7.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var indices = liSchueler.SelectedIndices;
            if (indices.Count > 0)
            {
                var index = indices[0];
                var item = (IndexedListViewItem) liSchueler.Items[index];
                var uid = item.Uid;
                var schueler = TSE2.GetSchueler(uid);
                SelectedSchueler(ref schueler);
            } else
            {
                TSE2.AddSchueler(SelectedSchueler());
            }
            showList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TSE2.DeleteSchueler(SelectedSchueler());
        }
    }
}
