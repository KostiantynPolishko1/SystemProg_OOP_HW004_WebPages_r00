using ConsoleApp.Controllers;
using ConsoleApp.Models;
using System.ComponentModel;
using System.Diagnostics;
using WinFormsApp.Controllers;
using WinFormsApp.Views.UserControls;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private WebController db;
        private PsiSet psiSet;
        private ControllerRegedit crRegedit;

        public MainForm()
        {
            InitializeComponent();

            crRegedit = new ControllerRegedit();
            languages = new List<string>() { "English", "Italian", "Russian" };
            actions = new List<string>() { "Reset", "Clear", "Save" };

            setMenuClick(mnDefault, mnCustom, mnLoad, mnAutoRun, mnDark, mnFullScreen);
            setSettingChecked(mnAutoRun, mnDark, mnFullScreen);

            mncmLanguage.Items.AddRange(languages.ToArray());
            mncmActions.Items.AddRange(actions.ToArray());
            mnCustom.Enabled = false;
            mnLoad.Visible = false;

            setLightTheme(crRegedit.flagsRegedit[(int)Setting.Theme]);
            setStartSize(crRegedit.flagsRegedit[(int)Setting.Mode]);

        }

        private void setLightTheme(bool flag)
        {
            if (flag) { BackColor = Color.FromArgb(119, 120, 122); }
        }

        private void setStartSize(bool flag)
        {
            if (flag) { WindowState = FormWindowState.Maximized; }
        }

        private void setMenuClick(params ToolStripMenuItem[] items)
        {
            for (int i = 0; i != items.Length; i++)
            {
                items[i].Checked = false;
                items[i].CheckOnClick = true;
            }
        }

        private void setSettingChecked(params ToolStripMenuItem[] items)
        {
            for (int i = 0; i != items.Length; i++)
            {
                items[i].Checked = crRegedit.flagsRegedit[i];
            }
        }

        private void mnDefault_CheckedChanged(object sender, EventArgs e)
        {
            db = new WebController() { };
            dbIsConnection();

            mnDefault.CheckOnClick = false;
            mnLoad.Visible = true;

            psiSet = new PsiSet();
        }

        private void dbIsConnection()
        {
            if (!db.isConnection())
            {
                MessageBox.Show("No connection Db");
                Environment.Exit(1);
            }
        }

        private void mnLoad_CheckedChanged(object sender, EventArgs e)
        {
            this.Controls.Add(new GridWebsUC(db, ref psiSet) { Location = new Point(10, 35) });
            mnConnection.Enabled = false;
        }

        private void setRegedit()
        {
            if (mncmActions.SelectedIndex == (int)_Action.Reset) { setSettingChecked(mnAutoRun, mnDark, mnFullScreen); }
            else if (mncmActions.SelectedIndex == (int)_Action.Clear) { setMenuClick(mnAutoRun, mnDark, mnFullScreen); }
            else if (mncmActions.SelectedIndex == (int)_Action.Save) { setSettingSave(mnAutoRun, mnDark, mnFullScreen); }

            mncmActions.SelectedIndex = -1;
            mncmActions.Text = "";
        }

        private void setSettingSave(params ToolStripMenuItem[] items)
        {
            bool flag = false;
            
            if (mnAutoRun.Checked != crRegedit.flagsRegedit[(int)Setting.AutoRun]) { crRegedit.setAutoRun(mnAutoRun.Checked); flag = true; }
            if (mnDark.Checked != crRegedit.flagsRegedit[(int)Setting.Theme]) { crRegedit.setTheme(mnDark.Checked); flag = true; }
            if (mnFullScreen.Checked != crRegedit.flagsRegedit[(int)Setting.Mode]) { crRegedit.setModeScreen(mnFullScreen.Checked); flag = true; }

            //if (mncmLanguage.SelectedItem.ToString() != crRegedit.language) { crRegedit.setLanguage(mncmLanguage.SelectedItem.ToString()); flag = true; }

            if (flag) { MessageBox.Show("ReloadApp"); /*ReloadPC();*/ }
        }

        private void mnSetting_DropDownOpened(object sender, EventArgs e)
        {           
            mnSetting.DropDown.AutoClose = false;
        }

        private void mnSetting_Click(object sender, EventArgs e)
        {
            if (mncmActions.SelectedIndex != -1) 
            {
                setRegedit();
                mnSetting.DropDown.AutoClose = true;
            }
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
                if (msg != string.Empty) { MessageBox.Show(msg); }
            }

        }
    }
}