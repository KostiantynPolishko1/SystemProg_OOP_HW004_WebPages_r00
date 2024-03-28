using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp.Models
{
    public class NamesEn : Names
    {
        public override List<string> LbNames { get; set; }
        public override List<string> BtnNames { get; set; }
        public override List<string> BtnNamesMF { get; set; }
        public override Dictionary<string, string> LbNamesWebUC { get; set; }
        public override Dictionary<string, string> BtnNamesWebUC { get; set; }

        public NamesEn()
        {
            LbNames = new List<string>() { "AutoRun", "Dark", "FullScreen", "Language" };
            BtnNames = new List<string>() { "Close", "Save", "Reset", "Clear" };
            BtnNamesMF = new List<string>() { "Default", "Custom", "Load" };

            LbNamesWebUC = new Dictionary<string, string>()
            {
                { "Name", "Name" },
                { "Link", "Link" },
                { "State", "State" }
            };

            BtnNamesWebUC = new Dictionary<string, string>()
            {
                { "Save", "Save" },
                { "Close", "Close" },
                { "Message", "Message" }
            };
        }
    }
}
