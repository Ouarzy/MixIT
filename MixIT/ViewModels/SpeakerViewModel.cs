using MixIT.Shared.Models;

namespace MixIT.ViewModels
{
    public class SpeakerViewModel
    {
        private readonly Speaker _speaker;

        public string FirstName
        {
            get
            {
                return _speaker.FirstName;
            }
        }

        public string LastName
        {
            get
            {
                return _speaker.LastName;
            }
        }

        public string Avatar
        {
            get
            {
                return _speaker.Avatar;
            }
        }

        public SpeakerViewModel(Speaker speaker)
        {
            _speaker = speaker;
        }
    }
}