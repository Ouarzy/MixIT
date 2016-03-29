using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MixIT.Navigations;
using MixIT.Shared.Models;

namespace MixIT.ViewModels
{
    public class DetailsViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IEventsBus _eventsBus;
        private readonly Talk _talk;

        private ObservableCollection<SpeakerViewModel> _speakers;

        public string Room => _talk.Room;

        public string Title => _talk.Title;

        public string Summary => _talk.Summary;

        public string Description => _talk.Description;

        public string Start => _talk.Start.ToString(@"hh\hmm");

        public string End => _talk.End.ToString(@"hh\hmm");

        public LanguageEnum Language => _talk.Language;

        public ObservableCollection<SpeakerViewModel> Speakers
        {
            get
            {
                return _speakers;
            }

            private set
            {
                if (value != _speakers)
                {
                    _speakers = value;
                    RaisePropertyChanged(() => Speakers);
                }
            }
        }

        public bool TalkDateDefined => !_talk.IsDateUndefined;

        public ICommand DuringThisTime { get; private set; }

        public DetailsViewModel(IEventsBus eventsBus, Talk talk)
        {
            _eventsBus = eventsBus;
            _talk = talk;
            DuringThisTime = new RelayCommand(OnDuringThisTime);
            CreateSpeakersViewModel(talk);
        }

        private void OnDuringThisTime()
        {
            _eventsBus.Raise(new DuringThisTimeRequired(_talk));
        }

        private void CreateSpeakersViewModel(Talk talk)
        {
            Speakers = new ObservableCollection<SpeakerViewModel>(talk.Speakers.Select(speaker => new SpeakerViewModel(speaker)));
        }
    }
}
