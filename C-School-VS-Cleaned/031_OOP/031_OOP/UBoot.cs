using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031_OOP
{
    class UBoot
    {
        public double Tiefe { get; set; }
        public double MaxTiefe { get; set; }
        public double Orientierung { get; set; } //Winkel gegen x-Achse
        public double XKoordinate { get; set; }
        public double YKoordinate { get; set; }

        public UBoot()
        {
            Tiefe = 0;
            MaxTiefe = 1000;
            Orientierung = 0;
            XKoordinate = 0;
            YKoordinate = 0;
        }
        public void Abtauchen(double distance)
        {
            Tiefe += distance;
        }
        public void Auftauchen(double distance)
        {
            Tiefe -= distance;
        }
        public void Fahren(double distance)
        {
            XKoordinate += distance * Math.Cos(Orientierung);
            YKoordinate += distance * Math.Sin(Orientierung);
        }
        public void Drehen(double angle)
        {
            Orientierung += angle * Math.PI / 180.0;
        }
    }
}
