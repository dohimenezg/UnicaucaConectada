using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EventosVista.Source.Core
{
    public static class Utilities
    {
        public static bool AnyFieldEmpty(Panel panel)
        {
            foreach (var child in panel.Children)
            {
                if (child is TextBox box)
                {
                    if (string.IsNullOrEmpty(box.Text))
                    {
                        return true;
                        
                    }
                } else if (child is DatePicker picker && string.IsNullOrEmpty(picker.Text))
                {
                  return true;
                }
                
            }
            return false;
        }

        public static string getImageName()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png";
                fldlg.ShowDialog();
                FileInfo fi = new FileInfo(fldlg.FileName);
                if (fi.Length > 5242880)
                {
                    MessageBox.Show("La imagen no debe superar 5MB");
                    return "";
                } else
                {
                    return fldlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return "";
            }
        }
    }
}
