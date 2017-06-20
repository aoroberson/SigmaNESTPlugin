namespace SigmaNESTPlugin
{
    partial class frmExecute
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
            this.btnAboutSN = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnLoadWS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAboutSN
            // 
            this.btnAboutSN.Location = new System.Drawing.Point(49, 11);
            this.btnAboutSN.Margin = new System.Windows.Forms.Padding(2);
            this.btnAboutSN.Name = "btnAboutSN";
            this.btnAboutSN.Size = new System.Drawing.Size(87, 26);
            this.btnAboutSN.TabIndex = 0;
            this.btnAboutSN.Text = "About";
            this.btnAboutSN.UseVisualStyleBackColor = true;
            this.btnAboutSN.Click += new System.EventHandler(this.btnAboutSN_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(49, 125);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(87, 26);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnLoadWS
            // 
            this.btnLoadWS.Location = new System.Drawing.Point(49, 41);
            this.btnLoadWS.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadWS.Name = "btnLoadWS";
            this.btnLoadWS.Size = new System.Drawing.Size(87, 26);
            this.btnLoadWS.TabIndex = 2;
            this.btnLoadWS.Text = "Load WS";
            this.btnLoadWS.UseVisualStyleBackColor = true;
            this.btnLoadWS.Click += new System.EventHandler(this.btnLoadWS_Click);
            // 
            // frmExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 159);
            this.Controls.Add(this.btnLoadWS);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnAboutSN);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmExecute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExecute";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAboutSN;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnLoadWS;
    }
}