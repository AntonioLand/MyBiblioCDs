using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBiblioCDs
{
    static class RegisterFunction
    {
        static RegistryKey key = null;
        static string msg1 = "";
        public static void OpenRegisterKey()
        {
            //RegistryKey key = null;
            //string msg1 = "";
            try
            {
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyBiblioCDs", true);
            }
            catch (SecurityException e)
            {
                msg1 = String.Format(Languages.msgSecurityException + ":\n\n{0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            catch (ObjectDisposedException e)
            {
                msg1 = string.Format(Languages.msgThekeyIsLocked + ": {0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException e)
            {
                msg1 = string.Format(Languages.msgUnauthorizedAccessException + ": {0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
        } // end of OpenRegister()

        public static object ReadKey(string namesubkey)
        {
            OpenRegisterKey();
            try
            {
                object obj = key.GetValue(namesubkey);
                return obj;
            }
            catch (SecurityException e)
            {
                msg1 = String.Format(Languages.msgSecurityException + ":\n\n{0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            catch (ObjectDisposedException e)
            {
                msg1 = string.Format(Languages.msgThekeyIsLocked + ": {0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException e)
            {
                msg1 = string.Format(Languages.msgUnauthorizedAccessException + ": {0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            RegisterKeyClose();
            return null;
        } // end of ReadKey

        public static void SetKey(string namesubkey, object val)
        {
            OpenRegisterKey();
            try
            {
                key.SetValue(namesubkey, (object)val);
            }
            catch (SecurityException e)
            {
                msg1 = String.Format(Languages.msgSecurityException + ":\n\n{0}");
                MessageBox.Show(msg1, e.Message);
            }
            catch (ObjectDisposedException e)
            {
                msg1 = string.Format(Languages.msgThekeyIsLocked + ": {0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException e)
            {
                msg1 = string.Format(Languages.msgUnauthorizedAccessException + ": {0}");
                MessageBox.Show(msg1, e.Message);
                Environment.Exit(1);
            }
            RegisterKeyClose();
        } // end of SetKey

        public static void RegisterKeyClose()
        {
            key.Close();
        }
    }
}
