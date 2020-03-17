using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033_Mensch
{
    class Adresse : Mensch
    {
        protected string strasse;
        protected string hausnr;
        protected string plz;
        protected string ort;
        public string Strasse
        {
            get { return strasse; }
            set { strasse = value; }
        }
        public string HausNr
        {
            get { return hausnr; }
            set { hausnr = value; }
        }
        public string PLZ
        {
            get { return plz; }
            set { plz = value; }
        }
        public string Ort
        {
            get { return ort; }
            set { ort = value; }
        }
        public Adresse()
        {
            strasse = "";
            hausnr = "";
            plz = "";
            ort = "";
        }
        public Adresse(Mensch mensch)
        {
            name = mensch.Name;
            vorname = mensch.Vorname;
            alter = mensch.Alter;
            strasse = "";
            hausnr = "";
            plz = "";
            ort = "";
        }
    }
}
