using EventosVista.Source.Core.Command;
using EventosVista.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventosVista.Source.ViewModel
{
    internal class RegisterViewModel
    {
        public bool UserSignup(string name, string username, string password, string email)
        {
            User user = new User()
            {
                Nombre = name,
                Nombre_Usuario = username,
                Contrasena = password,
                Correo = email
            };

            SaveCommand saveUser = new SaveCommand(user);
            Invoker.getInstance().setCommand(saveUser);
            Invoker.getInstance().execute();

            if (saveUser.response)
            {
                MessageBox.Show("Usuario registrado satisfactoriamente");
                return true;
            }
           return false;
        }
    }
}
