using ConsoleApp.Controllers;
using ConsoleApp.Models;
using WinFormsApp.Controllers;
using WinFormsApp.Views.UserControls;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private string[] nameBtns;
        private List<Button> menuBtns;
        private WebController db;
        private PsiSet psiSet;

        public MainForm()
        {
            crRegedit = new ControllerRegedit();

            InitializeComponent();
            InitializeComponent2();

            nameBtns = new string[] { "Default", "Custom", "Load", "Setting"};
            menuBtns = new List<Button>(nameBtns.Length);

            for(int i = 0; i < nameBtns.Length; i++) { menuBtns.Add(new Button()); }
        }

        private void setNameBtns(in string language)
        {
            switch (language)
            {
                case "Italian":
                    nameBtns = new NamesIt().BtnNamesMF.ToArray();
                    break;
                case "Russian":
                    nameBtns = new NamesRu().BtnNamesMF.ToArray();
                    break;
                default:
                    nameBtns = new NamesEn().BtnNamesMF.ToArray();
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateObj(menuBtns[0], new Point(LbSqlCon.Left + LbSqlCon.Width + 10, LbSqlCon.Top), $"Btn{nameBtns[0]}", nameBtns[0]);
            CreateObj(menuBtns[1], new Point(menuBtns[0].Left + menuBtns[0].Width + 10, LbSqlCon.Top), $"Btn{nameBtns[1]}", nameBtns[1]);

            menuBtns[0].MouseClick += BtnDefault_MouseClick;
        }

        private void CreateObj(in Control control, in Point point, string Name, string Text)
        {
            control.Name = Name;
            control.Text = Text;
            control.Size = new Size(100, 30);
            control.Location = point;
            control.TabIndex = 1;

            if (control is Button)
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.Black;
            }

            this.Controls.Add(control);
        }

        private void BtnDefault_MouseClick(object sender, MouseEventArgs e)
        {
            db = new WebController() { };
            dbIsConnection();

            psiSet = new PsiSet();

            menuBtns[0].BackColor = Color.DarkGreen;
            menuBtns[0].ForeColor = Color.White;

            menuBtns[1].BackColor = Color.Gray;
            menuBtns[1].Enabled = false;
            menuBtns[1].Visible = false;

            CreateObj(menuBtns[2], new Point(menuBtns[0].Left + menuBtns[0].Width + 10, LbSqlCon.Top), $"{nameBtns[2]}Btn", nameBtns[2]);
            menuBtns[2].BackColor = Color.Blue;
            menuBtns[2].ForeColor = Color.White;
            menuBtns[2].MouseClick += BtnLoad_MouseClick;

        }

        private void dbIsConnection()
        {
            if (!db.isConnection())
            {
                MessageBox.Show("No connection Db");
                Environment.Exit(1);
            }
        }

        private void BtnLoad_MouseClick(object sender, MouseEventArgs e)
        {
            menuBtns[0].Enabled = false;
            menuBtns[2].Enabled = false;

            this.Controls.Add(new GridWebsUC(db, ref psiSet) { Location = new Point(LbSqlCon.Left, menuBtns[0].Top + menuBtns[0].Height + 10) });
        }
    }
}