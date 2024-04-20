namespace TextBoxTime
{
    partial class TextControlHMS
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxS = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.textBoxH);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxM);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.textBoxS);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(75, 20);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseClick);
            this.flowLayoutPanel1.MouseEnter += new System.EventHandler(this.flowLayoutPanel1_MouseEnter);
            // 
            // textBoxH
            // 
            this.textBoxH.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxH.Location = new System.Drawing.Point(3, 3);
            this.textBoxH.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.textBoxH.MaxLength = 2;
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(15, 13);
            this.textBoxH.TabIndex = 0;
            this.textBoxH.Text = "00";
            this.textBoxH.TextChanged += new System.EventHandler(this.textBoxH_TextChanged);
            this.textBoxH.Enter += new System.EventHandler(this.textBoxH_Enter);
            this.textBoxH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxH_KeyDown);
            this.textBoxH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxH_MouseDown);
            this.textBoxH.MouseEnter += new System.EventHandler(this.textBoxH_MouseEnter);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // textBoxM
            // 
            this.textBoxM.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxM.Location = new System.Drawing.Point(28, 3);
            this.textBoxM.Margin = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.textBoxM.MaxLength = 2;
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(15, 13);
            this.textBoxM.TabIndex = 2;
            this.textBoxM.Text = "00";
            this.textBoxM.TextChanged += new System.EventHandler(this.textBoxM_TextChanged);
            this.textBoxM.Enter += new System.EventHandler(this.textBoxM_Enter);
            this.textBoxM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxM_KeyDown);
            this.textBoxM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxM_MouseDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // textBoxS
            // 
            this.textBoxS.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxS.Location = new System.Drawing.Point(55, 3);
            this.textBoxS.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.textBoxS.MaxLength = 2;
            this.textBoxS.Name = "textBoxS";
            this.textBoxS.Size = new System.Drawing.Size(15, 13);
            this.textBoxS.TabIndex = 4;
            this.textBoxS.Text = "00";
            this.textBoxS.TextChanged += new System.EventHandler(this.textBoxS_TextChanged);
            this.textBoxS.Enter += new System.EventHandler(this.textBoxS_Enter);
            this.textBoxS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxS_KeyDown);
            this.textBoxS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxS_MouseDown);
            // 
            // TextControlHMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TextControlHMS";
            this.Size = new System.Drawing.Size(75, 20);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextControlHMS_KeyDown);
            this.Leave += new System.EventHandler(this.TextControlHMS_Leave);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxS;
    }
}
