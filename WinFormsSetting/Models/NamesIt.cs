using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    public class NamesIt : Names
    {
        public override List<string> LbNames { get; set; }
        public override List<string> BtnNames { get; set; }

        public NamesIt()
        {
            LbNames = new List<string>() { "Autorun", "Sondo scuro", "Schermo intero", "Lingua" };
            BtnNames = new List<string>() { "Chiud", "Salva", "Ripristina", "Cancella" };
        }
    }
}
