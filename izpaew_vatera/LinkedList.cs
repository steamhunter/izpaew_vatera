using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{


    class LinkedList<T> :IEnumerable<T>,IEnumerator<T>
    {
        private int _count=-1;
        public int Count {
            get
            {
                if (_count == -1)
                {
                    int count = 0;
                    ListaElem p = fej;
                    while (p != null)
                    {
                        count++;

                        p = p.kovetkezo;
                    }
                    _count = count;
                    return count;
                }
                return _count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public T Current
        {
            get { return bejaroMutato.tartalom; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { throw new NotImplementedException(); } 
        }

        public bool MoveNext()
        {
            if (bejaroMutato == null)
            {
                bejaroMutato = fej;
                return true;
            }
            else if (bejaroMutato.kovetkezo != null)
            {
                bejaroMutato = bejaroMutato.kovetkezo;
                return true;
            }
            else
            {

                this.Reset();
                return false;
            }
        }

        private ListaElem fej;
        ListaElem bejaroMutato;
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
        public void Reset()
        {
            bejaroMutato = null;
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
