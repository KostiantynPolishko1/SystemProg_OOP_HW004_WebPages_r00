﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public partial class webtrack
    {
        public webtrack() : 
            this (0, null, null, "empty", "unknown", "unknown") { }

        public webtrack(in string url, in string name, in string owner) : 
            this (0, null, null, url, name, owner) { }

        public webtrack(in DateTime date, in TimeSpan time, in string url, in string name, in string owner) :
            this(0, date, time, url, name, owner)
        { }

        public webtrack(int id, DateTime? date, TimeSpan? time, in string url, in string name, in string owner)
        {
            this.id = id;
            this.date = date;
            this.time = time;
            this.url = url;
            this.name = name;
            this.owner = owner;
        }

        public override string ToString()
        {
            return $"{id} | {date} | {time} | {url} | {name} | {owner}";
        }
    }
}
 