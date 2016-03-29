using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using MixIT.Navigations;
using MixIT.Shared.Models;

namespace MixIT.ViewModels
{
    public class DuringThisTimeViewModel : ViewModelBase, IPageViewModel
    {
        private IList<RoomViewModel> _rooms;

        public IList<RoomViewModel> Rooms
        {
            get
            {
                return _rooms;
            }

            private set
            {
                _rooms = value;
                RaisePropertyChanged(() => Rooms);
            }
        }

        public string NameOfReferentTalk { get; private set; }

        public DuringThisTimeViewModel(IEventsBus eventsBus, IEnumerable<Room> roomsDuringThisTime)
        {
            Rooms = roomsDuringThisTime.Select(room=> new RoomViewModel(eventsBus, room)).ToList();
            NameOfReferentTalk = Rooms.First().Talks.First().Title;
        }
    }
}
