using EventosVista.MVVM.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.ICommand
{
    internal class SaveCommand : ICommand
    {
        private Object toSaveItem;
        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;

        public Boolean response { get; set; }
        public SaveCommand(Object obj)
        {   
            this.toSaveItem = obj;
            this.response = false;


            if (toSaveItem.GetType() == typeof(User))
            {
                _userRepository = RepositoryFactory.getInstance().GetUserRepository();
            }
            else if(toSaveItem.GetType() == typeof(Event))
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
