using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bruch22
{
    class Bruch
    {
        //Felder
        private int zaehler = 0;
        private int nenner = 1;
        
        //Konstruktor
        public Bruch(int z = 0, int n = 1)
        { 
            zaehler = z;
            nenner = n;
        }

        //Methoden
        public void SetZaehler(int z)
        {
            zahler = z;
        }
        public void SetNenner(int n)
        {
            nenner = n;
        }
        public double GetDezWert()
        {
            return Convert.ToDouble(zaehler) / Convert.ToDouble(nenner);
        }

    }
}