using System;
using System.Collections.Generic;

namespace MixIT.Shared.Models
{
    public class Room
    {
        public const string Undefined = "";

        public string Name { get; private set; }

        public DateTime Date { get; private set; }

        public IList<Talk> Talks { get; private set; }

        public Room(string name, DateTime date, IList<Talk> talks)
        {
            Talks = talks;
            Date = date;
            Name = name;
        }
    }
}
