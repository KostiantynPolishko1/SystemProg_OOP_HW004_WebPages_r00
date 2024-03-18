using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public sealed class WebDbContext : db_aa534b_polxswp31Context
    {
        public WebDbContext() : base() { }

        public bool IsConnection() => this.Database.CanConnect();
    }
}
