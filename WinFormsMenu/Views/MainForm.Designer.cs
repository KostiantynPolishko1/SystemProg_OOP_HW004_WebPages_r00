namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mnMain = new MenuStrip();
            mnConnection = new ToolStripMenuItem();
            mnDefault = new ToolStripMenuItem();
            mnLoad = new ToolStripMenuItem();
            mnCustom = new ToolStripMenuItem();
            mnSetting = new ToolStripMenuItem();
            mnAutoRun = new ToolStripMenuItem();
            mnDark = new ToolStripMenuItem();
            mnFullScreen = new ToolStripMenuItem();
            mnLanguages = new ToolStripMenuItem();
            mncmLanguage = new ToolStripComboBox();
            mncmActions = new ToolStripComboBox();
            mnInfo = new ToolStripMenuItem();
            imgFlags = new ImageList(components);
            pcBxFlag = new PictureBox();
            mnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBxFlag).BeginInit();
            SuspendLayout();
            // 
            // mnMain
            // 
            mnMain.BackColor = Color.FromArgb(210, 226, 252);
            mnMain.ImageScalingSize = new Size(20, 20);
            mnMain.Items.AddRange(new ToolStripItem[] { mnConnection, mnSetting, mnInfo });
            mnMain.Location = new Point(0, 0);
            mnMain.Name = "mnMain";
            mnMain.Size = new Size(645, 28);
            mnMain.TabIndex = 0;
            mnMain.Text = "mnMain";
            // 
            // mnConnection
            // 
            mnConnection.DropDownItems.AddRange(new ToolStripItem[] { mnDefault, mnCustom });
            mnConnection.Name = "mnConnection";
            mnConnection.Size = new Size(98, 24);
            mnConnection.Text = "Connection";
            // 
            // mnDefault
            // 
            mnDefault.DropDownItems.AddRange(new ToolStripItem[] { mnLoad });
            mnDefault.Name = "mnDefault";
            mnDefault.Size = new Size(142, 26);
            mnDefault.Text = "Default";
            mnDefault.CheckedChanged += mnDefault_CheckedChanged;
            // 
            // mnLoad
            // 
            mnLoad.Name = "mnLoad";
            mnLoad.Size = new Size(125, 26);
            mnLoad.Text = "Load";
            mnLoad.CheckedChanged += mnLoad_CheckedChanged;
            // 
            // mnCustom
            // 
            mnCustom.Name = "mnCustom";
            mnCustom.Size = new Size(142, 26);
            mnCustom.Text = "Custom";
            // 
            // mnSetting
            // 
            mnSetting.DropDownItems.AddRange(new ToolStripItem[] { mnAutoRun, mnDark, mnFullScreen, mnLanguages, mncmActions });
            mnSetting.Name = "mnSetting";
            mnSetting.Size = new Size(70, 24);
            mnSetting.Text = "Setting";
            mnSetting.DropDownOpened += mnSetting_DropDownOpened;
            mnSetting.Click += mnSetting_Click;
            // 
            // mnAutoRun
            // 
            mnAutoRun.Name = "mnAutoRun";
            mnAutoRun.Size = new Size(195, 26);
            mnAutoRun.Text = "AutoRun";
            // 
            // mnDark
            // 
            mnDark.Name = "mnDark";
            mnDark.Size = new Size(195, 26);
            mnDark.Text = "Dark";
            // 
            // mnFullScreen
            // 
            mnFullScreen.Name = "mnFullScreen";
            mnFullScreen.Size = new Size(195, 26);
            mnFullScreen.Text = "Full Screen";
            // 
            // mnLanguages
            // 
            mnLanguages.DropDownItems.AddRange(new ToolStripItem[] { mncmLanguage });
            mnLanguages.Name = "mnLanguages";
            mnLanguages.Size = new Size(195, 26);
            mnLanguages.Text = "Languages";
            // 
            // mncmLanguage
            // 
            mncmLanguage.Name = "mncmLanguage";
            mncmLanguage.Size = new Size(121, 28);
            // 
            // mncmActions
            // 
            mncmActions.DropDownStyle = ComboBoxStyle.DropDownList;
            mncmActions.Name = "mncmActions";
            mncmActions.Size = new Size(121, 28);
            // 
            // mnInfo
            // 
            mnInfo.Name = "mnInfo";
            mnInfo.Size = new Size(49, 24);
            mnInfo.Text = "Info";
            mnInfo.Click += mnInfo_Click;
            // 
            // imgFlags
            // 
            imgFlags.ColorDepth = ColorDepth.Depth32Bit;
            imgFlags.ImageSize = new Size(60, 30);
            imgFlags.TransparentColor = Color.Transparent;
            // 
            // pcBxFlag
            // 
            pcBxFlag.Location = new Point(555, 0);
            pcBxFlag.Margin = new Padding(0);
            pcBxFlag.Name = "pcBxFlag";
            pcBxFlag.Size = new Size(90, 30);
            pcBxFlag.SizeMode = PictureBoxSizeMode.Zoom;
            pcBxFlag.TabIndex = 1;
            pcBxFlag.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(645, 760);
            Controls.Add(pcBxFlag);
            Controls.Add(mnMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = mnMain;
            Name = "MainForm";
            Text = "WebPages";
            mnMain.ResumeLayout(false);
            mnMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBxFlag).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnMain;
        private ToolStripMenuItem mnConnection;
        private ToolStripMenuItem mnDefault;
        private ToolStripMenuItem mnLoad;
        private ToolStripMenuItem mnCustom;
        private ToolStripMenuItem mnSetting;
        private ToolStripMenuItem mnInfo;
        private List<string> languages;
        private List<string> actions;
        private ToolStripMenuItem mnAutoRun;
        private ToolStripMenuItem mnDark;
        private ToolStripMenuItem mnFullScreen;
        private ToolStripMenuItem mnLanguages;
        private ToolStripComboBox mncmActions;
        private ToolStripComboBox mncmLanguage;
        private ImageList imgFlags;
        private PictureBox pcBxFlag;
    }
}