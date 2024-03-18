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
            LbSqlCon = new Label();
            SuspendLayout();
            // 
            // LbSqlCon
            // 
            LbSqlCon.AutoSize = true;
            LbSqlCon.Location = new Point(10, 10);
            LbSqlCon.Name = "LbSqlCon";
            LbSqlCon.Size = new Size(56, 20);
            LbSqlCon.TabIndex = 0;
            LbSqlCon.Text = "SqlCon";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(640, 760);
            Controls.Add(LbSqlCon);
            Name = "MainForm";
            Text = "WebPages";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label LbSqlCon;

        #endregion
    }
}