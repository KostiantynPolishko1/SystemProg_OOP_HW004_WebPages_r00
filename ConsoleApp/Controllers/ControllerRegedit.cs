using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;
using ConsoleApp.Models;

namespace WinFormsApp.Controllers
{
    public class ControllerRegedit
    {
        public readonly Dictionary<string, int> languages;
        public readonly string language;
        private const int regeditCount = 3;
        public List<bool> flagsRegedit { get; private set; }
        private string? prcName { get; set; }

        public ControllerRegedit()
        {
            languages = new Dictionary<string, int>() { { "English", 0 }, { "Italian", 1 }, { "Russian", 2 } };
            flagsRegedit = new List<bool>(regeditCount);

            for (int i = 0; i != regeditCount; i++)
            {
                flagsRegedit.Add(false);
            }

            prcName = Process.GetCurrentProcess().ProcessName;
            prcName ??= "process";

            flagsRegedit[(int)Setting.AutoRun] = getAutoRun();
            flagsRegedit[(int)Setting.Theme] = getTheme();
            flagsRegedit[(int)Setting.Mode] = getModeScreen();

            language = getLanguage();
        }

        private bool getAutoRun()
        {
            bool flag = false;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                if (key != null)
                {
                    try
                    {
                        object? obj = key.GetValue(prcName, null);
                        if (obj != null) { flag = true; }
                    }
                    catch { }
                    finally { key.Close(); }
                }
            }
            return flag;
        }

        private bool getModeScreen()
        {
            bool flag = false;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\" + prcName))
            {
                if (key != null)
                {
                    try
                    {
                        object? obj = key.GetValue("AppStartSize", null);
                        if (obj != null && obj.ToString() == "2") { flag = true; }
                    }
                    catch { }
                    finally { key.Close(); }
                }
            }
            return flag;
        }

        private bool getTheme()
        {
            bool flag = false;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\" + prcName))
            {
                if (key != null)
                {
                    try
                    {
                        object? obj = key.GetValue("AppLightTheme", null);
                        if (obj != null && obj.ToString() == "0") { flag = true; }
                    }
                    catch { }
                    finally { key.Close(); }
                }
            }
            return flag;
        }

        private string getLanguage()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\" + prcName))
            {
                if (key != null)
                {
                    try
                    {
                        object? obj = key.GetValue("Language", null);
                        if (obj != null) { return obj.ToString(); }
                        else { setLanguage(languages.Keys.ToList().FirstOrDefault("English")); }
                    }
                    catch { }
                    finally { key.Close(); }
                }
            }

            return languages.Keys.ToList().FirstOrDefault("English");
        }

        public void setAutoRun(bool flag)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key != null)
                {
                    if (flag) { key.SetValue(prcName, $"{Environment.CurrentDirectory}\\{prcName}.exe", RegistryValueKind.String); }
                    else
                    {
                        if (getAutoRun()) { key.DeleteValue(prcName); }
                    }
                    key.Close();
                }
            }
        }

        public void setTheme(bool flag)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\" + prcName, true))
            {
                if (key != null)
                {
                    if (flag) { key.SetValue("AppLightTheme", 0, RegistryValueKind.DWord); }
                    else { key.SetValue("AppLightTheme", 1, RegistryValueKind.DWord); }
                    key.Close();
                }
            }
        }

        public void setModeScreen(bool flag)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\" + prcName, true))
            {
                if (key != null)
                {
                    if (flag) { key.SetValue("AppStartSize", 2, RegistryValueKind.DWord); }
                    else { key.SetValue("AppStartSize", 1, RegistryValueKind.DWord); }
                    key.Close();
                }
            }
        }

        public void setLanguage(in string language)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\" + prcName, true))
            {
                if (key != null)
                {
                    key.SetValue("Language", language, RegistryValueKind.String);
                    key.Close();
                }
            }            
        }
    }
}
