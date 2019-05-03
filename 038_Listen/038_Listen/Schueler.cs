using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _038_Listen
{
    class Schueler
    {
        public String Name
        {
            get;
            set;
        }

        public String Vorname
        {
            get;
            set;
        }

        public String Strasse
        {
            get;
            set;
        }

        public String Hausnummer
        {
            get;
            set;
        }

        public String PLZ
        {
            get;
            set;
        }

        public String Ort
        {
            get;
            set;
        }

        public String Telefon
        {
            get;
            set;
        }

        public DateTime GebDatum
        {
            get;
            set;
        }

        public Guid Uid
        {
            get;
        }

        public Schueler(
            String Name, String Vorname, String Strasse, String Hausnummer,
            String PLZ, String Ort, String Telefon, DateTime GebDatum)
        {
            this.Name = Name;
            this.Vorname = Vorname;
            this.Strasse = Strasse;
            this.Hausnummer = Hausnummer;
            this.PLZ = PLZ;
            this.Ort = Ort;
            this.Telefon = Telefon;
            this.GebDatum = GebDatum;
            this.Uid = Guid.NewGuid();
        }

        public Schueler ()
        {
            this.Uid = Guid.NewGuid();
        }

        public String ToString()
        {
            return $"{this.Vorname} {this.Name}";
        }
    }
}
