using System;
using System.Collections.Generic;

namespace MixIT.Shared.Models.Queries
{
    public interface IRoomsQuery
    {
        bool HasAnyError { get; }

        IEnumerable<Exception> Exceptions { get; }

        IEnumerable<Room> Rooms { get; }
    }
}