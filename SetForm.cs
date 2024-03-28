using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Controllers;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class SetForm : Form
    {
        private Form mainForm;
        private readonly Point posSetForm;
        private ControllerRegedit crRegedit;

        private readonly List<string> LbNames;
        private readonly List<string> BtnNames;
        private readonly List<string> ckBxNames;

        private readonly List<Label> LbMenu;
        private readonly List<Button> BtnMenu;
        private readonly List<CheckBox> ckBxMenu;

        private readonly Size LbSize;
        private readonly Size BtnSize;
        private readonly Size ckBxSize;

        public SetForm()
        {
            InitializeComponent();
        }

        public SetForm(in Names names) : this()
        {
            LbNames = names.LbNames;
            LbMenu = new List<Label>(LbNames.Count);
            LbSize = new Size(100, 20);

            BtnNames = names.BtnNames;
            BtnMenu = new List<Button>(BtnNames.Count);
            BtnSize = new Size(60, 30);

            ckBxNames = new List<string>() { "AutoRun", "Theme", "Mode" };
            ckBxMenu = new List<CheckBox>(ckBxNames.Count);
            ckBxSize = new Size(20, 20);

            InitLabes() ;

            InitButtons();

            InitckBox();
        }

        public SetForm(in Form mainForm, in ControllerRegedit crRegedit, in Point posSetForm, in Names names) : this(names)
        {
            this.mainForm = mainForm;
            this.crRegedit = crRegedit;
            this.posSetForm = posSetForm;

            StartPosition = FormStartPosition.Manual;
            cmBxLang.DataSource = this.crRegedit.languages.Keys.ToList();
            cmBxLang.SelectedIndex = this.crRegedit.languages[this.crRegedit.language];

            for (int i = 0; i != ckBxNames.Count; i++) { ckBxMenu[i].Checked = crRegedit.flagsRegedit[i]; }
        }

        private void InitLabes(int offsetY = 0)
        {
            for (int i = 0; i != LbNames.Count; i++)
            {
                CreateObj(out Label lb, LbSize, new Point(10, 20 + offsetY), $"Lb{LbNames[i]}", LbNames[i]);
                LbMenu.Add(lb);
                this.Controls.Add(lb);
                offsetY += LbSize.Height + 10;
            }
        }

        private void InitckBox()
        {
            for (int i = 0; i != ckBxNames.Count; i++)
            {
                CreateObj(out CheckBox ckBx, ckBxSize, new Point(LbMenu[i].Left + LbMenu[i].Width + 10, LbMenu[i].Top), $"Btn{ckBxNames[i]}", ckBxNames[i]);
                ckBxMenu.Add(ckBx);
                this.Controls.Add(ckBx);
            }
        }

        private void InitButtons(int offsetY = 0)
        {
            for (int i = 0; i != BtnNames.Count; i++)
            {
                CreateObj(out Button btn, BtnSize, new Point(this.Width - BtnSize.Width - 10, 20 + offsetY), $"Btn{BtnNames[i]}", BtnNames[i]);
                BtnMenu.Add(btn);
                this.Controls.Add(btn);
                offsetY += BtnSize.Height + 10;
            }

            BtnMenu[0].MouseClick += BtnSetClose_MouseClick;
            BtnMenu[1].MouseClick += BtnSetSave_MouseClick;
            BtnMenu[2].MouseClick += BtnSetReset_MouseClick;
            BtnMenu[3].MouseClick += BtnSetClear_MouseClick;
        }

        private void CreateObj(out Label label, in Size? size, in Point point, in string name, in string txt)
        {
            label = new Label() { Name = name, Text = txt, Size = size ?? this.LbSize, Location = point };
        }
        private void CreateObj(out Button button, in Size? size, in Point point, in string name, in string txt)
        {
            button = new Button() { Name = name, Text = txt, Size = size ?? this.LbSize, Location = point };
        }

        private void CreateObj(out CheckBox ckBox, in Size? size, in Point point, in string name, in string txt)
        {
            ckBox = new CheckBox() { Name = name, Text = txt, Size = size ?? this.LbSize, Location = point };
        }

        public void showFormOverMain(bool flag)
        {
            Visible = true;

            if (flag)
            {                
                TopMost = true;
            }

            Location = posSetForm;          
        }
    }
}
