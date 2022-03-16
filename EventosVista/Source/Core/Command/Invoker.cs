using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.Source.Core.Command
{
    internal class Invoker
    {
        private ICommand _command = new DefaultCommand();
        private static Invoker? instance;

        private Invoker()
        {

        }

        public static Invoker GetInstance()
        {
            if (instance == null)
            {
                instance = new Invoker();
            }

            return instance;
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public ICommand GetCommand()
        {
            return _command;
        }

        public void Execute()
        {
            _command.Execute();
        }
    }
}
