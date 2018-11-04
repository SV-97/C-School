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

namespace _024_Umlautersetzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Ersetzer1(ref TextBox textbox, string path)
        {
            string str_in = File.ReadAllText(path);
            List<List<string>> characters = new List<List<string>>();
            characters.Add(new List<string> { "Ä", "Ae" });
            characters.Add(new List<string> { "ä", "ae" });
            characters.Add(new List<string> { "Ö", "Oe" });
            characters.Add(new List<string> { "ö", "oe" });
            characters.Add(new List<string> { "Ü", "Ee" });
            characters.Add(new List<string> { "ü", "ue" });
            characters.Add(new List<string> { "ß", "ss" });
            foreach (var pair in characters)
            {
                str_in = str_in.Replace(pair[0], pair[1]);
            }
            textbox.Text = str_in;
        }

        private void Ersetzer2(ref TextBox textbox, string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = "";
                string new_line = "";
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    new_line = "";
                    foreach (var character in line)
                    {
                        switch (character)
                        {
                            case 'Ä':
                                new_line += "Ae";
                                break;
                            case 'ä':
                                new_line += "ae";
                                break;
                            case 'Ö':
                                new_line += "Oe";
                                break;
                            case 'ö':
                                new_line += "oe";
                                break;
                            case 'Ü':
                                new_line += "Ue";
                                break;
                            case 'ü':
                                new_line += "ue";
                                break;
                            case 'ß':
                                new_line += "ss";
                                break;
                            default:
                                new_line += character.ToString();
                                break;
                        }
                    }
                    textbox.AppendText(new_line + "\n");
                }
            }
        }

        private void InitializeFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("hällö wüue gäht Äß \r\ndiaer?");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"\File";
            InitializeFile(path);
            textBox1.Text = File.ReadAllText(path);
            Ersetzer1(ref textBox2, path);
            Ersetzer2(ref textBox3, path);
        }
    }
}
