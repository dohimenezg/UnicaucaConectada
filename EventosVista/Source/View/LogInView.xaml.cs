using EventosVista.Source.Core;
using EventosVista.Source.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace EventosVista.Source.View
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (Utilities.anyFieldEmpty(LoginFormGrid))
            {
                MessageBox.Show("Hay campos que deben ser llenados");
                return;
            }
            if(((LogInViewModel)this.DataContext).UserLogin(this.usernameField.Text, this.passwordField.Password))
            {
                e.Handled = false;
            }
        }
    }
}
