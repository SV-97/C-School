using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033_Mensch
{
    class Kunde : Adresse
    {
        protected string kdNr;
        protected string letzterEinkauf;
        public string KdNr
        {
            get { return kdNr; }
            set { kdNr = value; }
        }
        public string LetzterEinkauf
        {
            get { return letzterEinkauf; }
            set { letzterEinkauf = value;  }
        }
        public Kunde()
        {
            kdNr = "";
            letzterEinkauf = "";
        }
        public Kunde(Adresse adress)
        {
            name = adress.Name;
            vorname = adress.Vorname;
            alter = adress.Alter;
            strasse = adress.Strasse;
            hausnr = adress.HausNr;
            plz = adress.PLZ;
            ort = adress.Ort;
            kdNr = "";
            letzterEinkauf = "";
        }
    }
}
