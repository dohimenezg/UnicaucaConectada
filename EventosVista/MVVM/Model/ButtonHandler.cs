using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventosVista.MVVM.Model
{
    public static class ButtonHandler
    {
        public static MainWindow MainWindow { get; set; }

        public static void updateSessionButtons()
        {
            ButtonHandler.MainWindow.SignUpButton.IsEnabled = false;
            ButtonHandler.MainWindow.SignUpButton.Visibility = Visibility.Collapsed;
            ButtonHandler.MainWindow.LoginButton.IsEnabled = false;
            ButtonHandler.MainWindow.LoginButton.Visibility = Visibility.Collapsed;
            ButtonHandler.MainWindow.LogoutButton.IsEnabled = true;
            ButtonHandler.MainWindow.LogoutButton.Visibility = Visibility.Visible;
            
        }
    }
}
