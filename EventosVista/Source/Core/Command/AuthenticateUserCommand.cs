using EventosVista.Source.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.Source.Core.Command
{
    internal class AuthenticateUserCommand : ICommand
    {
        private string username;
        private string password;
        public bool response { get; set; }
        public AuthenticateUserCommand(string username, string password)
        {
            this.username = username;
            this.password = password;
            response = false;
        }
        public void Execute()
        {
            response = Authentication.AuthenticateUser(username, password);
        }
    }
}
