using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.Model
{
    internal class Session
    {
        private static Session _instance;

        private Session() { }

        public static Session GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Session();
                _instance.user = null;
            }
            return _instance;
        }

        public User user { get; set; }

    }
}
