using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _010_IP_Rechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox[] IP = new TextBox[4];
        TextBox[] SN = new TextBox[4];
        TextBox[] BC = new TextBox[4];
        TextBox[] NA = new TextBox[4];
        TextBox NC = new TextBox();
        Label lab_IP = new Label();
        Label lab_SN = new Label();
        Label lab_BC = new Label();
        Label lab_NA = new Label();
        Label lab_NC = new Label();
        Dot[] dots_IP = new Dot[3];
        Dot[] dots_SN = new Dot[3];
        Dot[] dots_BC = new Dot[3];
        Dot[] dots_NA = new Dot[3];
        Button calculate = new Button();
        Label line = new Label();
        Label title = new Label();

        public void Calculate(object sender, EventArgs e)
        {
            NC.Text = Calc_NC(Convert.ToInt32(IP[0].Text));
            string[] NA_str = Calc_NA(IP, SN);
            for (int i = 0; i < NA.Length; i++)
            {
                NA[i].Text = NA_str[i];
            }

            string[] BC_str = Calc_BC(IP, SN);
            for (int i = 0; i < BC.Length; i++)
            {
                BC[i].Text = BC_str[i];
            }

        }

        private string Calc_NC(int IP0)
        {
            char klasse;
            switch (IP0)
            {
                case 127:
                    break;
                default:
                    break;
            }

            if (IP0 <= 127)
            {
                klasse = 'A';
            }
            else if (IP0 <= 191)
            {
                klasse = 'B';
            }
            else if (IP0 <= 223)
            {
                klasse = 'C';
            }
            else if (IP0 <= 239)
            {
                klasse = 'D';
            }
            else if (IP0 >= 240)
            {
                klasse = 'E';
            }
            else
            {
                MessageBox.Show("Eingabe unzulässig");
                return "";
            }
            return Convert.ToString(klasse);
        }

        private string[] Calc_NA(TextBox[] IP, TextBox[] SN)
        {
            string[] NA = new string[IP.Length];
            for (int i = 0; i < NA.Length; i++)
            {
                NA[i] = Convert.ToString((Convert.ToInt32(IP[i].Text) & Convert.ToInt32(SN[i].Text)));
            }

            return NA;
        }

        private string[] Calc_BC(TextBox[] IP, TextBox[] SN)
        {
            string[] BC = new string[IP.Length];
            for (int i = 0; i < NA.Length; i++)
            {
                BC[i] = Convert.ToString((Convert.ToInt32(IP[i].Text) & Convert.ToInt32(SN[i].Text)));
            }

            return BC;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Dot.Populate(dots_IP);
            Dot.Populate(dots_SN);
            Dot.Populate(dots_BC);
            Dot.Populate(dots_NA);
            
            foreach (var dot in dots_IP)
            {
                dot.Parent = this;
            }

            foreach (var dot in dots_SN)
            {
                dot.Parent = this;
            }

            foreach (var dot in dots_BC)
            {
                dot.Parent = this;
            }

            foreach (var dot in dots_NA)
            {
                dot.Parent = this;
            }
            
            for (int i = 0; i < IP.Length; i++)
            {
                IP[i] = new TextBox();
                IP[i].Location = new System.Drawing.Point(94 + i*58, 46);
                IP[i].Width = 30;
                IP[i].Name = String.Format("textBox_IP_{0}", i);
                IP[i].TabIndex = i;
                IP[i].Enabled = true;
                IP[i].Parent = this;
                Controls.Add(IP[i]);
            }
            
            for (int i = 0; i < SN.Length; i++)
            {
                SN[i] = new TextBox();
                SN[i].Location = new System.Drawing.Point(94 + i * 58, 72);
                SN[i].Width = 30;
                SN[i].Name = String.Format("textBox_SN_{0}", i);
                SN[i].TabIndex = i+IP.Length;
                SN[i].Enabled = true;
                SN[i].Parent = this;
                Controls.Add(SN[i]);
            }

            for (int i = 0; i < NA.Length; i++)
            {
                NA[i] = new TextBox();
                NA[i].Location = new System.Drawing.Point(94 + i * 58, 117);
                NA[i].Width = 30;
                NA[i].Name = String.Format("textBox_NA_{0}", i);
                NA[i].TabIndex = i + IP.Length + NA.Length;
                NA[i].Enabled = true;
                NA[i].Parent = this;
                NA[i].Enabled = false;
                Controls.Add(NA[i]);
            }

            for (int i = 0; i < BC.Length; i++)
            {
                BC[i] = new TextBox();
                BC[i].Location = new System.Drawing.Point(94 + i * 58, 143);
                BC[i].Width = 30;
                BC[i].Name = String.Format("textBox_BC_{0}", i);
                BC[i].TabIndex = i + IP.Length + NA.Length + BC.Length;
                BC[i].Enabled = true;
                BC[i].Parent = this;
                BC[i].Enabled = false;
                Controls.Add(BC[i]);
            }

            NC.Location = new System.Drawing.Point(94, 169);
            NC.Width = 30;
            NC.Name = String.Format("textBox_NC");
            NC.TabIndex = 1 + IP.Length + NA.Length + BC.Length;
            NC.Enabled = true;
            NC.Parent = this;
            NC.Enabled = false;
            Controls.Add(NC);

            lab_IP.Location = new System.Drawing.Point(27, 49);
            lab_IP.AutoSize = true;
            lab_IP.Name = String.Format("label_IP");
            lab_IP.Text = "IP-Adresse:";
            lab_IP.Enabled = true;
            lab_IP.Parent = this;

            lab_SN.Location = new System.Drawing.Point(27, 49);
            lab_SN.AutoSize = true;
            lab_SN.Name = String.Format("label_SN");
            lab_SN.Text = "Subnetzmaske:";
            lab_SN.Enabled = true;
            lab_SN.Parent = this;

            lab_NA.Location = new System.Drawing.Point(27, 49);
            lab_NA.AutoSize = true;
            lab_NA.Name = String.Format("label_NA");
            lab_NA.Text = "Netzadr.:";
            lab_NA.Enabled = true;
            lab_NA.Parent = this;

            lab_BC.Location = new System.Drawing.Point(27, 49);
            lab_BC.AutoSize = true;
            lab_BC.Name = String.Format("label_BC");
            lab_BC.Text = "Broadcastadr.:";
            lab_BC.Enabled = true;
            lab_BC.Parent = this;

            lab_NC.Location = new System.Drawing.Point(27, 49);
            lab_NC.AutoSize = true;
            lab_NC.Name = String.Format("label_NC");
            lab_NC.Text = "Klasse:";
            lab_NC.Enabled = true;
            lab_NC.Parent = this;
            
            calculate.AutoSize = true;
            calculate.Text = "Berechnen";
            calculate.Parent = this;

            line.AutoSize = true;
            line.Parent = this;

            title.AutoSize = true;
            title.Parent = this;
            title.Text = "IP - Rechner";
            title.Font = new Font(FontFamily.GenericSansSerif , 12, FontStyle.Bold);

            this.calculate.Click += new System.EventHandler(this.Calculate);

            Form1_Resize(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Object_Grid_Pos(2, 2, control, IP);
            Object_Grid_Pos(2, 3, control, SN);
            Object_Grid_Pos(2, 5, control,NA);
            Object_Grid_Pos(2, 6, control, BC);
            Object_Grid_Pos(2, 7, control, NC);
            Object_Grid_Pos(0, 2, control, lab_IP);
            Object_Grid_Pos(0, 3, control, lab_SN);
            Object_Grid_Pos(0, 5, control, lab_NA);
            Object_Grid_Pos(0, 6, control, lab_BC);
            Object_Grid_Pos(0, 7, control, lab_NC);
            Dot.Dot_Pos(dots_IP, IP);
            Dot.Dot_Pos(dots_SN, SN);
            Dot.Dot_Pos(dots_NA, NA);
            Dot.Dot_Pos(dots_BC, BC);
            Object_Grid_Pos(6, 4, control, calculate);
            Object_Grid_Pos(0, 4, control, line);
            Draw_Line(line, "-", new Font("Serif", 16), calculate, control);
            Object_Grid_Pos(3, 1, control, title);
        }

        private void Draw_Line(Label line, string char_, Font font, Control far_object, Control control)
        {
            Graphics g = control.CreateGraphics();
            float char_size = g.MeasureString(char_, font).Width;
            int length = far_object.Location.X - line.Location.X;
            int number_of_chars = Convert.ToInt32(length / char_size);
            char_ = " " + char_;
            line.Text = "";
            line.Font = font;
            for (int i = 0; i < number_of_chars; i++)
            {
                line.Text = line.Text + char_;
            }
            g.Dispose();
        }

        private void Object_Grid_Pos(int x_start, int y_start, Control control, params Control[] obj)
        {
            int[] steps = new int[2];
            steps[0] = 8; //x
            steps[1] = 8; //y

            int x_size = control.ClientSize.Width / steps[0];
            int y_size = control.ClientSize.Height / steps[1];
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].Location = new Point((x_start + i) * x_size, y_start * y_size);
            }
        }



        public class Dot : Label
        {
            public Dot()
            {
                Location = new System.Drawing.Point(0, 0);
                AutoSize = true;
                Text = ".";
                Font = new Font("Serif", 16);
                Enabled = true;
            }

            public static void Dot_Pos(Dot[] dots, Control[] obj)
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    int xi = obj[i].Location.X;
                    int xip = obj[++i].Location.X;
                    int x = xi + ((xip - xi) / 2);
                    i--;
                    dots[i].Location = new Point(x, obj[i].Location.Y);
                }
            }
            
            public static void Populate(Dot[] dots)
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    dots[i] = new Dot();
                }
            }
        }
    }
}
