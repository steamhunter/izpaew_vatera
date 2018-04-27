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

        public void AddElado(string nev, IElado elado)
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

        public void ListByNev(string eladonev)
        {
            if (Eladok.TryGetValue(eladonev, out IElado elado))
            {
                foreach (var item in elado.TermekLista)
                {
                    Console.WriteLine($"{item.Cikkszam} {item.Nev}");
                } 
            }
            else
            {
                throw new Exception("Eladó nem található");
            }


        }

        public void AjandekOsztas(int ajandekokszama)
        {
            List<KeyValuePair<int, KeyValuePair<string, IElado>>> eladok = new List<KeyValuePair<int, KeyValuePair<string, IElado>>>();

            foreach (var item in Eladok)
            {
                eladok.Add(new KeyValuePair<int, KeyValuePair<string, IElado>>(item.Value.TermekLista.Count, item));
            }
            ;
            for (int i = 0; i < eladok.Count; i++)
            {
                for (int j = i+1; j < eladok.Count; j++)
                {

                    if (eladok[i].Key < eladok[j].Key)
                    {
                        var s = eladok[i];
                        eladok[i] = eladok[j];
                        eladok[j] = s;
                    }
                }
            }

            int k = 0;
            while (ajandekokszama != 0)
            {
                if (k < Eladok.Count)
                {
                    if (eladok[k].Value.Value.Ertekeles < ajandekokszama)
                    {
                        ajandekokszama -= eladok[k].Value.Value.Ertekeles;
                        eladok[k].Value.Value.OnGiftRecieved();
                    }
                    else
                    {
                        ajandekokszama = 0;
                        eladok[k].Value.Value.OnGiftRecieved();
                    }
                    k++;
                }
                else
                {
                    if (ajandekokszama > 0 && k >= Eladok.Count)
                    {
                        throw new Exception("marad még kiosztatlan ajándék");
                    }

                }

            }
        }
    }
}
