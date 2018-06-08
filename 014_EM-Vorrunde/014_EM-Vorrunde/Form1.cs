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

namespace _014_EM_Vorrunde
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Spiel
        {
            public Spiel()
            {
                Datum = "";
                Uhrzeit = "";
                Austragungsort = "";
                Heim = "";
                Gast = "";
                ToreHeim = 0;
                ToreGast = 0;
            }
            public string Datum;
            public string Uhrzeit;
            public string Austragungsort;
            public string Heim;
            public string Gast;
            public int ToreHeim;
            public int ToreGast;
        }

        public class Mannschaft//: IComparable<Mannschaft>
        {
            public string Name { get; set; }
            public int Punkte { get; set; }
            public int Tore { get; set; }
            public int ToreBekommen { get; set; }

            public Mannschaft Pop(ref List<Mannschaft> obj, int i)
            {
                Mannschaft o = obj[i];
                obj.RemoveAt(i);
                return o;
            }

            public void InsertionSort(ref Mannschaft[] mannschaften) //Insertion Sort, couldn't get IComparable to work
            {
                List<Mannschaft> i = new List<Mannschaft>();
                List<Mannschaft> sorted = new List<Mannschaft>();
                i.AddRange(mannschaften);
                sorted.Add(Pop(ref i, 0));
                while (i.Count() > 0)
                {
                    Mannschaft n = Pop(ref i, 0);
                    for (int j = sorted.Count() - 1; j > -1; j--)
                    {
                        if (sorted[j].Punkte < n.Punkte)
                        {
                            sorted.Insert(j + 1, n);
                            break;
                        }
                        else if (sorted.Count() >= 1 && j == 0)
                        {
                            sorted.Insert(j, n);
                            break;
                        }
                    }
                }
                mannschaften = sorted.ToArray();
            }
            
            public int CompareTo(Mannschaft other)
            {
                /*
                if (this.Punkte == other.Punkte)
                {
                    return this.Tore.CompareTo(other.Tore);
                }
                return other.Punkte.CompareTo(this.Punkte);
                */
                if (Punkte < other.Punkte) return 1;
                else if (Punkte > other.Punkte) return -1;
                else return 0;
            }

            public Mannschaft(string name)
            {
                Name = name;
                Punkte = 0;
                Tore = 0;
            }
        }

        public void Punkte(Spiel spiel,int ausgang) //ausgang = 0 -> Gast, ausgang = 1 -> Heim, ausgang = 3 -> Unentschieden
        {
            switch (ausgang)
            {
                case 0:
                    foreach (var mannschaft in mannschaften)
                    {
                        if (mannschaft.Name == spiel.Gast)
                        {
                            mannschaft.Punkte += 3;
                            break;
                        }
                    }
                    break;
                case 1:
                    foreach (var mannschaft in mannschaften)
                    {
                        if (mannschaft.Name == spiel.Heim)
                        {
                            mannschaft.Punkte += 3;
                            break;
                        }
                    }
                    break;
                case 2:
                    foreach (var mannschaft in mannschaften)
                    {
                        if (mannschaft.Name == spiel.Heim)
                        {
                            mannschaft.Punkte += 1;
                        }
                        if (mannschaft.Name == spiel.Gast)
                        {
                            mannschaft.Punkte += 1;
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }

        Spiel[] input;
        Mannschaft[] mannschaften;

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"D:\Git Repos\C-School\014_EM-Vorrunde\014_EM-Vorrunde\Tabelle.txt");
            string[] lines = sr.ReadToEnd().Split('\n');
            input = new Spiel[lines.Length-1];
            for (int i = 0; i < lines.Length-1; i++)
            {
                input[i] = new Spiel();
                string line = lines[i]; //TODO: still neeed to remove escape sequence \r at the end
                string[] a = line.Split('_');
                input[i].Datum = a[0];
                input[i].Uhrzeit = a[1];
                input[i].Austragungsort = a[2];
                input[i].Heim = a[3];
                input[i].Gast = a[4];
                input[i].ToreHeim = Convert.ToInt32(a[5]);
                input[i].ToreGast = Convert.ToInt32(a[6]);
            }
            List<string> laender = new List<string>();
            string[] teilnehmer = new string[2];
            for (int i = 0; i < teilnehmer.Length; i++)
            {
                teilnehmer[i] = "";
            }
            foreach (var spiel in input)
            {
                teilnehmer[0] = spiel.Heim;
                teilnehmer[1] = spiel.Gast;
                foreach (var land in teilnehmer)
                {
                    if (laender.Contains(land))
                    {
                    }
                    else
                    {
                        laender.Add(land);
                    }
                }
            }
            mannschaften = new Mannschaft[laender.Count()];
            for (int i = 0; i < laender.Count(); i++)
            {
                mannschaften[i] = new Mannschaft(laender[i]);
            }
            foreach (var spiel in input)
            {
                if (spiel.ToreGast > spiel.ToreHeim)
                {
                    Punkte(spiel,0);
                }
                else if (spiel.ToreGast < spiel.ToreHeim)
                {
                    Punkte(spiel, 1);
                }
                else if (spiel.ToreGast == spiel.ToreHeim)
                {
                    Punkte(spiel, 2);
                }
            }
            foreach (var spiel in input)
            {
                foreach (var mannschaft in mannschaften)
                {
                    if (spiel.Gast == mannschaft.Name)
                    {
                        mannschaft.Tore += spiel.ToreGast;
                        mannschaft.ToreBekommen += spiel.ToreHeim;
                    }
                    else if (spiel.Heim == mannschaft.Name)
                    {
                        mannschaft.Tore += spiel.ToreHeim;
                        mannschaft.ToreBekommen += spiel.ToreGast;
                    }
                }
            }
            mannschaften[1].InsertionSort(ref mannschaften);
            listView1.Items.Add("Name");
            listView2.Items.Add("Punktzahl");
            listView3.Items.Add("Tore");
            listView4.Items.Add("Tordifferenz");
            foreach (var mannschaft in mannschaften)
            {
                listView1.Items.Add(mannschaft.Name);
                listView2.Items.Add(Convert.ToString(mannschaft.Punkte));
                listView3.Items.Add(Convert.ToString(mannschaft.Tore));
                listView4.Items.Add(Convert.ToString(mannschaft.Tore - mannschaft.ToreBekommen));
            }
        }
    }
}
