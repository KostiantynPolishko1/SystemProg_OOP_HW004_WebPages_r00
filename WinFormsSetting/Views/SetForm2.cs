using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class SetForm
    {
        private void BtnSetClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            this.mainForm.Enabled = true;
            this.mainForm.Activate();
            ResetSettings();
        }

        private void BtnSetSave_MouseClick(object sender, MouseEventArgs e)
        {
            bool flag = false;
            if (ckBxMenu[(int)Setting.AutoRun].Checked != crRegedit.flagsRegedit[0]) { crRegedit.setAutoRun(ckBxMenu[0].Checked); flag = true; }
            if (ckBxMenu[(int)Setting.Theme].Checked != crRegedit.flagsRegedit[1]) { crRegedit.setTheme(ckBxMenu[1].Checked); flag = true; }
            if (ckBxMenu[(int)Setting.Mode].Checked != crRegedit.flagsRegedit[2]) { crRegedit.setModeScreen(ckBxMenu[2].Checked); flag = true; }

            if (cmBxLang.SelectedItem.ToString() != crRegedit.language) { crRegedit.setLanguage(cmBxLang.SelectedItem.ToString()); flag = true; }

            if (flag) 
            {
                MessageBox.Show("Need restart App!");
                //ReloadPC(); 
            }
        }

        private void BtnSetReset_MouseClick(object sender, MouseEventArgs e)
        {
            ResetSettings();
        }

        private void BtnSetClear_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i != ckBxMenu.Count; i++) { ckBxMenu[i].Checked = false; }
        }

        private void ResetSettings()
        {
            for (int i = 0; i != ckBxMenu.Count; i++) { ckBxMenu[i].Checked = crRegedit.flagsRegedit[i]; }
        }

        private void ReloadPC()
        {
            string msg = string.Empty;
            try
            {
                Process.Start(new ProcessStartInfo() { FileName = "cmd.exe", Arguments = "/c restart -s -t 00" });
            }
            catch (SystemException sysEx) when (sysEx is InvalidOperationException || sysEx is Win32Exception || sysEx is ObjectDisposedException || sysEx is PlatformNotSupportedException)
            {
                msg = sysEx.Message;
            }
            finally
            {
                if(msg != string.Empty) { MessageBox.Show(msg); }
            }

        }
    }   
}
