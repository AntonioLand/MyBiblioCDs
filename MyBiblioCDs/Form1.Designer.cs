
namespace MyBiblioCDs
{
#pragma warning disable CS1591

    partial class MainForm
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveinfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewsaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDriver = new System.Windows.Forms.ComboBox();
            this.backgroundFileList = new System.ComponentModel.BackgroundWorker();
            this.numCDUpD = new System.Windows.Forms.NumericUpDown();
            this.bBrowse = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.textNote = new System.Windows.Forms.TextBox();
            this.PosCDTxt = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bSaveInfo = new System.Windows.Forms.Button();
            this.BListFiles = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveOnllyNote = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.checkBoxIndexWord = new System.Windows.Forms.CheckBox();
            this.BSaveAll = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cmBxTypeMediaCD = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bkgroundWkAudio = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerDataBase = new System.ComponentModel.BackgroundWorker();
            this.cmbBxOpDrv = new ComboOpenCloseDrv.CmbBxOpenDrv();
            this.hlpProvider = new System.Windows.Forms.HelpProvider();
            this.BackgroundInsert = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCDUpD)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator,
            this.saveallToolStripMenuItem,
            this.saveinfoToolStripMenuItem,
            this.previewsaveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(156, 6);
            // 
            // saveallToolStripMenuItem
            // 
            this.saveallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveallToolStripMenuItem.Image")));
            this.saveallToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveallToolStripMenuItem.Name = "saveallToolStripMenuItem";
            this.saveallToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveallToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveallToolStripMenuItem.Text = "&Save All";
            this.saveallToolStripMenuItem.Click += new System.EventHandler(this.BSaveAll_Click);
            // 
            // saveinfoToolStripMenuItem
            // 
            this.saveinfoToolStripMenuItem.Name = "saveinfoToolStripMenuItem";
            this.saveinfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.saveinfoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveinfoToolStripMenuItem.Text = "Save &Info";
            this.saveinfoToolStripMenuItem.Click += new System.EventHandler(this.bSaveInfo_Click);
            // 
            // previewsaveToolStripMenuItem
            // 
            this.previewsaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("previewsaveToolStripMenuItem.Image")));
            this.previewsaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previewsaveToolStripMenuItem.Name = "previewsaveToolStripMenuItem";
            this.previewsaveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.previewsaveToolStripMenuItem.Text = "&Preview Save";
            this.previewsaveToolStripMenuItem.Click += new System.EventHandler(this.previewsaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cancelToolStripMenuItem.Text = "&Cancel";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.showListToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.saveCoverToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.españolToolStripMenuItem,
            this.italianoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem1.Text = "Language";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // deutschToolStripMenuItem
            // 
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            this.deutschToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deutschToolStripMenuItem.Text = "Deutsch";
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.deutschToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.españolToolStripMenuItem.Text = "Español";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // italianoToolStripMenuItem
            // 
            this.italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
            this.italianoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.italianoToolStripMenuItem.Text = "Italiano";
            this.italianoToolStripMenuItem.Click += new System.EventHandler(this.italianoToolStripMenuItem_Click);
            // 
            // showListToolStripMenuItem
            // 
            this.showListToolStripMenuItem.Name = "showListToolStripMenuItem";
            this.showListToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.showListToolStripMenuItem.Text = "&Show Explorer";
            this.showListToolStripMenuItem.Click += new System.EventHandler(this.showListToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // saveCoverToolStripMenuItem
            // 
            this.saveCoverToolStripMenuItem.Name = "saveCoverToolStripMenuItem";
            this.saveCoverToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveCoverToolStripMenuItem.Text = "Save Cover ...";
            this.saveCoverToolStripMenuItem.Click += new System.EventHandler(this.saveCoverToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.ToolStripMenuItem.Text = "&?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.aboutToolStripMenuItem.Text = "About MyBiblioCDs";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(2, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Drive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(193, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "CD Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(377, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "CD Nummer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(8, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nota al CD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(135, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pos. CD";
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Location = new System.Drawing.Point(6, 55);
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(103, 21);
            this.comboBoxDriver.TabIndex = 1;
            this.comboBoxDriver.SelectedIndexChanged += new System.EventHandler(this.comboBoxDriver_SelectedIndexChanged);
            this.comboBoxDriver.TextChanged += new System.EventHandler(this.comboBoxDriver_TextChanged);
            this.comboBoxDriver.Enter += new System.EventHandler(this.comboBoxDriver_Enter);
            // 
            // backgroundFileList
            // 
            this.backgroundFileList.WorkerSupportsCancellation = true;
            // 
            // numCDUpD
            // 
            this.numCDUpD.Location = new System.Drawing.Point(380, 55);
            this.numCDUpD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCDUpD.Name = "numCDUpD";
            this.numCDUpD.Size = new System.Drawing.Size(91, 20);
            this.numCDUpD.TabIndex = 4;
            // 
            // bBrowse
            // 
            this.bBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bBrowse.Image = ((System.Drawing.Image)(resources.GetObject("bBrowse.Image")));
            this.bBrowse.Location = new System.Drawing.Point(118, 55);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(21, 21);
            this.bBrowse.TabIndex = 2;
            this.bBrowse.UseVisualStyleBackColor = false;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(190, 55);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // textNote
            // 
            this.textNote.Location = new System.Drawing.Point(6, 124);
            this.textNote.Name = "textNote";
            this.textNote.Size = new System.Drawing.Size(103, 20);
            this.textNote.TabIndex = 5;
            this.textNote.TextChanged += new System.EventHandler(this.textNote_TextChanged);
            this.textNote.Enter += new System.EventHandler(this.textNote_Enter);
            this.textNote.Leave += new System.EventHandler(this.textNote_Leave);
            // 
            // PosCDTxt
            // 
            this.PosCDTxt.Location = new System.Drawing.Point(135, 124);
            this.PosCDTxt.Name = "PosCDTxt";
            this.PosCDTxt.Size = new System.Drawing.Size(149, 20);
            this.PosCDTxt.TabIndex = 6;
            this.PosCDTxt.Enter += new System.EventHandler(this.PosCDTxt_Enter);
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(7, 290);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(518, 68);
            this.labelInfo.TabIndex = 11;
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(523, 22);
            this.progressBar1.TabIndex = 12;
            // 
            // bSaveInfo
            // 
            this.bSaveInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bSaveInfo.Location = new System.Drawing.Point(10, 250);
            this.bSaveInfo.Name = "bSaveInfo";
            this.bSaveInfo.Size = new System.Drawing.Size(80, 24);
            this.bSaveInfo.TabIndex = 13;
            this.bSaveInfo.Text = "S&ave Info";
            this.SaveOnllyNote.SetToolTip(this.bSaveInfo, "Save the CD Number, CD Notes, Location and Title");
            this.bSaveInfo.UseVisualStyleBackColor = true;
            this.bSaveInfo.Click += new System.EventHandler(this.bSaveInfo_Click);
            // 
            // BListFiles
            // 
            this.BListFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BListFiles.Location = new System.Drawing.Point(110, 250);
            this.BListFiles.Name = "BListFiles";
            this.BListFiles.Size = new System.Drawing.Size(80, 24);
            this.BListFiles.TabIndex = 14;
            this.BListFiles.Text = "List &Files";
            this.BListFiles.UseVisualStyleBackColor = true;
            this.BListFiles.Click += new System.EventHandler(this.BListFiles_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bStop.Location = new System.Drawing.Point(320, 250);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(80, 24);
            this.bStop.TabIndex = 15;
            this.bStop.Text = "Sto&p";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Visible = false;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // SaveOnllyNote
            // 
            this.SaveOnllyNote.AutoPopDelay = 5000;
            this.SaveOnllyNote.InitialDelay = 500;
            this.SaveOnllyNote.ReshowDelay = 10;
            this.SaveOnllyNote.ShowAlways = true;
            this.SaveOnllyNote.StripAmpersands = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.toolStrip1);
            this.flowLayoutPanel1.Controls.Add(this.listView);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(546, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(497, 362);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(482, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripTextBox1.Size = new System.Drawing.Size(445, 25);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column3,
            this.column4});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 28);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(494, 333);
            this.listView.SmallImageList = this.imageList1;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDown);
            // 
            // column1
            // 
            this.column1.Text = "Name";
            this.column1.Width = 250;
            // 
            // column3
            // 
            this.column3.Text = "Size";
            this.column3.Width = 90;
            // 
            // column4
            // 
            this.column4.Text = "Last Modified";
            this.column4.Width = 180;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "usbpen.bmp");
            this.imageList1.Images.SetKeyName(1, "Cartelle.ico");
            this.imageList1.Images.SetKeyName(2, "cdrom.ico");
            // 
            // checkBoxIndexWord
            // 
            this.checkBoxIndexWord.AutoSize = true;
            this.checkBoxIndexWord.Location = new System.Drawing.Point(210, 200);
            this.checkBoxIndexWord.Name = "checkBoxIndexWord";
            this.checkBoxIndexWord.Size = new System.Drawing.Size(81, 17);
            this.checkBoxIndexWord.TabIndex = 17;
            this.checkBoxIndexWord.Text = "Word Index";
            this.checkBoxIndexWord.UseVisualStyleBackColor = true;
            // 
            // BSaveAll
            // 
            this.BSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BSaveAll.Location = new System.Drawing.Point(210, 250);
            this.BSaveAll.Name = "BSaveAll";
            this.BSaveAll.Size = new System.Drawing.Size(90, 24);
            this.BSaveAll.TabIndex = 18;
            this.BSaveAll.Text = "&Save All";
            this.BSaveAll.UseVisualStyleBackColor = true;
            this.BSaveAll.Click += new System.EventHandler(this.BSaveAll_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(305, 124);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 19;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // cmBxTypeMediaCD
            // 
            this.cmBxTypeMediaCD.Items.AddRange(new object[] {
            "CD-AUDIO",
            "CD-ROM",
            "CD-PHOTOS",
            "CD-VARIOUS",
            "DVD-DATA",
            "DVD-FILM",
            "BLU-RAY-DATA",
            "BLU-RAY-FILM",
            "REMOVABLE",
            "DIRECTORY",
            "COLLECTION",
            "MYCOMPILATION"});
            this.cmBxTypeMediaCD.Location = new System.Drawing.Point(6, 196);
            this.cmBxTypeMediaCD.Name = "cmBxTypeMediaCD";
            this.cmBxTypeMediaCD.Size = new System.Drawing.Size(121, 21);
            this.cmBxTypeMediaCD.TabIndex = 20;
            this.cmBxTypeMediaCD.TextChanged += new System.EventHandler(this.cmBxTypeMediaCD_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(14, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Media Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(305, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Creation Date";
            // 
            // bCancel
            // 
            this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCancel.Location = new System.Drawing.Point(420, 251);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 23;
            this.bCancel.Text = "Annulla";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bkgroundWkAudio
            // 
            this.bkgroundWkAudio.WorkerSupportsCancellation = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "MyBiblioCDs";
            // 
            // backgroundWorkerDataBase
            // 
            this.backgroundWorkerDataBase.WorkerReportsProgress = true;
            this.backgroundWorkerDataBase.WorkerSupportsCancellation = true;
            // 
            // cmbBxOpDrv
            // 
            this.cmbBxOpDrv.BackColor = System.Drawing.Color.DimGray;
            this.cmbBxOpDrv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbBxOpDrv.ForeColor = System.Drawing.Color.DimGray;
            this.cmbBxOpDrv.lbltext = "";
            this.cmbBxOpDrv.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbBxOpDrv.Location = new System.Drawing.Point(147, 56);
            this.cmbBxOpDrv.MinimumSize = new System.Drawing.Size(21, 21);
            this.cmbBxOpDrv.Name = "cmbBxOpDrv";
            this.cmbBxOpDrv.Padding = new System.Windows.Forms.Padding(1);
            this.cmbBxOpDrv.SelectRectangleHeight = 106;
            this.cmbBxOpDrv.SelectRectangleWidth = 21;
            this.cmbBxOpDrv.Size = new System.Drawing.Size(21, 21);
            this.cmbBxOpDrv.TabIndex = 25;
            this.cmbBxOpDrv.OnSelectedIndexChanged += new System.EventHandler(this.cmbBxOpDrv_OnSelectedIndexChanged);
            this.cmbBxOpDrv.OnDrawItem += new System.EventHandler(this.cmbBxOpDrv_OnDrawItem);
            // 
            // BackgroundInsert
            // 
            this.BackgroundInsert.WorkerReportsProgress = true;
            this.BackgroundInsert.WorkerSupportsCancellation = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1055, 423);
            this.Controls.Add(this.cmbBxOpDrv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmBxTypeMediaCD);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.BSaveAll);
            this.Controls.Add(this.checkBoxIndexWord);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.BListFiles);
            this.Controls.Add(this.bSaveInfo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.PosCDTxt);
            this.Controls.Add(this.textNote);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.numCDUpD);
            this.Controls.Add(this.comboBoxDriver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MyBiblioCds";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCDUpD)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewsaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDriver;
        private System.ComponentModel.BackgroundWorker backgroundFileList;
        private System.Windows.Forms.NumericUpDown numCDUpD;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox PosCDTxt;
        public System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bSaveInfo;
        private System.Windows.Forms.Button BListFiles;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolTip SaveOnllyNote;
        private System.Windows.Forms.ToolStripMenuItem showListToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.ColumnHeader column4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox checkBoxIndexWord;
        private System.Windows.Forms.Button BSaveAll;
        private System.ComponentModel.BackgroundWorker bkgroundWkAudio;
        public System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ToolStripMenuItem saveinfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italianoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.TextBox textNote;
        public System.ComponentModel.BackgroundWorker backgroundWorkerDataBase;
        public System.Windows.Forms.ComboBox cmBxTypeMediaCD;
        private ComboOpenCloseDrv.CmbBxOpenDrv cmbBxOpDrv;
        private System.Windows.Forms.ToolStripMenuItem saveCoverToolStripMenuItem;
        public System.Windows.Forms.HelpProvider hlpProvider;
        private System.ComponentModel.BackgroundWorker BackgroundInsert;
    }
}

