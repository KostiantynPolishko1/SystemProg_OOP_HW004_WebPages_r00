using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    public abstract class Names
    {
        public abstract List<string> LbNames { get; set; }
        public abstract List<string> BtnNames { get; set; }
        public abstract List<string> BtnNamesMF { get; set; }
        public abstract Dictionary<string, string> LbNamesWebUC { get; set; }
        public abstract Dictionary<string, string> BtnNamesWebUC { get; set; }
    }
}
