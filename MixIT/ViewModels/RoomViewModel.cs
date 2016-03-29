using System.Collections.ObjectModel;
using System.Windows.Input;
using MixIT.Navigations;
using MixIT.Shared.Models;

namespace MixIT.ViewModels
{
    public class RoomViewModel
    {
        public Room Room { get; private set; }

        public string Name => Room.Name;

        public ObservableCollection<TalkViewModel> Talks { get; }

        public RoomViewModel(IEventsBus eventsBus, Room room)
        {
            Room = room;

            Talks = new ObservableCollection<TalkViewModel>();
            foreach (var talk in Room.Talks)
            {
                Talks.Add(new TalkViewModel(eventsBus, talk));
            }
        }
    }
}