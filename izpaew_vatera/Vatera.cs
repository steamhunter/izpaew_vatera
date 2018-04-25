using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{
    class Vatera
    {
        Dictionary<string, IElado> Eladok = new Dictionary<string, IElado>();
        BST<Termek> Termekek = new BST<Termek>();

        public void AddElado(string nev,IElado elado)
        {
            if (!Eladok.ContainsKey(nev))
            {
                Eladok.Add(nev, elado);
            }
        }

        public void AddUjTermek(string eladonev, Termek termek)
        {
            if (Eladok.TryGetValue(eladonev, out IElado elado))
            {
                elado.TermekLista.Beszur(termek);
                Termekek.Insert(termek.Cikkszam, termek);
            }
            else
            {
                throw new Exception("Eladó nem található");
            }
        }

        public Termek FindTermekByCikszam(int cikkszam)
        {
            return Termekek.FindItemByKey(cikkszam);
        }

        public Termek FindTermekByNev(string nev)
        {
           List<Termek> termekek = Termekek.Bejaras(Bejarastipus.InOrder);

            foreach (var item in termekek)
            {

                if (item.Nev == nev)
                {
                    return item;
                }
            }
            return null;


        }

        public void ListByNev()
        {
            List<Termek> termekek = Termekek.Bejaras(Bejarastipus.InOrder);
            termekek.Sort();

            foreach (var item in termekek)
            {
                Console.WriteLine(item.Nev);
            }
            
        }
    }
}
