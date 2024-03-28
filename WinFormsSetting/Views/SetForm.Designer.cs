namespace WinFormsApp
{
    partial class SetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {          
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetForm));
            cmBxLang = new ComboBox();
            SuspendLayout();
            // 
            // cmBxLang
            // 
            //cmBxLang.DataSource = languages;
            cmBxLang.FormattingEnabled = true;
            cmBxLang.Location = new Point(10, 160);
            cmBxLang.Name = "cmBxLang";
            cmBxLang.Size = new Size(200, 28);
            cmBxLang.TabIndex = 0;
            // 
            // SetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 200);
            Controls.Add(cmBxLang);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SetForm";
            Text = "SetForm";
            TopMost = true;
            Activate();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmBxLang;
    }
}