using EventosVista.Source.Access;
using EventosVista.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.Source.Core.Command
{
    internal class SaveCommand : ICommand
    {
        private readonly object toSaveItem;
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        public bool response { get; set; }
        public SaveCommand(object obj)
        {
            toSaveItem = obj;
            response = false;


            if (toSaveItem.GetType() == typeof(User))
            {
                _userRepository = RepositoryFactory.getInstance().GetUserRepository();
            }
            else if (toSaveItem.GetType() == typeof(Event))
            {
                _eventRepository = RepositoryFactory.getInstance().GetEventRepository();
            }
        }
        public void Execute()
        {
            if (toSaveItem.GetType() == typeof(User))
            {
                response = _userRepository.saveUser((User)toSaveItem);
            }
            else if (toSaveItem.GetType() == typeof(Event))
            {
                response = _eventRepository.saveEvent((Event)toSaveItem);
            }
        }
    }
}
