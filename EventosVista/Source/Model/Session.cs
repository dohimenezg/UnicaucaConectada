using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.Source.Model
{
    internal class Session
    {
        private static Session? _instance;

        private Session() { }

        public static Session GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Session
                {
                    User = null
                };
            }
            return _instance;
        }

        public User? User { get; set; }

    }
}
