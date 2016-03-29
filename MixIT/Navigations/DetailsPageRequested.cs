using MixIT.Shared.Models;

namespace MixIT.Navigations
{
    public class DetailsPageRequested : IApplicationEvent
    {
        public Talk Talk { get; private set; }

        public DetailsPageRequested(Talk talk)
        {
            Talk = talk;
        }
    }
}
