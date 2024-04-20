using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using Microsoft.Win32;
using System.Security;
using System.Runtime.InteropServices;
using System.Threading;


#pragma warning disable IDE1006, IDE0017
namespace MyBiblioCDs
{
    public partial class MainForm : Form
    {
        private int CdInfo()
        {
            return DbFunction.SaveOnlyInfo(objMain);

        }

    }
}