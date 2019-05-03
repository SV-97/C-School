using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _035_RaumschiffÜbung
{
    abstract class Raumschiff
    {
        public double Laenge
        { get; set; }
        public double Breite
        { get; set; }
        public int Besatzung
        { get; set; }
        public static int Instanzzaehler;

        public Raumschiff() : this(250, 300.5, 150.4)
        {
            Console.WriteLine("Parameterloser Konstruktor");
        }

        public Raumschiff(int Besatzung, double Laenge, double Breite)
        {
            Instanzzaehler++;
            Console.WriteLine("Parametrierter Konstruktor");
            this.Besatzung = Besatzung;
            this.Laenge = Laenge;
            this.Breite = Breite;
        }
        abstract public String KlassenName();

    }
}
