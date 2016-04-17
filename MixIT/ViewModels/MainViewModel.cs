using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using MixIT.Navigations;
using MixIT.Shared.Models;

namespace MixIT.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public TalksViewModel MainPage { get; private set; }
        private readonly IEventsBus _eventsBus;
        private IPageViewModel _currentPage;

        public IPageViewModel CurrentPage
        {
            get { return _currentPage; }
            private set
            {
                _currentPage = value;
                RaisePropertyChanged(() => CurrentPage);
            }
        }

        public MainViewModel()
        {
            _eventsBus = new EventsBus();
            _eventsBus.On<DetailsPageRequested>(DisplayDetailsPage);
            _eventsBus.On<DuringThisTimeRequired>(DisplayDuringThisTimePage);

            var talksViewModel = new TalksViewModel(_eventsBus);
            talksViewModel.InitializeAsync();
            MainPage = talksViewModel;

            DisplayTalks();
        }

        public void DisplayTalks()
        {
            CurrentPage = MainPage;
        }

        private void DisplayDetailsPage(DetailsPageRequested detailsPageRequested)
        {
            CurrentPage = new DetailsViewModel(_eventsBus, detailsPageRequested.Talk);
        }

        private void DisplayDuringThisTimePage(DuringThisTimeRequired duringThisTimeRequired)
        {
            var talksDuringThisTime = GetTalksDuringThisTime(MainPage.Rooms.Select(r => r.Room), duringThisTimeRequired.Talk).ToList();
            if (talksDuringThisTime.Any())
            {
                CurrentPage = new DuringThisTimeViewModel(_eventsBus, talksDuringThisTime);
            }
        }

        private IEnumerable<Room> GetTalksDuringThisTime(IEnumerable<Room> allRooms, Talk referenceTalk)
        {
            IList<Room> roomsWithCurrentTalks = new List<Room>();
            foreach (var room in allRooms)
            {
                var currentTalkInThisRoom = room.Talks.FirstOrDefault(talk => !talk.IsDateUndefined && (talk.Start == referenceTalk.Start || talk.End == referenceTalk.End));
                if (currentTalkInThisRoom != null)
                {
                    roomsWithCurrentTalks.Add(new Room(room.Name, room.Date, new List<Talk> { currentTalkInThisRoom }));
                }
            }

            return roomsWithCurrentTalks;
        }
    }
}