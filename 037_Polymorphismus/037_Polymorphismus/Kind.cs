using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037_Polymorphismus
{
    class Kind1: Basis
    {
        public override int AbstrakteMethode()
        {
            return 1;
        }
    }

    class Kind2 : Basis
    {
        public override int AbstrakteMethode()
        {
            return 2;
        }

        // Mit new: wird zusätzlich zur Basisklassenmethode angelegt
        public new int VirtuelleMethode()
        {
            return base.VirtuelleMethode() + 2;
        }
    }

    class Kind3 : Basis
    {
        public override int AbstrakteMethode()
        {
            return 3;
        }

        // Mit override: überschreibt die Basisklassenimplementierung
        public override int VirtuelleMethode()
        {
            // Mit Schlüsselwort base kann Basisklassenimplementierung
            // weiterhin von innerhalb der Klasse aufgerufen werden
            return base.VirtuelleMethode() + 3;
        }
    }

    class Kind4 : Basis
    {
        public override int AbstrakteMethode()
        {
            return 4;
        }

        // Ohne zusätzliches Schlüsselwort: verwendet new und gibt Warnung aus
        public int VirtuelleMethode()
        {
            return 42;
        }
    }

    class Kind5 : Basis2
    {
        // override nicht erlaubt da versiegelt
        // public override int VirtuelleMethode()
        // new weiterhin erlaubt
        public new int VirtuelleMethode()
        {
            return 5;
        }
    }
}
