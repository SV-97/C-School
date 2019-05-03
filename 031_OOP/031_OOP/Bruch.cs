using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _031_OOP
{
    class Bruch
    {
        //Felder
        private int zaehler;
        private int nenner;

        //Properties
        public int Zaehler { get; set; }
        public int Nenner { get; set; }
        public double Dezimalwert
        {
            get { return Convert.ToDouble(Zaehler) / Convert.ToDouble(Nenner); }
        }

        //Konstruktor
        public Bruch()
        {
            zaehler = 0;
            nenner = 1;
            Zaehler = zaehler;
            Nenner = nenner;
        }

        public Bruch(int z, int n)
        {
            zaehler = z;
            nenner = n;
            Zaehler = zaehler;
            Nenner = nenner;
        }

        //Methoden
        /*
        public void SetZaehler(int z)
        {
            zaehler = z;
        }
        public void SetNenner(int n)
        {
            nenner = n;
        }
        public int GetZaehler()
        {
            return zaehler;
        }
        public int GetNenner()
        {
            return nenner;
        }
        public double GetDezWert()
        {
            return Convert.ToDouble(zaehler) / Convert.ToDouble(nenner);
        }
        */

        ~Bruch()
        {
            Console.WriteLine("Zerstört");
        }
    }
}