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
        private void InitializeComponent()
        {
            BtnSetting = new Button();
            SuspendLayout();
            // 
            // BtnSetting
            // 
            BtnSetting.Location = new Point(340, 10);
            BtnSetting.Name = "BtnSetting";
            BtnSetting.Size = new Size(40, 40);
            BtnSetting.TabIndex = 0;
            BtnSetting.Text = "Setting";
            BtnSetting.UseVisualStyleBackColor = true;
            BtnSetting.MouseClick += BtnSetting_MouseClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 100);
            Controls.Add(BtnSetting);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Normal;
            FormClosed += MainForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        public Button BtnSetting { get; set;}
    }
}