using MixIT.Shared.Models;

namespace MixIT.Navigations
{
    public class DuringThisTimeRequired : IApplicationEvent
    {
        public Talk Talk { get; private set; }

        public DuringThisTimeRequired(Talk talk)
        {
            Talk = talk;
        }
    }
}
