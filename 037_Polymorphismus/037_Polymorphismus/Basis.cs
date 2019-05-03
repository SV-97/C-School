using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037_Polymorphismus
{
    abstract class Basis
    {
        public virtual int VirtuelleMethode() //nie private
        {
            return 5;
        }

        public abstract int AbstrakteMethode();
    }

    class Basis2 : Basis
    {
        // Schlüsselwort sealed verhindert weiteres Überschreiben in Subklassen.
        public sealed override int VirtuelleMethode()
        {
            return 5;
        }

        public override int AbstrakteMethode()
        {
            return 1;
        }
    }
}
