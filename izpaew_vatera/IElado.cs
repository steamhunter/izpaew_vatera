using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{
    interface IElado
    {
        int Adoszam { get; set; }
        IElado KontaktSzemely { get; set; }
        int Ertekeles { get; set; }
        LinkedList<Termek> TermekLista { get; set; }
    }
}
