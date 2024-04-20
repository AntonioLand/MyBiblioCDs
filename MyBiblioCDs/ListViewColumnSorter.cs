using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

#pragma warning disable CS1591


namespace MyBiblioCDs
{

    public class ListViewColumnSorter : IComparer
    {
        public int ColumnToSort { get; set; }
        public SortOrder OrderOfSort { get; set; }
        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// Used to compare two objects (major, minor, equal)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int compareResult = 0;
            try
            {
                ListViewItem listviewX, listviewY;
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
                if (ColumnToSort == 0)
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text,
                                                  listviewY.SubItems[ColumnToSort].Text);
                }
                else if (ColumnToSort == 1)
                {
                    int one, two;
                    if (listviewX.SubItems[ColumnToSort].Text != string.Empty)
                    {
                        one = Convert.ToInt32(listviewX.SubItems[ColumnToSort].Text);
                    }
                    else
                        one = 0;
                    if (listviewY.SubItems[ColumnToSort].Text != string.Empty)
                        two = Convert.ToInt32(listviewY.SubItems[ColumnToSort].Text);
                    else
                        two = 0;

                    compareResult = ObjectCompare.Compare(one, two);
                }
                else if (ColumnToSort == 2)
                {
                    DateTime dateX;
                    DateTime dateY;
                    if (DateTime.TryParse(listviewX.SubItems[ColumnToSort].Text, out dateX) && DateTime.TryParse(listviewY.SubItems[ColumnToSort].Text, out dateY))
                    {
                        compareResult = ObjectCompare.Compare(dateX, dateY);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }
    }



    public class tplistViewColumnSorter : IComparer
    {
        public int ColumnToSort { get; set; }
        public SortOrder OrderOfSort { get; set; }
        private CaseInsensitiveComparer ObjectCompare;

        public tplistViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult = 0;
            try
            {
                ListViewItem listviewX, listviewY;
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
                if (ColumnToSort == 0 || ColumnToSort == 4)
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text,
                                                  listviewY.SubItems[ColumnToSort].Text);
                }
                else if (ColumnToSort == 1)
                {
                    int one, two;
                    if (listviewX.SubItems[ColumnToSort].Text != string.Empty)
                    {
                        one = Convert.ToInt32(listviewX.SubItems[ColumnToSort].Text);
                    }
                    else
                        one = 0;
                    if (listviewY.SubItems[ColumnToSort].Text != string.Empty)
                        two = Convert.ToInt32(listviewY.SubItems[ColumnToSort].Text);
                    else
                        two = 0;

                    compareResult = ObjectCompare.Compare(one, two);
                }
                else if (ColumnToSort == 2 || ColumnToSort == 3)
                {
                    DateTime dateX;
                    DateTime dateY;
                    if (DateTime.TryParse(listviewX.SubItems[ColumnToSort].Text, out dateX) && DateTime.TryParse(listviewY.SubItems[ColumnToSort].Text, out dateY))
                    {
                        compareResult = ObjectCompare.Compare(dateX, dateY);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }
    }
}
