using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{
    class MaganSzemely : IElado
    {
        public int Adoszam { get; set; }
        public IElado KontaktSzemely {
            get { return this; }
            set { throw new Exception("Magánszemély kontaktja nem álítható"); }
            }
        int ertekeles;
        public int Ertekeles {
            get { return ertekeles; }
            set { if (value >= 1 && value <= 5) ertekeles = value;
                else throw new Exception($"értékelás nem 1-5 közötti {this.Adoszam} Eladónál "); } }
        public LinkedList<Termek> TermekLista { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        
    }
}
