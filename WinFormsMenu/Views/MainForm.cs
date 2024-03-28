using ConsoleApp.Controllers;
using ConsoleApp.Models;
using System.ComponentModel;
using System.Diagnostics;
using WinFormsApp.Controllers;
using WinFormsApp.Views.UserControls;
using WinFormsMenu;
using WinFormsMenu.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private WebController db;
        private PsiSet psiSet;
        private ControllerRegedit crRegedit;
        private ImageApp imgApp;

        public MainForm()
        {
            InitializeComponent();

            imgApp = new ImageApp();
            crRegedit = new ControllerRegedit();
            actions = new List<string>() { "Reset", "Clear", "Save" };

            setMenuClick(mnDefault, mnCustom, mnLoad, mnAutoRun, mnDark, mnFullScreen);
            setSettingChecked(mnAutoRun, mnDark, mnFullScreen);

            mncmLanguage.Items.AddRange(crRegedit.languages.Keys.ToArray());
            mncmActions.Items.AddRange(actions.ToArray());
            mnCustom.Enabled = false;
            mnLoad.Visible = false;

            setLightTheme(crRegedit.flagsRegedit[(int)Setting.Theme]);
            setStartSize(crRegedit.flagsRegedit[(int)Setting.Mode]);

            mncmLanguage.SelectedIndex = crRegedit.languages[crRegedit.language];

            createImgFlags(crRegedit.languages.Keys.ToList());
            pcBxFlag.Image = imgFlags.Images[crRegedit.languages[crRegedit.language]];
        }

        private void createImgFlags(in List<string> countries)
        {
            string path = imgApp.path + "\\flags\\";
            foreach (string country in countries)
            {
                imgFlags.Images.Add(Image.FromFile($"{path}{country}Flag.png"));
            }
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
            this.Controls.Add(new GridWebsUC(db, ref psiSet, imgApp ) { Location = new Point(10, 35) });
            mnConnection.Enabled = false;
        }

        private void setRegedit()
        {
            if (mncmActions.SelectedIndex == (int)_Action.Reset) { setSettingChecked(); }
            else if (mncmActions.SelectedIndex == (int)_Action.Clear) { setMenuClick(); }
            else if (mncmActions.SelectedIndex == (int)_Action.Save) { setSettingSave(); }

            mncmActions.SelectedIndex = -1;
            mncmActions.Text = "";
        }

        private void setSettingSave()
        {
            bool flag = false;

            if (mnAutoRun.Checked != crRegedit.flagsRegedit[(int)Setting.AutoRun]) { crRegedit.setAutoRun(mnAutoRun.Checked); flag = true; }
            if (mnDark.Checked != crRegedit.flagsRegedit[(int)Setting.Theme]) { crRegedit.setTheme(mnDark.Checked); flag = true; }
            if (mnFullScreen.Checked != crRegedit.flagsRegedit[(int)Setting.Mode]) { crRegedit.setModeScreen(mnFullScreen.Checked); flag = true; }

            if (mncmLanguage.SelectedItem.ToString() != crRegedit.language)
            {
                crRegedit.setLanguage(mncmLanguage.SelectedItem.ToString()); flag = true;
            }

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

        private void mnInfo_Click(object sender, EventArgs e)
        {
            new AppInfo().ShowDialog();
        }
    }
}