#pragma warning disable CS1591

namespace MyBiblioCDs
{
    partial class ListFiles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListFiles));
            this.btnsave = new System.Windows.Forms.Button();
            this.btnNote = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ckfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilesuserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilesisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilespchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilespdbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilesdllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilesexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfileslogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilesobjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckfilesresxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCheckFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tplistView = new System.Windows.Forms.ListView();
            this.tplsviewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tplsviewSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tplsviewCreate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tplsviewLastMod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tplsviewExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HashButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStriptxt = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.bckgrWkLoadLsFiles = new System.ComponentModel.BackgroundWorker();
            this.backgroundHash = new System.ComponentModel.BackgroundWorker();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.axWndMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.statusStrip1.SuspendLayout();
            this.toolStriptxt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWndMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsave
            // 
            resources.ApplyResources(this.btnsave, "btnsave");
            this.btnsave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnsave.Name = "btnsave";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnNote
            // 
            resources.ApplyResources(this.btnNote, "btnNote");
            this.btnNote.Name = "btnNote";
            this.btnNote.UseVisualStyleBackColor = true;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "usbpen.bmp");
            this.imageList1.Images.SetKeyName(1, "Cartelle.ico");
            this.imageList1.Images.SetKeyName(2, "cdrom.ico");
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgBar,
            this.toolStripDropDownButton1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripProgBar
            // 
            this.toolStripProgBar.Name = "toolStripProgBar";
            resources.ApplyResources(this.toolStripProgBar, "toolStripProgBar");
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckfilesToolStripMenuItem,
            this.ckfilesuserToolStripMenuItem,
            this.ckfilesisoToolStripMenuItem,
            this.ckfilespchToolStripMenuItem,
            this.ckfilespdbToolStripMenuItem,
            this.ckfilesdllToolStripMenuItem,
            this.ckfilesexeToolStripMenuItem,
            this.ckfileslogToolStripMenuItem,
            this.ckfilesobjToolStripMenuItem,
            this.ckfilesresxToolStripMenuItem,
            this.loadCheckFilesToolStripMenuItem});
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // ckfilesToolStripMenuItem
            // 
            this.ckfilesToolStripMenuItem.Name = "ckfilesToolStripMenuItem";
            resources.ApplyResources(this.ckfilesToolStripMenuItem, "ckfilesToolStripMenuItem");
            this.ckfilesToolStripMenuItem.Click += new System.EventHandler(this.ckfilesToolStripMenuItem_Click);
            // 
            // ckfilesuserToolStripMenuItem
            // 
            this.ckfilesuserToolStripMenuItem.Name = "ckfilesuserToolStripMenuItem";
            resources.ApplyResources(this.ckfilesuserToolStripMenuItem, "ckfilesuserToolStripMenuItem");
            this.ckfilesuserToolStripMenuItem.Click += new System.EventHandler(this.ckfilesuserToolStripMenuItem_Click);
            // 
            // ckfilesisoToolStripMenuItem
            // 
            this.ckfilesisoToolStripMenuItem.Name = "ckfilesisoToolStripMenuItem";
            resources.ApplyResources(this.ckfilesisoToolStripMenuItem, "ckfilesisoToolStripMenuItem");
            this.ckfilesisoToolStripMenuItem.Click += new System.EventHandler(this.ckfilesisoToolStripMenuItem_Click);
            // 
            // ckfilespchToolStripMenuItem
            // 
            this.ckfilespchToolStripMenuItem.Name = "ckfilespchToolStripMenuItem";
            resources.ApplyResources(this.ckfilespchToolStripMenuItem, "ckfilespchToolStripMenuItem");
            this.ckfilespchToolStripMenuItem.Click += new System.EventHandler(this.ckfilespchToolStripMenuItem_Click);
            // 
            // ckfilespdbToolStripMenuItem
            // 
            this.ckfilespdbToolStripMenuItem.Name = "ckfilespdbToolStripMenuItem";
            resources.ApplyResources(this.ckfilespdbToolStripMenuItem, "ckfilespdbToolStripMenuItem");
            this.ckfilespdbToolStripMenuItem.Click += new System.EventHandler(this.ckfilespdbToolStripMenuItem_Click);
            // 
            // ckfilesdllToolStripMenuItem
            // 
            this.ckfilesdllToolStripMenuItem.Name = "ckfilesdllToolStripMenuItem";
            resources.ApplyResources(this.ckfilesdllToolStripMenuItem, "ckfilesdllToolStripMenuItem");
            this.ckfilesdllToolStripMenuItem.Click += new System.EventHandler(this.ckfilesdllToolStripMenuItem_Click);
            // 
            // ckfilesexeToolStripMenuItem
            // 
            this.ckfilesexeToolStripMenuItem.Name = "ckfilesexeToolStripMenuItem";
            resources.ApplyResources(this.ckfilesexeToolStripMenuItem, "ckfilesexeToolStripMenuItem");
            this.ckfilesexeToolStripMenuItem.Click += new System.EventHandler(this.ckfilesexeToolStripMenuItem_Click);
            // 
            // ckfileslogToolStripMenuItem
            // 
            this.ckfileslogToolStripMenuItem.Name = "ckfileslogToolStripMenuItem";
            resources.ApplyResources(this.ckfileslogToolStripMenuItem, "ckfileslogToolStripMenuItem");
            this.ckfileslogToolStripMenuItem.Click += new System.EventHandler(this.ckfileslogToolStripMenuItem_Click);
            // 
            // ckfilesobjToolStripMenuItem
            // 
            this.ckfilesobjToolStripMenuItem.Name = "ckfilesobjToolStripMenuItem";
            resources.ApplyResources(this.ckfilesobjToolStripMenuItem, "ckfilesobjToolStripMenuItem");
            this.ckfilesobjToolStripMenuItem.Click += new System.EventHandler(this.ckfilesobjToolStripMenuItem_Click);
            // 
            // ckfilesresxToolStripMenuItem
            // 
            this.ckfilesresxToolStripMenuItem.Name = "ckfilesresxToolStripMenuItem";
            resources.ApplyResources(this.ckfilesresxToolStripMenuItem, "ckfilesresxToolStripMenuItem");
            this.ckfilesresxToolStripMenuItem.Click += new System.EventHandler(this.ckfilesresxToolStripMenuItem_Click);
            // 
            // loadCheckFilesToolStripMenuItem
            // 
            this.loadCheckFilesToolStripMenuItem.Name = "loadCheckFilesToolStripMenuItem";
            resources.ApplyResources(this.loadCheckFilesToolStripMenuItem, "loadCheckFilesToolStripMenuItem");
            this.loadCheckFilesToolStripMenuItem.Click += new System.EventHandler(this.loadCheckFilesToolStripMenuItem_Click);
            // 
            // tplistView
            // 
            resources.ApplyResources(this.tplistView, "tplistView");
            this.tplistView.CheckBoxes = true;
            this.tplistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tplsviewName,
            this.tplsviewSize,
            this.tplsviewCreate,
            this.tplsviewLastMod,
            this.tplsviewExt,
            this.nt});
            this.tplistView.HideSelection = false;
            this.tplistView.MultiSelect = false;
            this.tplistView.Name = "tplistView";
            this.tplistView.ShowItemToolTips = true;
            this.tplistView.SmallImageList = this.imageList1;
            this.toolTip1.SetToolTip(this.tplistView, resources.GetString("tplistView.ToolTip"));
            this.tplistView.UseCompatibleStateImageBehavior = false;
            this.tplistView.View = System.Windows.Forms.View.Details;
            this.tplistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.tplistView_ColumnClick);
            this.tplistView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
            this.tplistView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.tplistView_ItemSelectionChanged);
            this.tplistView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tplistView_KeyDown);
            this.tplistView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tplistView_MouseClick);
            this.tplistView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tplistView_MouseDown);
            // 
            // tplsviewName
            // 
            resources.ApplyResources(this.tplsviewName, "tplsviewName");
            // 
            // tplsviewSize
            // 
            resources.ApplyResources(this.tplsviewSize, "tplsviewSize");
            // 
            // tplsviewCreate
            // 
            resources.ApplyResources(this.tplsviewCreate, "tplsviewCreate");
            // 
            // tplsviewLastMod
            // 
            resources.ApplyResources(this.tplsviewLastMod, "tplsviewLastMod");
            // 
            // tplsviewExt
            // 
            resources.ApplyResources(this.tplsviewExt, "tplsviewExt");
            // 
            // nt
            // 
            resources.ApplyResources(this.nt, "nt");
            // 
            // HashButton
            // 
            resources.ApplyResources(this.HashButton, "HashButton");
            this.HashButton.Name = "HashButton";
            this.toolTip1.SetToolTip(this.HashButton, resources.GetString("HashButton.ToolTip"));
            this.HashButton.UseVisualStyleBackColor = true;
            this.HashButton.Click += new System.EventHandler(this.HashButton_Click);
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // toolStriptxt
            // 
            resources.ApplyResources(this.toolStriptxt, "toolStriptxt");
            this.toolStriptxt.GripMargin = new System.Windows.Forms.Padding(10);
            this.toolStriptxt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.toolStriptxt.Name = "toolStriptxt";
            this.toolStriptxt.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AcceptsReturn = true;
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            this.toolStripTextBox1.AutoToolTip = true;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Enter += new System.EventHandler(this.toolStripTextBox1_Enter);
            this.toolStripTextBox1.Leave += new System.EventHandler(this.toolStripTextBox1_Leave);
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            // 
            // bckgrWkLoadLsFiles
            // 
            this.bckgrWkLoadLsFiles.WorkerReportsProgress = true;
            this.bckgrWkLoadLsFiles.WorkerSupportsCancellation = true;
            // 
            // backgroundHash
            // 
            this.backgroundHash.WorkerReportsProgress = true;
            // 
            // toolTip2
            // 
            this.toolTip2.IsBalloon = true;
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // axWndMediaPlayer
            // 
            resources.ApplyResources(this.axWndMediaPlayer, "axWndMediaPlayer");
            this.axWndMediaPlayer.Name = "axWndMediaPlayer";
            this.axWndMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWndMediaPlayer.OcxState")));
            // 
            // ListFiles
            // 
            this.AcceptButton = this.btnsave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::MyBiblioCDs.Properties.Resources.CD_5;
            this.Controls.Add(this.axWndMediaPlayer);
            this.Controls.Add(this.HashButton);
            this.Controls.Add(this.toolStriptxt);
            this.Controls.Add(this.tplistView);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNote);
            this.Controls.Add(this.btnsave);
            this.Name = "ListFiles";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListFiles_FormClosing);
            this.Load += new System.EventHandler(this.ListFiles_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ListFiles_Paint);
            this.Resize += new System.EventHandler(this.ListFiles_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStriptxt.ResumeLayout(false);
            this.toolStriptxt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWndMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       // private LibVLCSharp.WinForms.VideoView videoView;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgBar;
        private System.ComponentModel.BackgroundWorker bckgrWkLoadLsFiles;
        private System.Windows.Forms.ListView tplistView;
        public System.Windows.Forms.ColumnHeader tplsviewName;
        private System.Windows.Forms.ColumnHeader tplsviewSize;
        private System.Windows.Forms.ColumnHeader tplsviewCreate;
        private System.Windows.Forms.ColumnHeader tplsviewLastMod;
        private System.Windows.Forms.ColumnHeader tplsviewExt;
        public System.Windows.Forms.ColumnHeader nt;
        private System.Windows.Forms.ToolStrip toolStriptxt;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundHash;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ckfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilesuserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilesisoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilespchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilespdbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilesdllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilesexeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfileslogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilesobjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckfilesresxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCheckFilesToolStripMenuItem;
        private System.Windows.Forms.Button HashButton;
        private System.Windows.Forms.ToolTip toolTip2;
        private AxWMPLib.AxWindowsMediaPlayer axWndMediaPlayer;
    }
}