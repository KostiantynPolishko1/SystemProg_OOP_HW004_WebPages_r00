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
        public override List<string> BtnNamesMF { get; set; }
        public override Dictionary<string, string> LbNamesWebUC { get; set; }
        public override Dictionary<string, string> BtnNamesWebUC { get; set; }

        public NamesIt()
        {
            LbNames = new List<string>() { "Autorun", "Sondo scuro", "Schermo intero", "Lingua" };
            BtnNames = new List<string>() { "Chiud", "Salva", "Ripristina", "Cancella" };
            BtnNamesMF = new List<string>() { "Predefinito", "Personalizzato", "Carico" };

            LbNamesWebUC = new Dictionary<string, string>()
            {
                { "Name", "Nome" },
                { "Link", "Collegamento" },
                { "State", "Stato" }
            };

            BtnNamesWebUC = new Dictionary<string, string>()
            {
                { "Save", "Salva" },
                { "Close", "Chuidi" },
                { "Message", "Messaggio" }
            };
        }
    }
}
