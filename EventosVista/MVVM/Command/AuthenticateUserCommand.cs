using EventosVista.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.ICommand
{
    internal class AuthenticateUserCommand : ICommand
    {
        private string username;
        private string password;
        public Boolean response { get; set; }
        public AuthenticateUserCommand(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.response = false;
        }
        public void Execute()
        {
            response = Authentication.AuthenticateUser(username, password);
        }
    }
}
