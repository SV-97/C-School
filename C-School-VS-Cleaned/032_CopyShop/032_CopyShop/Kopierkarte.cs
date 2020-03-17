using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_CopyShop
{
    public class Kopierkarte : Chipkarte
    {
        private int kopien;
        private bool gueltig;
        public bool Gueltig
        {
            get { return gueltig; }
        }
        public void setKopien(int kops)
        {
            kopien = kops;
        }
        public int getKopien()
        {
            return kopien;
        }
        public Kopierkarte()
        {
            kopien = 0;
            gueltig = true;
        }
        public bool kopieren(int anzahl)
        {
            if (!gueltig) { return false; };
            kopien -= anzahl;
            if (kopien < 0)
            {
                kopien = 0;
                gueltig = false;
            }
            return true;
        }
    }
}
