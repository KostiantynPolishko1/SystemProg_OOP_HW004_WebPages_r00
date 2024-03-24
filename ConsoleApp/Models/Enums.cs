using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public enum Setting : int
    {
        AutoRun = 0,
        Theme,
        Mode
    }

    public enum _Action : int
    {
        Reset = 0,
        Clear,
        Save
    }
}
