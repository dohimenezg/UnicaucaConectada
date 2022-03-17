using EventosVista.Source.Core;
using EventosVista.Source.Model;
using EventosVista.Source.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EventosVista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Session.GetInstance().User = null;
            SignUpButton.IsEnabled = true;
            SignUpButton.Visibility = Visibility.Visible;
            LoginButton.IsEnabled = true;
            LoginButton.Visibility = Visibility.Visible;
            LogoutButton.IsEnabled = false;
            LogoutButton.Visibility = Visibility.Collapsed;
            NewEventButton.IsEnabled = false;
            NewEventButton.Visibility = Visibility.Collapsed;
            ((MainViewModel)this.DataContext).HomeRouter();
        }

        private void ContentControl_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                if (button.Name.Equals("register"))
                {
                    ((MainViewModel)this.DataContext).RegisterRouter();
                }
                else if (((Button)e.OriginalSource).Name.Equals("LoginButton"))
                {
                    SignUpButton.IsEnabled = false;
                    SignUpButton.Visibility = Visibility.Collapsed;
                    LoginButton.IsEnabled = false;
                    LoginButton.Visibility = Visibility.Collapsed;
                    LogoutButton.IsEnabled = true;
                    LogoutButton.Visibility = Visibility.Visible;
                    NewEventButton.IsEnabled = true;
                    NewEventButton.Visibility = Visibility.Visible;
                    ((MainViewModel)this.DataContext).HomeRouter();
                }
                else
                {
                    ((MainViewModel)this.DataContext).HomeRouter();
                }
            }
        }
    }
}
