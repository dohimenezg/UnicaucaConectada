using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.Source.Access
{
    internal class RepositoryFactory
    {
        private static RepositoryFactory? instance;

        private RepositoryFactory()
        {

        }

        public static RepositoryFactory getInstance()
        {
            if (instance == null)
            {
                instance = new RepositoryFactory();
            }
            return instance;
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }

        public IEventRepository GetEventRepository()
        {
            return new EventRepository();
        }
    }
}
