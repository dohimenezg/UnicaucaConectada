using EventosVista.MVVM.ICommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.Model
{
    internal class Invoker
    {
        private ICommand.ICommand _command;
        private static Invoker instance;

        private Invoker()
        {

        }

        public static Invoker getInstance()
        {
            if (instance == null)
            {
                instance = new Invoker(); 
            }
                
            return instance;
        }

        public void setCommand(ICommand.ICommand command)
        {
            this._command = command;
        }

        public ICommand.ICommand GetCommand()
        {
            return this._command;
        }

        public void execute()
        {
            _command.Execute();
        }
    }
}
