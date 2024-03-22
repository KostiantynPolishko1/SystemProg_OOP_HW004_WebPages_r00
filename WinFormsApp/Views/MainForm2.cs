using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Controllers;
using WinFormsApp.Models;

namespace WinFormsApp
{  
    partial class MainForm
    {
        private SetForm setForm;
        public Button BtnSetting { get; set; }
        private void InitializeComponent2()
        {
            BtnSetting = new Button();
            SuspendLayout();
            // 
            // BtnSetting
            // 
            BtnSetting.Location = new Point(590, 10);
            BtnSetting.Name = "BtnSetting";
            BtnSetting.Size = new Size(40, 40);
            BtnSetting.TabIndex = 0;
            //BtnSetting.Text = "Setting";
            setImageToObj(BtnSetting, "setting");
            BtnSetting.UseVisualStyleBackColor = true;
            BtnSetting.MouseClick += BtnSetting_MouseClick;
            // 
            // MainForm
            //
            Controls.Add(BtnSetting);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Normal;
            FormClosed += MainForm_FormClosed;
            ResumeLayout(false);           

            setLightTheme(crRegedit.flagsRegedit[(int)Setting.Theme]);
            setStartSize(crRegedit.flagsRegedit[(int)Setting.Mode]);

            createSetForm(crRegedit.language);
        }

        private void setImageToObj(in Control control, in string nameImg)
        {
            control.BackgroundImage = Image.FromFile(@"A:\OneDrive - ITSTEP\SystemProg\Projects\SystemProg_OOP_HW005_WebPages_r00\WinFormsApp\Resources\" + nameImg + ".png");
            control.BackgroundImageLayout = ImageLayout.Zoom;
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
