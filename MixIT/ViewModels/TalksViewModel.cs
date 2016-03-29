using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using MixIT.Navigations;
using MixIT.Shared.Models;
using MixIT.Shared.Models.Queries;
using MixIT.Shared.Repositories;

namespace MixIT.ViewModels
{
    public class TalksViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IEventsBus _eventsBus;
        private const string TalksString = "Talks";
        private const string LightTalksString = "Lightning Talks";
        private static readonly string DatePattern = CultureInfo.CurrentCulture.DateTimeFormat.MonthDayPattern;
        private readonly IRepository _repository;

        private DateTime _selectedDateMixIt = Talk.MixItFirstDay;
        private string _selectedTypeTalk = TalksString;
        private bool _showError;
        private string _errorMessage;
        private bool _isLoading;
        private IList<RoomViewModel> _rooms;

        private DateTime SelectedDateMixIt
        {
            get
            {
                return _selectedDateMixIt;
            }

            set
            {
                if (value != _selectedDateMixIt)
                {
                    _selectedDateMixIt = value;
                    RaisePropertyChanged(() => SelectedDateMixIt);
                    RaisePropertyChanged(() => SelectedDateMixItString);
                    InitializeAsync();
                }
            }
        }

        public string SelectedDateMixItString
        {
            get
            {
                return SelectedDateMixIt.ToString(DatePattern);
            }
        }

        public string SelectedTypeTalk
        {
            get
            {
                return _selectedTypeTalk;
            }

            private set
            {
                if (value != _selectedTypeTalk)
                {
                    _selectedTypeTalk = value;
                    RaisePropertyChanged(() => SelectedTypeTalk);
                    InitializeAsync();
                }
            }
        }

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

        public bool ShowError
        {
            get
            {
                return _showError;
            }

            private set
            {
                _showError = value;
                RaisePropertyChanged(() => ShowError);
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }

            private set
            {
                this._errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        public bool IsLoading
        {
            get
            {
                return this._isLoading;
            }

            private set
            {
                this._isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public ICommand TalkClickCommand
        {
            get;
            private set;
        }

        public ICommand LigthtalkClickCommand
        {
            get;
            private set;
        }

        public ICommand FirstDayClickCommand
        {
            get;
            private set;
        }

        public ICommand SecondDayClickCommand
        {
            get;
            private set;
        }

        public ICommand ReloadData
        {
            get;
            private set;
        }

        public TalksViewModel(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
            Rooms = new ObservableCollection<RoomViewModel>();
            _repository = new MixItRepository(DispatcherHelper.UIDispatcher);
            TalkClickCommand = new RelayCommand(OnTalkClick);
            LigthtalkClickCommand = new RelayCommand(OnLigthtalkClick);
            FirstDayClickCommand = new RelayCommand(OnFirstDayClick);
            SecondDayClickCommand = new RelayCommand(OnSecondDayClick);
            ReloadData = new RelayCommand(InitializeAsync);
        }

        private void DisplayError(string exceptionMessage)
        {
            Rooms = new List<RoomViewModel>();
            ErrorMessage = exceptionMessage;
            ShowError = true;
        }

        private void HideError()
        {
            ShowError = false;
        }

        private void OnSecondDayClick()
        {
            SelectedDateMixIt = Talk.MixItSecondDay;
        }

        private void OnFirstDayClick()
        {
            SelectedDateMixIt = Talk.MixItFirstDay;
        }

        private void OnLigthtalkClick()
        {
            SelectedTypeTalk = LightTalksString;
        }

        private void OnTalkClick()
        {
            SelectedTypeTalk = TalksString;
        }

        public async void InitializeAsync()
        {
            IsLoading = true;

            IRoomsQuery roomsQuery;
            switch (SelectedTypeTalk)
            {
                case LightTalksString:
                    {
                        roomsQuery = await _repository.LoadRoomsLightTalksAsync(SelectedDateMixIt);
                        break;
                    }

                default:
                    {
                        roomsQuery = await _repository.LoadRoomsTalksAsync(SelectedDateMixIt);
                        break;
                    }
            }

            RoomsLoaded(roomsQuery);
        }

        private void RoomsLoaded(IRoomsQuery roomsQuery)
        {
            if (roomsQuery.HasAnyError)
            {
                DisplayError("Une erreur est survenue lors de la récupération des données. Merci de vérfier votre connexion.");
            }
            else
            {
                HideError();
                var rooms = roomsQuery.Rooms.ToList();
                if (!rooms.Any())
                {
                    DisplayError("Les sessions n'ont pas encore été publiées, il faut patienter un peu. Plus d'infos sur www.mix-it.fr.");
                }
                else
                {
                    var tempRooms = new List<RoomViewModel>();
                    for (var roomIndex = 0; roomIndex < rooms.Count(); roomIndex++)
                    {
                        tempRooms.Add(new RoomViewModel(_eventsBus, rooms[roomIndex]));
                    }
                    Rooms = new List<RoomViewModel>(tempRooms);
                }
            }

            IsLoading = false;
        }
    }
}