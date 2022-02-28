using EventosVista.MVVM.Model;
using System.Collections.ObjectModel;

namespace EventosVista.MVVM.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<Item> Songs { get; set; }
        public MainViewModel()
        {
            Songs = new ObservableCollection<Item>();
            PopulateCollection();
        }

        void PopulateCollection()
        {
            var item = new Item();
            Item[] Items = new Item[3];

            Items[0] = new Item();
            Items[0].Id = "1";
            Items[0].Name = "Test1";
            Items[1] = new Item();
            Items[1].Id = "2";
            Items[1].Name = "Test2";
            Items[2] = new Item();
            Items[2].Id = "3";
            Items[2].Name = "Test3";

            for (int i = 0; i < 3; i++)
            {
                var track = Items[i];
                Songs.Add(track);
            }
        }
    }
}
