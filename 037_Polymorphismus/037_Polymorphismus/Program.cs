using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037_Polymorphismus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Basis basis = new Basis(); // geht nicht da abstrakt
            var kind1 = new Kind1();
            var kind2 = new Kind2();
            var kind3 = new Kind3();
            var kind4 = new Kind4();

            Console.WriteLine($">>> kind1.Methode() -> {kind1.Methode()}");
            Console.WriteLine($">>> ((Basis)kind1).Methode() -> {((Basis)kind1).Methode()}");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine($">>> kind1.AbstrakteMethode() -> {kind1.AbstrakteMethode()}");
            Console.WriteLine($">>> kind2.AbstrakteMethode() -> {kind2.AbstrakteMethode()}");
            Console.WriteLine($">>> kind3.AbstrakteMethode() -> {kind3.AbstrakteMethode()}");
            Console.WriteLine();
            Console.ReadKey();


            Console.WriteLine($">>> kind1.VirtuelleMethode() -> {kind1.VirtuelleMethode()}");
            Console.WriteLine($">>> kind2.VirtuelleMethode() -> {kind2.VirtuelleMethode()}");
            Console.WriteLine($">>> kind3.VirtuelleMethode() -> {kind3.VirtuelleMethode()}");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Kind1 hat keine eigene Implementierung für VirtuelleMethode");
            Console.WriteLine("Kind1 als Basis ruft weiterhin Standartimplementation von VirtuelleMethode auf:");
            Console.WriteLine(">>> Basis kind1_als_basis = (Basis)kind1;");
            Basis kind1_als_basis = (Basis)kind1;
            Console.WriteLine($">>> kind1_als_basis.VirtuelleMethode() -> {kind1_als_basis.VirtuelleMethode()}");
            Console.WriteLine("Ohne Cast auf Basis:");
            Basis basis1 = kind1;
            Console.WriteLine(">>> Basis basis1 = kind1;");
            Console.WriteLine($">>> basis1.VirtuelleMethode() -> {basis1.VirtuelleMethode()}");
            Console.WriteLine("Was aufgerufen wird hängt vom 'Laufzeittyp' ab.");
            Console.WriteLine("Auch 'Dynamic Dispatch'(dt. 'Dynamische Bindung')");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Kind2 hat eigene Implementierung für VirtuelleMethode mit `new`");
            Console.WriteLine("Kind2 als Basis ruft Standartimplementation von VirtuelleMethode auf:");
            Console.WriteLine($">>> ((Basis)kind2).VirtuelleMethode() -> {((Basis)kind2).VirtuelleMethode()}");
            Basis basis2 = kind2;
            Console.WriteLine("Basis basis2 = kind2;");
            Console.WriteLine($">>> basis2.VirtuelleMethode() -> {basis2.VirtuelleMethode()}");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Kind3 hat eigene Implementierung für VirtuelleMethode mit `override`");
            Console.WriteLine("Kind3 als Basis ruft VirtuelleMethode von Kind3 auf:");
            Console.WriteLine($">>> ((Basis)kind3).VirtuelleMethode() -> {((Basis)kind3).VirtuelleMethode()}");
            Basis basis3 = kind3;
            Console.WriteLine("Basis basis3 = kind3;");
            Console.WriteLine($">>> basis3.VirtuelleMethode() -> {basis3.VirtuelleMethode()}");
            Console.WriteLine();
            Console.ReadKey();


            Console.WriteLine("Kind4 hat eigene Implementierung für VirtuelleMethode ohne Schlüsselwort");
            Console.WriteLine("Kind4 als Basis ruft Standartimplementation von VirtuelleMethode auf:");
            Console.WriteLine($">>> ((Basis)kind4).VirtuelleMethode() -> {((Basis)kind4).VirtuelleMethode()}");
            Basis basis4 = kind4;
            Console.WriteLine("Basis basis4 = kind4;");
            Console.WriteLine($">>> basis4.VirtuelleMethode() -> {basis4.VirtuelleMethode()}");
            Console.WriteLine();
            Console.ReadKey();
            

            var dreieck1 = new Dreieck(1.0, 2.0, Math.PI / 2);

            // Geht nicht da Parallelogramm in Vererbungshierarchie weiter unten
            // var para = (Parallelogramm) dreieck1;
            var para = new Parallelogramm(1.0, 2.0, Math.PI / 2);
            // Geht
            var dreieck2 = (Dreieck)para;

            Console.WriteLine($"Ein Dreieck mit Seitenlängen {dreieck1.SeiteA:f2}, {dreieck1.SeiteB:f2} und Winkel {dreieck1.Winkel:f2}rad");
            Console.WriteLine($"Seine Fläche ist {dreieck1.Flaeche:e2}");
            Console.WriteLine();
            Console.WriteLine($"Ein Parallelogramm mit Seitenlängen {para.SeiteA:f2}, {para.SeiteB:f2} und Winkel {para.Winkel:f2}rad");
            Console.WriteLine($"Seine Fläche ist {para.Flaeche:e2}");

            Console.ReadLine();
            Console.WriteLine("Alle Parallelogramm sind auch Dreiecke, können daher in ein Array:");
            Console.WriteLine(">>> var liste = new Dreieck[] { dreieck1, para }; ");
            Console.WriteLine("Fläche kann einheitlich ausgegeben werden:");

            var arr = new Dreieck[] { dreieck1, para };
            foreach (var element in arr)
            {
                Console.WriteLine($"{element.GetType().Name}.Flaeche -> {element.Flaeche:e2}");
            }
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Aber wenn Parallelogramm.Flaeche mit new deklariert wurde:");
            var para_falsch = new ParallelogrammFalsch(1.0, 2.0, Math.PI / 2);
            var arr_falsch = new Dreieck[] { dreieck1, para_falsch };
            foreach (var element in arr_falsch)
            {
                Console.WriteLine($"{element.GetType().Name}.Flaeche -> {element.Flaeche:e2}");
            }
            Console.ReadKey();
        }
    }
}
