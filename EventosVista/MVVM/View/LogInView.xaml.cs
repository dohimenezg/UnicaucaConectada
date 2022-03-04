﻿using EventosVista.MVVM.Model;
using EventosVista.MVVM.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if(Authentication.AuthenticateUser(this.usernameField.Text, this.passwordField.Password))
            {
                MessageBox.Show("User found! User is "+ Session.GetInstance().user.nombre_usuario+" and Pass is: "+ Session.GetInstance().user.contrasena);
                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Nombre de Usuario o Contrasena invalidos!");
            }
            
        }
    }
}
