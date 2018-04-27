using System;

namespace izpaew_vatera
{
    class Program
    {
        static Vatera vatera;
        static void Main(string[] args)
        {
            vatera = new Vatera();

            AddMaganszemely("Péter", 01, 1);
            AddMaganszemely("Zsolt", 02, 1);

            Ceg ceg = new Ceg() { KontaktSzemely = new MaganSzemely() { Adoszam = 02, Nev = "Kiss Kontakt" }, Adoszam = 10, Ertekeles = 3, Nev = "Kiss Pék KFT." };
            ceg.GiftRecied += AjandekErtesito;
            vatera.AddElado("Kiss Pék KFT.",ceg);


            vatera.AddUjTermek("Péter", new Termek() { Nev = "TV", Cikkszam = 999 });
            vatera.AddUjTermek("Péter", new Termek() { Nev = "PC", Cikkszam = 666 });

            vatera.AddUjTermek("Kiss Pék KFT.", new Termek() { Nev = "sütő", Cikkszam = 565 });

            vatera.ListByNev("Péter");
            Console.WriteLine(vatera.FindTermekByCikszam(999).Nev);
            Console.WriteLine(vatera.FindTermekByNev("TV").Cikkszam);
            vatera.AjandekOsztas(10);


        }

        public static void AddMaganszemely(string nev, int adoszam, int ertekeles)
        {
            MaganSzemely msz = new MaganSzemely() { Adoszam = adoszam, Ertekeles = ertekeles, Nev = nev};
            msz.GiftRecied += AjandekErtesito;
            vatera.AddElado(nev, msz);
        }
        public static void AjandekErtesito(object src, EventArgs e)
        {
            Console.WriteLine($" új ajándék {((IElado)src).Nev} eladónak ");
        }
    }
}
