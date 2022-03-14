﻿using EventosVista.MVVM.ICommand;
using EventosVista.MVVM.Model;
using EventosVista.MVVM.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventosVista.MVVM.View
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
            if (Utilities.anyFieldEmpty(RegisterFormGrid))
            {
                e.Handled = true;
                MessageBox.Show("Hay campos que deben ser llenados");
                return;
            }

           User user = new User()
           {
                nombre = this.nameField.Text,
                nombre_usuario = this.usernameField.Text,
                contrasena = this.passwordField.Password,
                correo = this.emailField.Text
           };

            Invoker invoker = Invoker.getInstance();
            invoker.setCommand(new SaveCommand(user));
            invoker.execute();

            this.nameField.Text = String.Empty;
            this.usernameField.Text = String.Empty;
            this.passwordField.Password = String.Empty;
            this.emailField.Text = String.Empty;
            this.emailField.SetCurrentValue(BackgroundProperty, Brushes.White);

            MessageBox.Show("Usuario registrado satisfactoriamente");
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
