using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033_Mensch
{
    class Mensch   {
        protected string name;
        protected string vorname;
        protected int alter;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }
        public int Alter
        {
            get { return alter; }
            set { alter = value; }
        }
        public Mensch()
        {
            vorname = "";
            name = "";
            alter = -1;
        }
        public Mensch(string vn, string n, int a)
        {
            vorname = vn;
            name = n;
            alter = a;
        }
    }
}
