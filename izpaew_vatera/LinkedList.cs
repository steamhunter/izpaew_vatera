using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{


    class LinkedList<T>
    {

        private ListaElem fej;
        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;

            public override string ToString()
            {
                return tartalom.ToString();
            }
        }


        public void ElejereBeszur(T elem)
        {
            ListaElem uj = new ListaElem()
            {
                tartalom = elem,
                kovetkezo =fej
            };
            fej = uj;
        }
        public void Beszur(T elem)
        {
            var uj = new ListaElem() { tartalom = elem ,kovetkezo=null};


            if (fej == null)
            {
                fej = uj;

            }
            else
            {
                ListaElem p = fej;
                while (p.kovetkezo != null)
                {
                    p = p.kovetkezo;
                }
                p.kovetkezo = uj;
            }
        }
        public void Bejar()
        {
            ListaElem p = fej;
            while (p!=null)
            {
                Feldolgoz(p);
                p = p.kovetkezo;
            }
        }

        private void Feldolgoz(ListaElem elem)
        {
            if(elem !=null)
            Console.WriteLine(elem);
        }
    }
    class Test
    {
        static void Run(string[] args)
        {
            LinkedList<int> lista = new LinkedList<int>();

            lista.ElejereBeszur(1);
            lista.ElejereBeszur(2);
            lista.ElejereBeszur(3);
            lista.Beszur(666);
            lista.Bejar();
        }
    }
}
