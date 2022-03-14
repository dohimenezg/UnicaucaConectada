using EventosVista.MVVM.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.Model
{
    internal class Invoker
    {
        private ICommand _command;

        public Invoker()
        {

        }

        public void setCommand(ICommand command)
        {
            this._command = command;
        }

        public ICommand GetCommand()
        {
            return this._command;
        }

        public void execute()
        {
            _command.Execute();
        }
    }
}
