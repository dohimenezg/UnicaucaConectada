using EventosVista.Source.Core;
using EventosVista.Source.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EventosVista.Source.View
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utilities.AnyFieldEmpty(RegisterFormGrid))
            {
                e.Handled = true;
                MessageBox.Show("Hay campos que deben ser llenados");
                return;
            }
            ((RegisterViewModel)this.DataContext).UserSignup(this.nameField.Text, this.usernameField.Text, this.passwordField.Password, this.emailField.Text);
            this.nameField.Text = String.Empty;
            this.usernameField.Text = String.Empty;
            this.passwordField.Password = String.Empty;
            this.emailField.Text = String.Empty;
            this.emailField.SetCurrentValue(BackgroundProperty, Brushes.White);
            
        }

        private void emailField_KeyUp(object sender, KeyEventArgs e)
        {
            Regex reg = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            string email = this.emailField.Text;

            if (reg.IsMatch(email))
            {
                this.emailField.SetCurrentValue(BackgroundProperty, Brushes.LightGreen);
            }
            else
            {
                this.emailField.SetCurrentValue(BackgroundProperty, Brushes.Salmon);
            }
        }
    }
}
