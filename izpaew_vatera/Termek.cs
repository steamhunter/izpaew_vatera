using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{
    class Termek : IComparable
    {

        public string Nev { get; set; }
        public int Cikkszam { get; set; }
        public int CompareTo(object obj)
        {
            return Nev.CompareTo(obj);
        }
    }
}
