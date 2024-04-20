using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MyBiblioCDs
{
    static class FilesWorks
    {

        public static void HashString(InfoFiles isthisfile, bool isImg)
        {
            // Debug.WriteLine(isthisfile.thisfile.FullName);
            CalculateHashString(ref isthisfile);
            string codehash = string.Empty;

            if (isthisfile.hashcode == string.Empty)
            {
                if (isImg)
                {
                    try
                    {
                        codehash = ImageDataHash(isthisfile.thisfile);
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (codehash == string.Empty)
                    {
                        LogProj.Info("Not found ext file to calculate hash value");
                    }
                    else
                        isthisfile.hashcode = codehash;
                }
                else
                {
                    try
                    {
                        using (var md5 = MD5.Create())
                        {
                            // LogProj.Info("Hash => " + isthisfile.thisfile.FullName);
                            using (var stream = File.OpenRead(isthisfile.thisfile.FullName))
                            {
                                var hash = md5.ComputeHash(stream);
                                codehash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (codehash != string.Empty)
                                    isthisfile.hashcode = codehash;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }            
        }

        public static void CalculateHashString(ref InfoFiles fl)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (FileStream stream = File.OpenRead(fl.thisfile.FullName))
                    {
                        var hash = md5.ComputeHash(stream);
                        fl.hashcode = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            } 
            catch (Exception ex)
            {
                fl.chck = true;
                LogProj.exception("Exception during file: " + fl.thisfile.FullName + " " + ex.Message);
            }
        }
        public static string ImageDataHash(FileInfo imgFile)
        {
            using (Bitmap bmp = (Bitmap)Bitmap.FromFile(imgFile.FullName))
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
                IntPtr dataPointer = bmpData.Scan0;
                int totalBytes = bmpData.Stride * bmp.Height;
                byte[] values = new byte[totalBytes];
                System.Runtime.InteropServices.Marshal.Copy(dataPointer, values, 0, totalBytes);
                bmp.UnlockBits(bmpData);
                SHA256 sha = new SHA256Managed();
                byte[] hash = sha.ComputeHash(values);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
