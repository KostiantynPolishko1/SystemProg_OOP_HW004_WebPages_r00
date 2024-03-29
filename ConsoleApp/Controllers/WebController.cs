﻿using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using ConsoleApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Collections;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Controllers
{
    public sealed class WebController : db_aa534b_polxswp31Context
    {
        public WebController() : base() { }

        public bool isConnection() => Database.CanConnect();

        public (bool, string) isSaveChanges()
        {
            try
            {
                this.SaveChanges();
                return (true, string.Empty);
            }
            catch(SystemException sysEx)
            {
                return (false, sysEx.Message);
            }
        }

        public string GetAllWebShortcuts(out List<webshortcut>? webShortcuts)
        {
            try
            {
                webShortcuts = webshortcuts.ToList();
                return string.Empty;
            }
            catch (SystemException sysEx)
            {
                webShortcuts = null;
                return sysEx.Message;
            }
        }

        public void AddWebToDb(in webtrack wt)
        {

            this.webtracks.Add(wt);
            (bool flag, string msg) = this.isSaveChanges();

            if (!flag)
            {
                Console.WriteLine(msg);
                //or write msg to logfile
            }
        }

        public void AddWebShortcutToDb(in webshortcut wst)
        {
            this.webshortcuts.Add(wst);
            (bool flag, string msg) = this.isSaveChanges();

            if (!flag)
            {
                Console.WriteLine(msg);
                //or write msg to logfile
            }
        }

        public static void writeInfo(in List<webshortcut> items)
        {
            foreach (webshortcut item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void writeInfo(in List<string> items)
        {
            foreach(string item in items)
            {
                Console.WriteLine($"\tAttention!\n\t{item}");
            }
        }

        public static (bool, webshortcut?) getWebShortCut(in Process prs)
        {
            webshortcut? wst = null;
            if (prs == null) { return (true, wst); }

            if (getUrl(prs, out string url)) { return (true, wst); }

            if (getWebName(prs, out string webname)) { return (true, wst); }

            return (false, new webshortcut(url, webname));
        }

        public static (bool, webtrack?) getWebTrack(in Process prs)
        {
            webtrack? wt = null;
            if (prs == null) { return (true, wt); }

            if (getOwner(prs, out string owner)) { return (true, wt); }

            if (getUrl(prs, out string url)) { return (true, wt); }

            getProcessName(prs, out string name);

            getDate(prs, out DateTime? date);

            getTime(prs, out TimeSpan? time);

            return (false, new webtrack() {date = date, time = time, url = url, name = name, owner = owner});
        }

        private static void getDate(in Process prs, out DateTime? date)
        {
            try
            {
                date = prs.StartTime.ToLocalTime().Date;
            }
            catch (SystemException sysEx) when(sysEx is NotSupportedException || sysEx is InvalidDataException || sysEx is Win32Exception) 
            {
                date = null;
            }
        }

        private static void getTime(in Process prs, out TimeSpan? time)
        {
            try
            {
                time = prs.StartTime.ToLocalTime().TimeOfDay;
            }
            catch (SystemException sysEx) when (sysEx is NotSupportedException || sysEx is InvalidDataException || sysEx is Win32Exception)
            {
                time = null;
            }
        }

        private static bool getUrl(in Process prs, out string url)
        {            
            try
            {
                if (findUrl(prs.StartInfo.ArgumentList.ToList(), out string urlname))
                { 
                    url = urlname;
                    return false;
                }

                url = string.Empty;
                return true;
            }
            catch
            {
                url = string.Empty;
                return true;
            }
        }

        private static bool getWebName(in Process prs, out string webname)
        {
            try
            {
                if (findUrl(prs.StartInfo.ArgumentList.ToList(), out string urlname))
                {
                    webname = urlname.Substring(urlname.IndexOf(":") + 3, (urlname.IndexOf(".") - urlname.IndexOf(":") - 3));
                    return false;
                }

                webname = string.Empty;
                return true;
            }
            catch
            {
                webname = string.Empty;
                return true;
            }
        }

        private static bool findUrl(List<string> args, out string urlname)
        {
            foreach (string arg in args)
            {
                if (arg.StartsWith("--new-tab"))
                {
                    urlname = arg.Substring(arg.IndexOf(" ") + 1);
                    return true;
                }
            }

            urlname = string.Empty;
            return false;
        }

        private static bool getOwner(in Process prs, out string owner)
        {
            string? cname = null;
            string? uname = null;

            try
            {
                foreach (DictionaryEntry de in prs.StartInfo.EnvironmentVariables)
                {
                    if (de.Key.ToString() == "COMPUTERNAME")
                    {
                        cname = de.Value.ToString();
                    }
                    else if (de.Key.ToString() == "USERNAME")
                    {
                        uname = de.Value.ToString();
                    }

                    if (cname != null && uname != null) { break; }
                }

                //cname = Environment.GetEnvironmentVariable("COMPUTERNAME");
                //uname = Environment.GetEnvironmentVariable("USERNAME");

                owner = $"{cname ??= "unknown"} | {uname ??= "-"}";
                return false;
            }
            catch
            {
                owner = string.Empty;
                return true;
            }
        }

        private static void getProcessName(in Process prs, out string name)
        {
            try
            {
                name = prs.StartInfo.FileName;
            }
            catch
            {
                name = "unknown";
            }
        }
    }
}
