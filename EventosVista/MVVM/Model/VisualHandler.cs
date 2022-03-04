using EventosVista.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventosVista.MVVM.Model
{
    public static class VisualHandler
    {
        public static MainWindow MainWindow { get; set; }
        
        public static void updateSessionButtons()
        {
            MainWindow.SignUpButton.IsEnabled = false;
            MainWindow.SignUpButton.Visibility = Visibility.Collapsed;
            MainWindow.LoginButton.IsEnabled = false;
            MainWindow.LoginButton.Visibility = Visibility.Collapsed;
            MainWindow.LogoutButton.IsEnabled = true;
            MainWindow.LogoutButton.Visibility = Visibility.Visible;
            MainWindow.NewEventButton.IsEnabled = true;
            MainWindow.NewEventButton.Visibility = Visibility.Visible;
            
        }

        public static void updateLogoutButtons()
        {
            MainWindow.SignUpButton.IsEnabled = true;
            MainWindow.SignUpButton.Visibility = Visibility.Visible;
            MainWindow.LoginButton.IsEnabled = true;
            MainWindow.LoginButton.Visibility = Visibility.Visible;
            MainWindow.LogoutButton.IsEnabled = false;
            MainWindow.LogoutButton.Visibility = Visibility.Collapsed;
            MainWindow.NewEventButton.IsEnabled = false;
            MainWindow.NewEventButton.Visibility = Visibility.Hidden;
            

        }
    }
}
