namespace MyBiblioCDsAudio
{
    partial class CDCoverControl
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
            this.components = new System.ComponentModel.Container();
            this.cdPanelGradient1 = new MyBiblioCDsAudio.CdPanelGradient();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.HideInfoBtn = new System.Windows.Forms.Button();
            this.MenuBtn = new System.Windows.Forms.Button();
            this.FileTxtBx = new MyBiblioCDsAudio.TransparentTextBox();
            this.SizeTxt = new MyBiblioCDsAudio.TransparentTextBox();
            this.NameTxtBx = new MyBiblioCDsAudio.TransparentTextBox();
            this.lbFile = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.IndexTxt = new MyBiblioCDsAudio.TransparentTextBox();
            this.ShowInfoBtn = new System.Windows.Forms.Button();
            this.CoverCd = new System.Windows.Forms.PictureBox();
            this.MenuCnt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cdPanelGradient1.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverCd)).BeginInit();
            this.MenuCnt.SuspendLayout();
            this.SuspendLayout();
            // 
            // cdPanelGradient1
            // 
            this.cdPanelGradient1.Angle = 0F;
            this.cdPanelGradient1.BackColor = System.Drawing.Color.CadetBlue;
            this.cdPanelGradient1.BottomColor = System.Drawing.Color.Transparent;
            this.cdPanelGradient1.Controls.Add(this.InfoPanel);
            this.cdPanelGradient1.Controls.Add(this.IndexTxt);
            this.cdPanelGradient1.Controls.Add(this.ShowInfoBtn);
            this.cdPanelGradient1.Controls.Add(this.CoverCd);
            this.cdPanelGradient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdPanelGradient1.ForeColor = System.Drawing.Color.White;
            this.cdPanelGradient1.Location = new System.Drawing.Point(0, 0);
            this.cdPanelGradient1.Name = "cdPanelGradient1";
            this.cdPanelGradient1.Size = new System.Drawing.Size(180, 290);
            this.cdPanelGradient1.TabIndex = 0;
            this.cdPanelGradient1.TopColor = System.Drawing.Color.Empty;
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.InfoPanel.Controls.Add(this.HideInfoBtn);
            this.InfoPanel.Controls.Add(this.MenuBtn);
            this.InfoPanel.Controls.Add(this.FileTxtBx);
            this.InfoPanel.Controls.Add(this.SizeTxt);
            this.InfoPanel.Controls.Add(this.NameTxtBx);
            this.InfoPanel.Controls.Add(this.lbFile);
            this.InfoPanel.Controls.Add(this.lbSize);
            this.InfoPanel.Controls.Add(this.lbName);
            this.InfoPanel.Location = new System.Drawing.Point(5, 180);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(170, 100);
            this.InfoPanel.TabIndex = 6;
