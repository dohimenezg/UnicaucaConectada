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
            Invoker.GetInstance().SetCommand(authUserCmd);
            Invoker.GetInstance().Execute();

            if (authUserCmd.Response)
            {
                MessageBox.Show("Bienvenido! " + Session.GetInstance().User.Nombre_Usuario);
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
