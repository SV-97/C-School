using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _038_Listen
{
    class Schulklasse
    {
        private List<Schueler> Schueler;

        public int AnzahlSchueler
        {
            get { return this.Schueler.Count(); }
        }

        public Schulklasse()
        {
            this.Schueler = new List<Schueler>();
        }

        public void AddSchueler(
            String Name, String Vorname, String Strasse, String Hausnummer,
            String PLZ, String Ort, String Telefon, DateTime GebDatum)
        {
            var schueler = new Schueler(
                Name, Vorname, Strasse, Hausnummer,
                PLZ, Ort, Telefon, GebDatum);
            this.Schueler.Add(schueler);
        }

        public void AddSchueler(Schueler schueler)
        {
            this.Schueler.Add(schueler);
        }

        public void DeleteSchueler(Schueler schueler)
        {
            this.Schueler.Remove(schueler);
        }

        public void DeleteSchueler(int i)
        {
            this.Schueler.RemoveAt(i);
        }

        public Schueler GetSchueler(int i)
        {
            return this.Schueler[i];
        }

        public Schueler GetSchueler(Guid Uid) 
        {
            return this.Schueler.Find(schueler => schueler.Uid == Uid);
        }

        public Schueler Pop(int i = 0)
        {
            var schueler = GetSchueler(i);
            DeleteSchueler(i);
            return schueler;
        }
    }
}
