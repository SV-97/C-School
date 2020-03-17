using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037_Polymorphismus
{
    class Dreieck
    {
        public Dreieck (double SeiteA, double SeiteB, double Winkel)
        {
            this.SeiteA = SeiteA;
            this.SeiteB = SeiteB;
            this.Winkel = Winkel;
        }

        public double SeiteA
        { get; set; }

        public double SeiteB
        { get; set; }

        public double Winkel
        { get; set; }

        public virtual double Flaeche
        {
            get { return 0.5 * SeiteA * SeiteB * Math.Sin(Winkel); }
        }
    }

    class Parallelogramm : Dreieck
    {
        public Parallelogramm(double SeiteA, double SeiteB, double Winkel) :
            base(SeiteA, SeiteB, Winkel)
        { }

        public override double Flaeche
        {
            get { return 2 * base.Flaeche; }
        }
    }


    class ParallelogrammFalsch : Dreieck
    {
        public ParallelogrammFalsch(double SeiteA, double SeiteB, double Winkel) :
            base(SeiteA, SeiteB, Winkel)
        { }

        public new double Flaeche
        {
            get { return 2 * base.Flaeche; }
        }
    }
}
