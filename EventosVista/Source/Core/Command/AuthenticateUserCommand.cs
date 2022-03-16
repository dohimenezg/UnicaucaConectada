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
        private readonly string username;
        private readonly string password;
        public bool Response { get; set; }
        public AuthenticateUserCommand(string username, string password)
        {
            this.username = username;
            this.password = password;
            Response = false;
        }
        public void Execute()
        {
            Response = Authentication.AuthenticateUser(username, password);
        }
    }
}
