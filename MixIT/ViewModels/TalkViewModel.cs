using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MixIT.Navigations;
using MixIT.Shared.Models;

namespace MixIT.ViewModels
{
    public class TalkViewModel : ViewModelBase
    {
        private readonly IEventsBus _eventsBus;
        private readonly Random _random = new Random();

        private ObservableCollection<SpeakerViewModel> _speakers;

        public Talk Talk { get; private set; }

        public string Title => Talk.Title;

        public string Resume => Talk.Summary;

        public string Start => Talk.Start.ToString(@"hh\hmm");

        public string End => Talk.End.ToString(@"hh\hmm");

        public LanguageEnum Language => Talk.Language;

        public ICommand ViewDetailCommand { get; private set; }

        public SpeakerViewModel RandomSpeaker => _speakers[_random.Next(0, _speakers.Count)];

        public bool TalkDateDefined => !Talk.IsDateUndefined;

        public TalkViewModel(IEventsBus eventsBus, Talk talk)
        {
            _eventsBus = eventsBus;
            Talk = talk;
            CreateSpeakersViewModel();
            ViewDetailCommand = new RelayCommand(OnViewDetailCommand);
        }

        private void OnViewDetailCommand()
        {
            _eventsBus.Raise(new DetailsPageRequested(Talk));
        }

        private void CreateSpeakersViewModel()
        {
            _speakers = new ObservableCollection<SpeakerViewModel>(Talk.Speakers.Select(speaker => new SpeakerViewModel(speaker)));
        }
    }
}