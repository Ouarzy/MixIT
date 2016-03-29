using System;
using System.Collections.Generic;
using System.Linq;

namespace MixIT.Shared.Models.Queries
{
    public class RoomsQuery : IRoomsQuery
    {
        public IEnumerable<Room> Rooms { get; }

        public bool HasAnyError
        {
            get
            {
                return Exceptions.Any(ex => ex != null);
            }
        }

        public IEnumerable<Exception> Exceptions { get; }

        public RoomsQuery(IEnumerable<Room> rooms, IEnumerable<Exception> exceptions)
        {
            this.Rooms = rooms;
            this.Exceptions = exceptions.ToList();
        }
    }
}