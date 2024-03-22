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
    }
}