//            this.InfoPanel.DoubleClick += new System.EventHandler(this.InfoPanel_DoubleClick);
            // 
            // HideInfoBtn
            // 
            this.HideInfoBtn.FlatAppearance.BorderSize = 0;
            this.HideInfoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideInfoBtn.Image = global::MyBiblioCDsAudio.Properties.Resources.HidepanelInfo;
            this.HideInfoBtn.Location = new System.Drawing.Point(156, 80);
            this.HideInfoBtn.Name = "HideInfoBtn";
            this.HideInfoBtn.Size = new System.Drawing.Size(12, 13);
            this.HideInfoBtn.TabIndex = 13;
            this.HideInfoBtn.UseVisualStyleBackColor = true;
            this.HideInfoBtn.Click += new System.EventHandler(this.HideInfoBtn_Click);
            // 
            // MenuBtn
            // 
            this.MenuBtn.FlatAppearance.BorderSize = 0;
            this.MenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtn.Image = global::MyBiblioCDsAudio.Properties.Resources.MenuBtn;
            this.MenuBtn.Location = new System.Drawing.Point(6, 80);
            this.MenuBtn.Name = "MenuBtn";
            this.MenuBtn.Size = new System.Drawing.Size(12, 13);
            this.MenuBtn.TabIndex = 12;
            this.MenuBtn.UseVisualStyleBackColor = true;
            this.MenuBtn.Click += new System.EventHandler(this.MenuBtn_Click);
            // 
            // FileTxtBx
            // 
            this.FileTxtBx.BackColor = System.Drawing.Color.Transparent;
            this.FileTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileTxtBx.Location = new System.Drawing.Point(43, 60);
            this.FileTxtBx.Name = "FileTxtBx";
            this.FileTxtBx.Size = new System.Drawing.Size(115, 13);
            this.FileTxtBx.TabIndex = 11;
            this.FileTxtBx.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // SizeTxt
            // 
            this.SizeTxt.BackColor = System.Drawing.Color.Transparent;
            this.SizeTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SizeTxt.Location = new System.Drawing.Point(43, 35);
            this.SizeTxt.Name = "SizeTxt";
            this.SizeTxt.Size = new System.Drawing.Size(115, 13);
            this.SizeTxt.TabIndex = 10;
            this.SizeTxt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // NameTxtBx
            // 
            this.NameTxtBx.BackColor = System.Drawing.Color.Transparent;
            this.NameTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTxtBx.Location = new System.Drawing.Point(43, 10);
            this.NameTxtBx.Name = "NameTxtBx";
            this.NameTxtBx.ReadOnly = true;
            this.NameTxtBx.Size = new System.Drawing.Size(115, 13);
            this.NameTxtBx.TabIndex = 9;
            this.NameTxtBx.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.ForeColor = System.Drawing.Color.Black;
            this.lbFile.Location = new System.Drawing.Point(5, 59);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(23, 13);
            this.lbFile.TabIndex = 8;
            this.lbFile.Text = "File";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.ForeColor = System.Drawing.Color.Black;
            this.lbSize.Location = new System.Drawing.Point(5, 34);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(27, 13);
            this.lbSize.TabIndex = 7;
            this.lbSize.Text = "Size";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(5, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "Name";
            // 
            // IndexTxt
            // 
            this.IndexTxt.BackColor = System.Drawing.Color.Transparent;
            this.IndexTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IndexTxt.Location = new System.Drawing.Point(13, 165);
            this.IndexTxt.Name = "IndexTxt";
            this.IndexTxt.Size = new System.Drawing.Size(32, 13);
            this.IndexTxt.TabIndex = 5;
            this.IndexTxt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.IndexTxt.Visible = false;
            // 
            // ShowInfoBtn
            // 
            this.ShowInfoBtn.BackColor = System.Drawing.Color.Transparent;
            this.ShowInfoBtn.FlatAppearance.BorderSize = 0;
            this.ShowInfoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowInfoBtn.ForeColor = System.Drawing.Color.Transparent;
            this.ShowInfoBtn.Image = global::MyBiblioCDsAudio.Properties.Resources.showpanelInfo;
            this.ShowInfoBtn.Location = new System.Drawing.Point(160, 165);
            this.ShowInfoBtn.Name = "ShowInfoBtn";
            this.ShowInfoBtn.Size = new System.Drawing.Size(12, 13);
            this.ShowInfoBtn.TabIndex = 4;
            this.ShowInfoBtn.UseVisualStyleBackColor = false;
            this.ShowInfoBtn.Click += new System.EventHandler(this.ShowInfoBtn_Click);
            // 
            // CoverCd
            // 
            this.CoverCd.BackColor = System.Drawing.Color.Transparent;
            this.CoverCd.Location = new System.Drawing.Point(5, 6);
            this.CoverCd.Name = "CoverCd";
            this.CoverCd.Size = new System.Drawing.Size(170, 155);
            this.CoverCd.TabIndex = 3;
            this.CoverCd.TabStop = false;
            this.CoverCd.DoubleClick += new System.EventHandler(this.CoverCd_DoubleClick);
            this.CoverCd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CoverCd_Click);
            // 
            // MenuCnt
            // 
            this.MenuCnt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.editInfoToolStripMenuItem});
            this.MenuCnt.Name = "MenuCnt";
            this.MenuCnt.Size = new System.Drawing.Size(137, 70);
            // 
            // saveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.SaveFileToolStripMenuItem.Text = "&Choose this";
            this.SaveFileToolStripMenuItem.Click += new System.EventHandler(this.ChooseThisToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // editInfoToolStripMenuItem
            // 
            this.editInfoToolStripMenuItem.Name = "editInfoToolStripMenuItem";
            this.editInfoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.editInfoToolStripMenuItem.Text = "&Edit Info";
            this.editInfoToolStripMenuItem.Click += new System.EventHandler(this.EditInfoToolStripMenuItem_Click);
            // 
            // CDCoverControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cdPanelGradient1);
            this.Name = "CDCoverControl";
            this.Size = new System.Drawing.Size(180, 290);
            this.Load += new System.EventHandler(this.CDCoverControl_Load);
            this.cdPanelGradient1.ResumeLayout(false);
            this.cdPanelGradient1.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverCd)).EndInit();
            this.MenuCnt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CdPanelGradient cdPanelGradient1;
        private System.Windows.Forms.Button ShowInfoBtn;
        public System.Windows.Forms.PictureBox CoverCd;
        public System.Windows.Forms.Panel InfoPanel;
        public TransparentTextBox NameTxtBx;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbName;
        public TransparentTextBox IndexTxt;
        public System.Windows.Forms.Button HideInfoBtn;
        private System.Windows.Forms.ContextMenuStrip MenuCnt;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        public System.Windows.Forms.Button MenuBtn;
        private System.Windows.Forms.ToolStripMenuItem editInfoToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        public TransparentTextBox FileTxtBx;
        public TransparentTextBox SizeTxt;
    }
}
