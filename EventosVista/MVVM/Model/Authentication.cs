using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace EventosVista.MVVM.Model
{
    internal class Authentication
    {

        public static Boolean AuthenticateUser(string username, string password)
        {

            IUserRepository repo = new UserRepository();
            User user;
            
            user = repo.findUser(username);
            
            if (user == null)
            {
                return false;
            }

            if (user.contrasena == password)
            {
                Session.GetInstance().user = user;
                VisualHandler.updateSessionButtons();
                return true;
            }
            return false;
            
        }
    }
}
