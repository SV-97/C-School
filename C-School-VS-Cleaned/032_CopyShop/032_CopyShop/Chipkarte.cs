using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_CopyShop
{
    public class Chipkarte
    {
        protected int pinNr;
        public int PinNr
        {
            get { return pinNr; }
            set { pinNr = value; }
        }
        public Chipkarte()
        {
            pinNr = 12345;
        }
        public bool vergleichePinNr(int other)
        {
            return other == pinNr;
        }
    }
}
