using System;

namespace MixIT.Shared.Models.Queries
{
    public class TalkQuery : ITalkQuery
    {
        public Exception Exception { get; private set; }

        public Talk Talk { get; private set; }

        public TalkQuery(Talk talk, Exception exception)
        {
            Talk = talk;
            Exception = exception;
        }
    }
}