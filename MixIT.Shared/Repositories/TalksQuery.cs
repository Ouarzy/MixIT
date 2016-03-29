using System;
using System.Collections.Generic;
using System.Linq;
using MixIT.Shared.Models.Queries;

namespace MixIT.Shared.Repositories
{
    public class TalksQuery : ITalksQuery
    {
        public bool HasError
        {
            get
            {
                return this.Exceptions.Any();
            }
        }

        public IEnumerable<Exception> Exceptions
        {
            get
            {
                return this.TalkQueries.Select(o => o.Exception);
            }
        }

        public IEnumerable<ITalkQuery> TalkQueries { get; private set; }

        public TalksQuery(IEnumerable<ITalkQuery> talkQueries)
        {
            this.TalkQueries = talkQueries;
        }
    }
}