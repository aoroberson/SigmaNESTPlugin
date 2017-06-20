namespace SigmaNESTPlugin
{
    partial class frmConfig
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
            this.btnDone = new System.Windows.Forms.Button();
            this.cbo_1 = new System.Windows.Forms.ComboBox();
            this.gbo_1 = new System.Windows.Forms.GroupBox();
            this.gbo_2 = new System.Windows.Forms.GroupBox();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.gbo_1.SuspendLayout();
            this.gbo_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Location = new System.Drawing.Point(51, 125);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(87, 26);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // cbo_1
            // 
            this.cbo_1.FormattingEnabled = true;
            this.cbo_1.Location = new System.Drawing.Point(5, 18);
            this.cbo_1.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_1.Name = "cbo_1";
            this.cbo_1.Size = new System.Drawing.Size(150, 21);
            this.cbo_1.TabIndex = 3;
            // 
            // gbo_1
            // 
            this.gbo_1.Controls.Add(this.cbo_1);
            this.gbo_1.Location = new System.Drawing.Point(13, 13);
            this.gbo_1.Name = "gbo_1";
            this.gbo_1.Size = new System.Drawing.Size(160, 46);
            this.gbo_1.TabIndex = 5;
            this.gbo_1.TabStop = false;
            this.gbo_1.Text = "Select Machine";
            // 
            // gbo_2
            // 
            this.gbo_2.Controls.Add(this.txt_1);
            this.gbo_2.Location = new System.Drawing.Point(13, 65);
            this.gbo_2.Name = "gbo_2";
            this.gbo_2.Size = new System.Drawing.Size(160, 46);
            this.gbo_2.TabIndex = 6;
            this.gbo_2.TabStop = false;
            this.gbo_2.Text = "OnPartSave Event Message";
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(7, 20);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(147, 20);
            this.txt_1.TabIndex = 0;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 159);
            this.Controls.Add(this.gbo_2);
            this.Controls.Add(this.gbo_1);
            this.Controls.Add(this.btnDone);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.gbo_1.ResumeLayout(false);
            this.gbo_2.ResumeLayout(false);
            this.gbo_2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ComboBox cbo_1;
        private System.Windows.Forms.GroupBox gbo_1;
        private System.Windows.Forms.GroupBox gbo_2;
        private System.Windows.Forms.TextBox txt_1;

    }
}