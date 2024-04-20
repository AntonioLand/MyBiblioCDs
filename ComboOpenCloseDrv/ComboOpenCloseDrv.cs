using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Resources;
using ComboOpenCloseDrv.Properties;
using System.Reflection.Emit;

namespace ComboOpenCloseDrv
{

    [DefaultEvent("OnSelectedIndexChanged")]
    public partial class CmbBxOpenDrv : UserControl
    {
        private Color backColor = Color.WhiteSmoke;
        private Color listBackColor = Color.FromArgb(240, 240, 240);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.DimGray;
        private int borderSize = 1;

        private ComboBox cmbList = null;
        private System.Windows.Forms.Label lblText;
        private Button btnIcon;

        public ComboBox CmbList
        {
            get { return cmbList; }
        }
        //Events
        public event EventHandler OnSelectedIndexChanged;//Default event
        public CmbBxOpenDrv()
        {
            lblText = new System.Windows.Forms.Label();
            btnIcon = new Button();
            cmbList = new ComboBox();
            this.SuspendLayout();

            //Button
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(18, 14);
            btnIcon.BackgroundImage = (Resources.openandclose as System.Drawing.Image);
            btnIcon.BackgroundImageLayout = ImageLayout.Center;
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(btn_Click);//Open dropdown list
            btnIcon.Location = new Point(cmbList.Location.X, cmbList.Location.Y);

            // ComboBox

            cmbList.Size = new Size(18, 14);
            cmbList.Width = btnIcon.Width;
            cmbList.DropDownWidth = btnIcon.Width;
            cmbList.FlatStyle = FlatStyle.Flat;
            cmbList.Padding = new Padding(0, 0, 0, 0);
            this.Controls.Add(btnIcon);//1
            this.Controls.Add(cmbList);//0
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Default even
            cmbList.BackColor = listBackColor;

            this.MinimumSize = new Size(18, 14);
            this.Size = new Size(18, 14);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);//Border Size
            this.Font = new Font(this.Font.Name, 10F);
            base.BackColor = borderColor; //Border Color
            this.ResumeLayout();
        }


        private void btn_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);
            //Refresh text
            lblText.Text = cmbList.Text;
        }

        // Data

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]

        [Category("CmbBxOpenDrv Data")]
        public ComboBox.ObjectCollection Items
        {
            get
            {

                return cmbList.Items;
            }
        }
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return cmbList.DataSource;
            }
            set
            {
                cmbList.DataSource = value;
            }
        }
        [Category("CmbBxOpenDrv Data")]
        public string lbltext
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("CmbBxOpenDrv Data")]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return cmbList.AutoCompleteCustomSource;
            }
            set
            {
                AutoCompleteCustomSource = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("CmbBxOpenDrv Data")]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return cmbList.AutoCompleteSource;
            }
            set
            {
                cmbList.AutoCompleteSource = value;
            }
        }
        [DefaultValue(AutoCompleteMode.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("CmbBxOpenDrv Data")]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return cmbList.AutoCompleteMode;
            }
            set
            {
                cmbList.AutoCompleteMode = value;
            }
        }

        [Browsable(false)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                int num = SelectedIndex;
                if (num != -1)
                {
                    return Items[num];
                }

                return null;
            }
            set
            {
                cmbList.SelectedItem = value;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return cmbList.SelectedIndex;
            }
            set
            {
                cmbList.SelectedIndex = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get
            {
                return cmbList.SelectedText;
            }
            set
            {
                cmbList.SelectedText = value;
            }
        }
        [Category("CmbBxOpenDrv - Appearance")]
        public Color ListBackColor
        {
            get { return listBackColor; }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }
    }
}
