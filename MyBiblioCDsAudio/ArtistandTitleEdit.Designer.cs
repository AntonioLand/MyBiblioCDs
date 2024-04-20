
namespace MyBiblioCDsAudio
{
    partial class ArtistTitleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtistTitleEdit));
            this.lbArtist = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.TitleTxt = new MyBiblioCDsAudio.TransparentTextBox2();
            this.ArtistTxt = new MyBiblioCDsAudio.TransparentTextBox2();
            this.SuspendLayout();
            // 
            // lbArtist
            // 
            resources.ApplyResources(this.lbArtist, "lbArtist");
            this.lbArtist.Name = "lbArtist";
            // 
            // lbTitle
            // 
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.Name = "lbTitle";
            // 
            // SearchBtn
            // 
            this.SearchBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.SearchBtn, "SearchBtn");
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // TitleTxt
            // 
            this.TitleTxt.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.TitleTxt, "TitleTxt");
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ArtistTxt
            // 
            this.ArtistTxt.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ArtistTxt, "ArtistTxt");
            this.ArtistTxt.Name = "ArtistTxt";
            this.ArtistTxt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ArtistTitleEdit
            // 
            this.AcceptButton = this.SearchBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyBiblioCDsAudio.Properties.Resources.CD_4;
            this.CancelButton = this.bCancel;
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.TitleTxt);
            this.Controls.Add(this.ArtistTxt);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbArtist);
            this.MaximizeBox = false;
            this.Name = "ArtistTitleEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.ArtistTitleEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbArtist;
        private System.Windows.Forms.Label lbTitle;
        public TransparentTextBox2 ArtistTxt;
        public TransparentTextBox2 TitleTxt;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button bCancel;
    }
}