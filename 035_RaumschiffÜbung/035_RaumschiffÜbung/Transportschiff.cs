using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _035_RaumschiffÜbung
{
    class Transportschiff : Raumschiff
    {
        public int Lager
        { get; set; }

        public Transportschiff() : this(20)
        {}

        public Transportschiff( int Lager ) : base()
        {
            this.Lager = Lager;
        }

        public override String KlassenName()
        {
            return $"{this}";
        }
    }
}
