using EventosVista.Source.Core.Command;
using EventosVista.Source.Model;
using System.Windows;

namespace EventosVista.Source.ViewModel
{
    internal class LogInViewModel
    {
        public bool UserLogin(string username, string password)
        {
            AuthenticateUserCommand authUserCmd = new AuthenticateUserCommand(username, password);
            Invoker.getInstance().setCommand(authUserCmd);
            Invoker.getInstance().execute();

            if (authUserCmd.response)
            {
                MessageBox.Show("Bienvenido! " + Session.GetInstance().user.nombre_usuario);
                return true;
            }
            else
            {
                MessageBox.Show("Nombre de Usuario o Contrasena invalidos!");
                return false;
            }
        }

    }
}
