namespace MyBiblioCDsAudio
{
    partial class MainFormAudio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormAudio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TrackDtGrVw = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackAUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBarcode = new System.Windows.Forms.TextBox();
            this.textCountry = new System.Windows.Forms.TextBox();
            this.textDate = new System.Windows.Forms.TextBox();
            this.textArtist = new System.Windows.Forms.TextBox();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgrvwInfoCd = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publicationDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTracksDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coverArtFDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genreMusicDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MusicBrainz = new System.Windows.Forms.Button();
            this.cdfilepicbx = new System.Windows.Forms.PictureBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.bLocal = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbgenreMusic = new System.Windows.Forms.ComboBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textDuration = new System.Windows.Forms.TextBox();
            this.textCtrlHMS = new TextBoxTime.TextControlHMS();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publicationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTracksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coverArtFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genreMusicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabInfoImg = new System.Windows.Forms.Label();
            this.linkToDiscOrMBr = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.TrackDtGrVw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvwInfoCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdfilepicbx)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackDtGrVw
            // 
            this.TrackDtGrVw.AutoGenerateColumns = false;
            this.TrackDtGrVw.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TrackDtGrVw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TrackDtGrVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrackDtGrVw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.durationDataGridViewTextBoxColumn3});
            this.TrackDtGrVw.DataSource = this.trackAUBindingSource;
            resources.ApplyResources(this.TrackDtGrVw, "TrackDtGrVw");
            this.TrackDtGrVw.Name = "TrackDtGrVw";
            this.TrackDtGrVw.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TrackDtGrVw_CellMouseDown);
            this.TrackDtGrVw.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.TrackDtGrVw_DataError);
            this.TrackDtGrVw.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.TrackDtGrVw_EditingControlShowing);
            this.TrackDtGrVw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackDtGrVw_KeyUp);
            this.TrackDtGrVw.Leave += new System.EventHandler(this.TrackDtGrVw_Leave);
            this.TrackDtGrVw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrackDtGrVw_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TrNum";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TitleTrack";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // durationDataGridViewTextBoxColumn3
            // 
            this.durationDataGridViewTextBoxColumn3.DataPropertyName = "Duration";
            resources.ApplyResources(this.durationDataGridViewTextBoxColumn3, "durationDataGridViewTextBoxColumn3");
            this.durationDataGridViewTextBoxColumn3.Name = "durationDataGridViewTextBoxColumn3";
            // 
            // trackAUBindingSource
            // 
            this.trackAUBindingSource.AllowNew = true;
            this.trackAUBindingSource.DataSource = typeof(MyBiblioCDsAudio.Track_AU);
            // 
            // textBarcode
            // 
            resources.ApplyResources(this.textBarcode, "textBarcode");
            this.textBarcode.Name = "textBarcode";
            // 
            // textCountry
            // 
            resources.ApplyResources(this.textCountry, "textCountry");
            this.textCountry.Name = "textCountry";
            this.textCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCountry_KeyPress);
            this.textCountry.Leave += new System.EventHandler(this.textCountry_Leave);
            // 
            // textDate
            // 
            resources.ApplyResources(this.textDate, "textDate");
            this.textDate.Name = "textDate";
            this.textDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDate_KeyPress);
            this.textDate.Leave += new System.EventHandler(this.textDate_Leave);
            // 
            // textArtist
            // 
            resources.ApplyResources(this.textArtist, "textArtist");
            this.textArtist.Name = "textArtist";
            this.textArtist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textArtist_KeyPress);
            this.textArtist.Leave += new System.EventHandler(this.textArtist_Leave);
            // 
            // textTitle
            // 
            resources.ApplyResources(this.textTitle, "textTitle");
            this.textTitle.Name = "textTitle";
            this.textTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTitle_KeyPress);
            this.textTitle.Leave += new System.EventHandler(this.textTitle_Leave);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // dtgrvwInfoCd
            // 
            this.dtgrvwInfoCd.AllowUserToDeleteRows = false;
            this.dtgrvwInfoCd.AutoGenerateColumns = false;
            this.dtgrvwInfoCd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgrvwInfoCd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgrvwInfoCd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrvwInfoCd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrvwInfoCd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgrvwInfoCd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn1,
            this.artistDataGridViewTextBoxColumn1,
            this.publicationDateDataGridViewTextBoxColumn1,
            this.countryDataGridViewTextBoxColumn1,
            this.barcodeDataGridViewTextBoxColumn1,
            this.releaseIDDataGridViewTextBoxColumn1,
            this.numTracksDataGridViewTextBoxColumn1,
            this.coverArtFDataGridViewTextBoxColumn1,
            this.genreMusicDataGridViewTextBoxColumn1,
            this.durationDataGridViewTextBoxColumn2});
            this.dtgrvwInfoCd.DataSource = this.audioCDBindingSource;
            resources.ApplyResources(this.dtgrvwInfoCd, "dtgrvwInfoCd");
            this.dtgrvwInfoCd.MultiSelect = false;
            this.dtgrvwInfoCd.Name = "dtgrvwInfoCd";
            this.dtgrvwInfoCd.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgrvwInfoCd_DataError);
            this.dtgrvwInfoCd.SelectionChanged += new System.EventHandler(this.dtgrvwInfoCd_SelectionChanged);
            // 
            // titleDataGridViewTextBoxColumn1
            // 
            this.titleDataGridViewTextBoxColumn1.DataPropertyName = "Title";
            resources.ApplyResources(this.titleDataGridViewTextBoxColumn1, "titleDataGridViewTextBoxColumn1");
            this.titleDataGridViewTextBoxColumn1.Name = "titleDataGridViewTextBoxColumn1";
            // 
            // artistDataGridViewTextBoxColumn1
            // 
            this.artistDataGridViewTextBoxColumn1.DataPropertyName = "Artist";
            resources.ApplyResources(this.artistDataGridViewTextBoxColumn1, "artistDataGridViewTextBoxColumn1");
            this.artistDataGridViewTextBoxColumn1.Name = "artistDataGridViewTextBoxColumn1";
            // 
            // publicationDateDataGridViewTextBoxColumn1
            // 
            this.publicationDateDataGridViewTextBoxColumn1.DataPropertyName = "PublicationDate";
            resources.ApplyResources(this.publicationDateDataGridViewTextBoxColumn1, "publicationDateDataGridViewTextBoxColumn1");
            this.publicationDateDataGridViewTextBoxColumn1.Name = "publicationDateDataGridViewTextBoxColumn1";
            // 
            // countryDataGridViewTextBoxColumn1
            // 
            this.countryDataGridViewTextBoxColumn1.DataPropertyName = "Country";
            resources.ApplyResources(this.countryDataGridViewTextBoxColumn1, "countryDataGridViewTextBoxColumn1");
            this.countryDataGridViewTextBoxColumn1.Name = "countryDataGridViewTextBoxColumn1";
            // 
            // barcodeDataGridViewTextBoxColumn1
            // 
            this.barcodeDataGridViewTextBoxColumn1.DataPropertyName = "Barcode";
            resources.ApplyResources(this.barcodeDataGridViewTextBoxColumn1, "barcodeDataGridViewTextBoxColumn1");
            this.barcodeDataGridViewTextBoxColumn1.Name = "barcodeDataGridViewTextBoxColumn1";
            // 
            // releaseIDDataGridViewTextBoxColumn1
            // 
            this.releaseIDDataGridViewTextBoxColumn1.DataPropertyName = "Release_ID";
            resources.ApplyResources(this.releaseIDDataGridViewTextBoxColumn1, "releaseIDDataGridViewTextBoxColumn1");
            this.releaseIDDataGridViewTextBoxColumn1.Name = "releaseIDDataGridViewTextBoxColumn1";
            // 
            // numTracksDataGridViewTextBoxColumn1
            // 
            this.numTracksDataGridViewTextBoxColumn1.DataPropertyName = "numTracks";
            resources.ApplyResources(this.numTracksDataGridViewTextBoxColumn1, "numTracksDataGridViewTextBoxColumn1");
            this.numTracksDataGridViewTextBoxColumn1.Name = "numTracksDataGridViewTextBoxColumn1";
            // 
            // coverArtFDataGridViewTextBoxColumn1
            // 
            this.coverArtFDataGridViewTextBoxColumn1.DataPropertyName = "CoverArtF";
            resources.ApplyResources(this.coverArtFDataGridViewTextBoxColumn1, "coverArtFDataGridViewTextBoxColumn1");
            this.coverArtFDataGridViewTextBoxColumn1.Name = "coverArtFDataGridViewTextBoxColumn1";
            // 
            // genreMusicDataGridViewTextBoxColumn1
            // 
            this.genreMusicDataGridViewTextBoxColumn1.DataPropertyName = "genreMusic";
            resources.ApplyResources(this.genreMusicDataGridViewTextBoxColumn1, "genreMusicDataGridViewTextBoxColumn1");
            this.genreMusicDataGridViewTextBoxColumn1.Name = "genreMusicDataGridViewTextBoxColumn1";
            // 
            // durationDataGridViewTextBoxColumn2
            // 
            this.durationDataGridViewTextBoxColumn2.DataPropertyName = "Duration";
            resources.ApplyResources(this.durationDataGridViewTextBoxColumn2, "durationDataGridViewTextBoxColumn2");
            this.durationDataGridViewTextBoxColumn2.Name = "durationDataGridViewTextBoxColumn2";
            // 
            // audioCDBindingSource
            // 
            this.audioCDBindingSource.DataSource = typeof(MyBiblioCDsAudio.Audio_CD);
            // 
            // MusicBrainz
            // 
            resources.ApplyResources(this.MusicBrainz, "MusicBrainz");
            this.MusicBrainz.Name = "MusicBrainz";
            this.MusicBrainz.UseVisualStyleBackColor = true;
            this.MusicBrainz.Click += new System.EventHandler(this.MusicBrainz_Click);
            // 
            // cdfilepicbx
            // 
            resources.ApplyResources(this.cdfilepicbx, "cdfilepicbx");
            this.cdfilepicbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cdfilepicbx.Name = "cdfilepicbx";
            this.cdfilepicbx.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnsave, "btnsave");
            this.btnsave.Name = "btnsave";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.save_Click);
            // 
            // bLocal
            // 
            resources.ApplyResources(this.bLocal, "bLocal");
            this.bLocal.Name = "bLocal";
            this.bLocal.UseVisualStyleBackColor = true;
            this.bLocal.Click += new System.EventHandler(this.bLocal_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cmbgenreMusic
            // 
            this.cmbgenreMusic.FormattingEnabled = true;
            this.cmbgenreMusic.Items.AddRange(new object[] {
            resources.GetString("cmbgenreMusic.Items"),
            resources.GetString("cmbgenreMusic.Items1"),
            resources.GetString("cmbgenreMusic.Items2"),
            resources.GetString("cmbgenreMusic.Items3"),
            resources.GetString("cmbgenreMusic.Items4"),
            resources.GetString("cmbgenreMusic.Items5"),
            resources.GetString("cmbgenreMusic.Items6"),
            resources.GetString("cmbgenreMusic.Items7"),
            resources.GetString("cmbgenreMusic.Items8"),
            resources.GetString("cmbgenreMusic.Items9"),
            resources.GetString("cmbgenreMusic.Items10"),
            resources.GetString("cmbgenreMusic.Items11"),
            resources.GetString("cmbgenreMusic.Items12"),
            resources.GetString("cmbgenreMusic.Items13"),
            resources.GetString("cmbgenreMusic.Items14"),
            resources.GetString("cmbgenreMusic.Items15"),
            resources.GetString("cmbgenreMusic.Items16"),
            resources.GetString("cmbgenreMusic.Items17"),
            resources.GetString("cmbgenreMusic.Items18"),
            resources.GetString("cmbgenreMusic.Items19"),
            resources.GetString("cmbgenreMusic.Items20"),
            resources.GetString("cmbgenreMusic.Items21"),
            resources.GetString("cmbgenreMusic.Items22"),
            resources.GetString("cmbgenreMusic.Items23"),
            resources.GetString("cmbgenreMusic.Items24"),
            resources.GetString("cmbgenreMusic.Items25"),
            resources.GetString("cmbgenreMusic.Items26"),
            resources.GetString("cmbgenreMusic.Items27"),
            resources.GetString("cmbgenreMusic.Items28"),
            resources.GetString("cmbgenreMusic.Items29"),
            resources.GetString("cmbgenreMusic.Items30"),
            resources.GetString("cmbgenreMusic.Items31"),
            resources.GetString("cmbgenreMusic.Items32"),
            resources.GetString("cmbgenreMusic.Items33"),
            resources.GetString("cmbgenreMusic.Items34"),
            resources.GetString("cmbgenreMusic.Items35"),
            resources.GetString("cmbgenreMusic.Items36"),
            resources.GetString("cmbgenreMusic.Items37"),
            resources.GetString("cmbgenreMusic.Items38"),
            resources.GetString("cmbgenreMusic.Items39"),
            resources.GetString("cmbgenreMusic.Items40"),
            resources.GetString("cmbgenreMusic.Items41"),
            resources.GetString("cmbgenreMusic.Items42"),
            resources.GetString("cmbgenreMusic.Items43"),
            resources.GetString("cmbgenreMusic.Items44"),
            resources.GetString("cmbgenreMusic.Items45"),
            resources.GetString("cmbgenreMusic.Items46"),
            resources.GetString("cmbgenreMusic.Items47"),
            resources.GetString("cmbgenreMusic.Items48"),
            resources.GetString("cmbgenreMusic.Items49"),
            resources.GetString("cmbgenreMusic.Items50"),
            resources.GetString("cmbgenreMusic.Items51"),
            resources.GetString("cmbgenreMusic.Items52"),
            resources.GetString("cmbgenreMusic.Items53"),
            resources.GetString("cmbgenreMusic.Items54"),
            resources.GetString("cmbgenreMusic.Items55"),
            resources.GetString("cmbgenreMusic.Items56"),
            resources.GetString("cmbgenreMusic.Items57"),
            resources.GetString("cmbgenreMusic.Items58"),
            resources.GetString("cmbgenreMusic.Items59"),
            resources.GetString("cmbgenreMusic.Items60"),
            resources.GetString("cmbgenreMusic.Items61"),
            resources.GetString("cmbgenreMusic.Items62"),
            resources.GetString("cmbgenreMusic.Items63"),
            resources.GetString("cmbgenreMusic.Items64"),
            resources.GetString("cmbgenreMusic.Items65"),
            resources.GetString("cmbgenreMusic.Items66"),
            resources.GetString("cmbgenreMusic.Items67"),
            resources.GetString("cmbgenreMusic.Items68"),
            resources.GetString("cmbgenreMusic.Items69"),
            resources.GetString("cmbgenreMusic.Items70"),
            resources.GetString("cmbgenreMusic.Items71"),
            resources.GetString("cmbgenreMusic.Items72"),
            resources.GetString("cmbgenreMusic.Items73"),
            resources.GetString("cmbgenreMusic.Items74"),
            resources.GetString("cmbgenreMusic.Items75"),
            resources.GetString("cmbgenreMusic.Items76"),
            resources.GetString("cmbgenreMusic.Items77"),
            resources.GetString("cmbgenreMusic.Items78"),
            resources.GetString("cmbgenreMusic.Items79"),
            resources.GetString("cmbgenreMusic.Items80"),
            resources.GetString("cmbgenreMusic.Items81"),
            resources.GetString("cmbgenreMusic.Items82"),
            resources.GetString("cmbgenreMusic.Items83"),
            resources.GetString("cmbgenreMusic.Items84"),
            resources.GetString("cmbgenreMusic.Items85"),
            resources.GetString("cmbgenreMusic.Items86"),
            resources.GetString("cmbgenreMusic.Items87"),
            resources.GetString("cmbgenreMusic.Items88"),
            resources.GetString("cmbgenreMusic.Items89"),
            resources.GetString("cmbgenreMusic.Items90"),
            resources.GetString("cmbgenreMusic.Items91"),
            resources.GetString("cmbgenreMusic.Items92"),
            resources.GetString("cmbgenreMusic.Items93"),
            resources.GetString("cmbgenreMusic.Items94"),
            resources.GetString("cmbgenreMusic.Items95"),
            resources.GetString("cmbgenreMusic.Items96"),
            resources.GetString("cmbgenreMusic.Items97"),
            resources.GetString("cmbgenreMusic.Items98"),
            resources.GetString("cmbgenreMusic.Items99"),
            resources.GetString("cmbgenreMusic.Items100"),
            resources.GetString("cmbgenreMusic.Items101"),
            resources.GetString("cmbgenreMusic.Items102"),
            resources.GetString("cmbgenreMusic.Items103"),
            resources.GetString("cmbgenreMusic.Items104"),
            resources.GetString("cmbgenreMusic.Items105"),
            resources.GetString("cmbgenreMusic.Items106"),
            resources.GetString("cmbgenreMusic.Items107"),
            resources.GetString("cmbgenreMusic.Items108"),
            resources.GetString("cmbgenreMusic.Items109"),
            resources.GetString("cmbgenreMusic.Items110"),
            resources.GetString("cmbgenreMusic.Items111"),
            resources.GetString("cmbgenreMusic.Items112"),
            resources.GetString("cmbgenreMusic.Items113"),
            resources.GetString("cmbgenreMusic.Items114"),
            resources.GetString("cmbgenreMusic.Items115"),
            resources.GetString("cmbgenreMusic.Items116"),
            resources.GetString("cmbgenreMusic.Items117"),
            resources.GetString("cmbgenreMusic.Items118"),
            resources.GetString("cmbgenreMusic.Items119"),
            resources.GetString("cmbgenreMusic.Items120"),
            resources.GetString("cmbgenreMusic.Items121"),
            resources.GetString("cmbgenreMusic.Items122"),
            resources.GetString("cmbgenreMusic.Items123"),
            resources.GetString("cmbgenreMusic.Items124"),
            resources.GetString("cmbgenreMusic.Items125"),
            resources.GetString("cmbgenreMusic.Items126"),
            resources.GetString("cmbgenreMusic.Items127"),
            resources.GetString("cmbgenreMusic.Items128"),
            resources.GetString("cmbgenreMusic.Items129"),
            resources.GetString("cmbgenreMusic.Items130"),
            resources.GetString("cmbgenreMusic.Items131"),
            resources.GetString("cmbgenreMusic.Items132"),
            resources.GetString("cmbgenreMusic.Items133"),
            resources.GetString("cmbgenreMusic.Items134"),
            resources.GetString("cmbgenreMusic.Items135"),
            resources.GetString("cmbgenreMusic.Items136"),
            resources.GetString("cmbgenreMusic.Items137"),
            resources.GetString("cmbgenreMusic.Items138"),
            resources.GetString("cmbgenreMusic.Items139"),
            resources.GetString("cmbgenreMusic.Items140"),
            resources.GetString("cmbgenreMusic.Items141"),
            resources.GetString("cmbgenreMusic.Items142"),
            resources.GetString("cmbgenreMusic.Items143"),
            resources.GetString("cmbgenreMusic.Items144"),
            resources.GetString("cmbgenreMusic.Items145"),
            resources.GetString("cmbgenreMusic.Items146"),
            resources.GetString("cmbgenreMusic.Items147"),
            resources.GetString("cmbgenreMusic.Items148"),
            resources.GetString("cmbgenreMusic.Items149"),
            resources.GetString("cmbgenreMusic.Items150")});
            resources.ApplyResources(this.cmbgenreMusic, "cmbgenreMusic");
            this.cmbgenreMusic.Name = "cmbgenreMusic";
            this.cmbgenreMusic.TextChanged += new System.EventHandler(this.cmbgenreMusic_TextChanged);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textDuration
            // 
            resources.ApplyResources(this.textDuration, "textDuration");
            this.textDuration.Name = "textDuration";
            // 
            // textCtrlHMS
            // 
            resources.ApplyResources(this.textCtrlHMS, "textCtrlHMS");
            this.textCtrlHMS.Name = "textCtrlHMS";
            this.textCtrlHMS.time = "00:00:00";
            this.textCtrlHMS.TextInternalChanged += new System.EventHandler(this.textCtrlHMS_TextInternalChanged);
            this.textCtrlHMS.Leave += new System.EventHandler(this.textCtrlHMS_Leave);
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            resources.ApplyResources(this.titleDataGridViewTextBoxColumn, "titleDataGridViewTextBoxColumn");
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // artistDataGridViewTextBoxColumn
            // 
            this.artistDataGridViewTextBoxColumn.DataPropertyName = "Artist";
            resources.ApplyResources(this.artistDataGridViewTextBoxColumn, "artistDataGridViewTextBoxColumn");
            this.artistDataGridViewTextBoxColumn.Name = "artistDataGridViewTextBoxColumn";
            // 
            // publicationDateDataGridViewTextBoxColumn
            // 
            this.publicationDateDataGridViewTextBoxColumn.DataPropertyName = "PublicationDate";
            resources.ApplyResources(this.publicationDateDataGridViewTextBoxColumn, "publicationDateDataGridViewTextBoxColumn");
            this.publicationDateDataGridViewTextBoxColumn.Name = "publicationDateDataGridViewTextBoxColumn";
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            resources.ApplyResources(this.countryDataGridViewTextBoxColumn, "countryDataGridViewTextBoxColumn");
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            resources.ApplyResources(this.barcodeDataGridViewTextBoxColumn, "barcodeDataGridViewTextBoxColumn");
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            // 
            // releaseIDDataGridViewTextBoxColumn
            // 
            this.releaseIDDataGridViewTextBoxColumn.DataPropertyName = "Release_ID";
            resources.ApplyResources(this.releaseIDDataGridViewTextBoxColumn, "releaseIDDataGridViewTextBoxColumn");
            this.releaseIDDataGridViewTextBoxColumn.Name = "releaseIDDataGridViewTextBoxColumn";
            // 
            // numTracksDataGridViewTextBoxColumn
            // 
            this.numTracksDataGridViewTextBoxColumn.DataPropertyName = "numTracks";
            resources.ApplyResources(this.numTracksDataGridViewTextBoxColumn, "numTracksDataGridViewTextBoxColumn");
            this.numTracksDataGridViewTextBoxColumn.Name = "numTracksDataGridViewTextBoxColumn";
            // 
            // coverArtFDataGridViewTextBoxColumn
            // 
            this.coverArtFDataGridViewTextBoxColumn.DataPropertyName = "CoverArtF";
            resources.ApplyResources(this.coverArtFDataGridViewTextBoxColumn, "coverArtFDataGridViewTextBoxColumn");
            this.coverArtFDataGridViewTextBoxColumn.Name = "coverArtFDataGridViewTextBoxColumn";
            // 
            // genreMusicDataGridViewTextBoxColumn
            // 
            this.genreMusicDataGridViewTextBoxColumn.DataPropertyName = "genreMusic";
            resources.ApplyResources(this.genreMusicDataGridViewTextBoxColumn, "genreMusicDataGridViewTextBoxColumn");
            this.genreMusicDataGridViewTextBoxColumn.Name = "genreMusicDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            resources.ApplyResources(this.durationDataGridViewTextBoxColumn, "durationDataGridViewTextBoxColumn");
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // LabInfoImg
            // 
            resources.ApplyResources(this.LabInfoImg, "LabInfoImg");
            this.LabInfoImg.Name = "LabInfoImg";
            // 
            // linkToDiscOrMBr
            // 
            resources.ApplyResources(this.linkToDiscOrMBr, "linkToDiscOrMBr");
            this.linkToDiscOrMBr.Name = "linkToDiscOrMBr";
            // 
            // MainFormAudio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkToDiscOrMBr);
            this.Controls.Add(this.LabInfoImg);
            this.Controls.Add(this.textCtrlHMS);
            this.Controls.Add(this.textDuration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.cmbgenreMusic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bLocal);
            this.Controls.Add(this.MusicBrainz);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cdfilepicbx);
            this.Controls.Add(this.dtgrvwInfoCd);
            this.Controls.Add(this.TrackDtGrVw);
            this.Controls.Add(this.textBarcode);
            this.Controls.Add(this.textCountry);
            this.Controls.Add(this.textDate);
            this.Controls.Add(this.textArtist);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainFormAudio";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormAudio_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackDtGrVw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvwInfoCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdfilepicbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBarcode;
        private System.Windows.Forms.TextBox textCountry;
        private System.Windows.Forms.TextBox textDate;
        private System.Windows.Forms.TextBox textArtist;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MusicBrainz;
        private System.Windows.Forms.PictureBox cdfilepicbx;
        private System.Windows.Forms.Button btnsave;
        public System.Windows.Forms.DataGridView dtgrvwInfoCd;
        private System.Windows.Forms.Button bLocal;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbgenreMusic;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textDuration;
        private TextBoxTime.TextControlHMS textCtrlHMS;
        public System.Windows.Forms.DataGridView TrackDtGrVw;
        private System.Windows.Forms.BindingSource audioCDBindingSource;
        private System.Windows.Forms.BindingSource trackAUBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn publicationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTracksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coverArtFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genreMusicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn publicationDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTracksDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coverArtFDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn genreMusicDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label LabInfoImg;
        private System.Windows.Forms.LinkLabel linkToDiscOrMBr;
    }
}