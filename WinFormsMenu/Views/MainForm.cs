using ConsoleApp.Controllers;
using ConsoleApp.Models;
using WinFormsApp.Views.UserControls;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private WebController db;
        private PsiSet psiSet;

        public MainForm()
        {
            InitializeComponent();
            languages = new List<string>() { "English", "Italian", "Russian" };

            setMenuClick(mnDefault, mnCustom, mnLoad);
            mncmLanguage.Items.AddRange(languages.ToArray());
            mnCustom.Enabled = false;
            mnLoad.Visible = false;
        }

        private void setMenuClick(params ToolStripMenuItem[] items)
        {
            for (int i = 0; i != items.Length; i++)
            {
                items[i].Checked = false;
                items[i].CheckOnClick = true;
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
    }
}