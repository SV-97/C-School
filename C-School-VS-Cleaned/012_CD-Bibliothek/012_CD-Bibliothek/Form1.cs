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

namespace _012_CD_Bibliothek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private static string _language;
        public static string language
        {
            get // this makes you to access value in form2
            {
                return _language;
            }
            set // this makes you to change value in form2
            {
                _language = value;
            }
        }



        int anzahl_im_archiv = 0;
        int auswahl = 0;
        CD[] collection = new CD[100];
        TextBox[] textBoxes = new TextBox[4];

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                collection[i] = new CD();
            }
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            Sync_from_archive();
            Display_collection_size();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox6.Enabled = false;

            using (StreamReader sr = new StreamReader(@"D:\Git Repos\C-School\012_CD-Bibliothek\012_CD-Bibliothek\Dict"))
            {
                string text = sr.ReadToEnd();
                string[] lines = text.Split('\r');
                foreach (var line in lines)
                {
                    string[] l = line.Split('*');
                    Control cntrl = this.Controls[l[0]];
                    switch (language)
                    {
                        case "Deutsch":
                            cntrl.Text = l[2];
                            break;
                        default:
                        case "English":
                            cntrl.Text = l[1];
                            break;
                    }
                }
            }

            listView1.Columns.Add(label1.Text);
            listView1.Columns.Add(label2.Text);
            listView1.Columns.Add(label3.Text);
            listView1.Columns.Add(label4.Text);
        }

        class CD
        {
            public CD()
            {
                titel = "";
                interpret = "";
                anzahl = "";
                dauer = "";
            }
            public string titel;
            public string interpret;
            public string anzahl;
            public string dauer;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CD cd = collection[anzahl_im_archiv];
            cd.titel = textBox1.Text;
            cd.interpret = textBox2.Text;
            cd.dauer = textBox3.Text;
            cd.anzahl = textBox4.Text;
            anzahl_im_archiv++;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Sync_to_archive();
            Display_collection_size();
        }

        private void Sync_from_archive()
        {
            string path = textBox5.Text;
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                string[] lines = text.Split('\n');
                anzahl_im_archiv = 0;
                foreach (var line in lines)
                {
                    if (string.Join("", line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)) == "") //Check if line consists solely of whitespaces
                    {
                        continue;
                    }
                    string[] album = line.Split('*');
                    collection[anzahl_im_archiv].titel = album[0];
                    collection[anzahl_im_archiv].interpret = album[1];
                    collection[anzahl_im_archiv].anzahl = album[2];
                    collection[anzahl_im_archiv].dauer = album[3];
                    anzahl_im_archiv++;
                }
                auswahl = anzahl_im_archiv-1;
            }

            //ListviewBox beschreiben
            ListViewItem[] list = new ListViewItem[anzahl_im_archiv];
            for (int i = 0; i < anzahl_im_archiv; i++)
            {
                list[i] = new ListViewItem(collection[i].titel);
                list[i].SubItems.Add(collection[i].interpret);
                list[i].SubItems.Add(collection[i].dauer);
                list[i].SubItems.Add(collection[i].anzahl);
            }
            listView1.Items.Clear();
            listView1.Items.AddRange(list);

            //Aktuelle Auswahl in Textboxen schreiben
            Auswahl_zu_Textboxen();
        }

        private void Sync_to_archive()
        {
            string path = textBox5.Text;
            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var CD in collection)
                {
                    if (CD.titel == "")
                    {
                        continue;
                    }
                    sr.WriteLine(String.Format("{0}*{1}*{2}*{3}",CD.titel, CD.interpret,CD.anzahl, CD.dauer));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                return;
            }
            auswahl++;
            if (auswahl >= anzahl_im_archiv)
            {
                auswahl = anzahl_im_archiv-1;
            }
            Auswahl_zu_Textboxen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                return;
            }
            auswahl--;
            if (auswahl < 0)
            {
                auswahl = 0;
            }
            Auswahl_zu_Textboxen();
        }

        private void Auswahl_zu_Textboxen()
        {
            if (radioButton1.Checked)
            {
                return;
            }
            CD cd = collection[auswahl];
            textBox1.Text = cd.titel;
            textBox2.Text = cd.interpret;
            textBox3.Text = cd.dauer;
            textBox4.Text = cd.anzahl;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //write
        {
            foreach (var txt in textBoxes)
            {
                txt.Enabled = true;
                txt.Text = "";
            }
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox6.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //read
        {
            Sync_from_archive();
            foreach (var txt in textBoxes)
            {
                txt.Enabled = false;
            }
            Display_collection_size();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            textBox6.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sync_to_archive();
        }


        private void Display_collection_size()
        {
            switch (language)
            {
                default:
                case "English":
                    label5.Text = String.Format("There are {0} of {1} CDs in collection", anzahl_im_archiv, collection.Length);
                    break;
                case "Deutsch":
                    label5.Text = String.Format("Es befinden sich {0} von {1} CDs in der Sammlung", anzahl_im_archiv, collection.Length);
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < anzahl_im_archiv; i++)
            {
                if (collection[i].titel.ToLower() == textBox6.Text.ToLower())
                {
                    auswahl = i;
                    Auswahl_zu_Textboxen();
                    break;
                }
            }
        }
    }
}
