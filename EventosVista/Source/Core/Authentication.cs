using EventosVista.Source.Access;
using EventosVista.Source.Model;
using System;

namespace EventosVista.Source.Core
{
    internal static class Authentication
    {

        public static bool AuthenticateUser(string username, string password)
        {

            IUserRepository repo = new UserRepository();
            User? user;

            user = repo.findUser(username);

            if (user == null)
            {
                return false;
            }

            if (user.Contrasena == password)
            {
                Session.GetInstance().User = user;
                VisualHandler.updateSessionButtons();
                return true;
            }
            return false;

        }
    }
}
