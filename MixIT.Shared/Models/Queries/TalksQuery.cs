using System;
using System.Collections.Generic;

namespace MixIT.Shared.Models.Queries
{
    public interface ITalksQuery
    {
        bool HasError { get; }

        IEnumerable<Exception> Exceptions { get; }

        IEnumerable<ITalkQuery> TalkQueries { get; }
    }
}
