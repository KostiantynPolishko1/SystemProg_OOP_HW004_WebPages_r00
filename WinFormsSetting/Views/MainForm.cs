using WinFormsApp.Controllers;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private SetForm setForm;
        private ControllerRegedit crRegedit;

        public MainForm()
        {
            InitializeComponent();

            crRegedit = new ControllerRegedit();

            setLightTheme(crRegedit.flagsRegedit[(int)Setting.Theme]);
            setStartSize(crRegedit.flagsRegedit[(int)Setting.Mode]);

            createSetForm(crRegedit.language);
        }

        private void createSetForm(in string language)
        {
            switch (language)
            {
                case "Italian":
                    setForm = new SetForm(this, crRegedit, getPosSetForm(crRegedit.flagsRegedit[(int)Setting.Mode]), new NamesIt());
                    break;
                case "Russian":
                    setForm = new SetForm(this, crRegedit, getPosSetForm(crRegedit.flagsRegedit[(int)Setting.Mode]), new NamesRu());
                    break;
                default:
                    setForm = new SetForm(this, crRegedit, getPosSetForm(crRegedit.flagsRegedit[(int)Setting.Mode]), new NamesEn());
                    break;
            }          
        }

        private void BtnSetting_MouseClick(object sender, MouseEventArgs e)
        {
            this.Enabled = false;                    
            setForm.showFormOverMain(crRegedit.flagsRegedit[(int)Setting.Mode]);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            setForm.Close();
        }

        private void setLightTheme(bool flag)
        {
            if (flag) { BackColor = Color.FromArgb(119, 120, 122); }
        }

        private void setStartSize(bool flag)
        {           
            if (flag) { WindowState = FormWindowState.Maximized; }
        }

        private Point getPosSetForm(bool flag)
        {
            if (flag) { return new Point(BtnSetting.Left + BtnSetting.Width + 10, BtnSetting.Top); }
            return new Point(Left + Width, Top);
        }
    }
}