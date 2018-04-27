using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{
    class MaganSzemely : IElado
    {
        public delegate void GiftRecievedEventHandler(object src, EventArgs e);
        public event GiftRecievedEventHandler GiftRecied;
        public int Adoszam { get; set; }
        public IElado KontaktSzemely {
            get { return this; }
            set { throw new Exception("Magánszemély kontaktja nem álítható"); }
            }
        int ertekeles;
        public int Ertekeles {
            get { return ertekeles; }
            set { if (value >= 1 && value <= 5) ertekeles = value;
                else throw new Exception($"értékelés nem 1-5 közötti {this.Adoszam} Eladónál "); } }
        public LinkedList<Termek> TermekLista { get; set ; }
        public string Nev { get; set; }

        public void OnGiftRecieved()
        {
            if (GiftRecied != null)
                GiftRecied(this,EventArgs.Empty);
        }

        public MaganSzemely()
        {
            TermekLista = new LinkedList<Termek>();
        }
    }
}
