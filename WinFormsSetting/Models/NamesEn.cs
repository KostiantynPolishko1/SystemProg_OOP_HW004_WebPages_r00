using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    public class NamesEn : Names
    {
        public override List<string> LbNames { get; set; }
        public override List<string> BtnNames { get; set; }

        public NamesEn()
        {
            LbNames = new List<string>() { "AutoRun", "Dark", "FullScreen", "Language" };
            BtnNames = new List<string>() { "Close", "Save", "Reset", "Clear" };
        }
    }
}
