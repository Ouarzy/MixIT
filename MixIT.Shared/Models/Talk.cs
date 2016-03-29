using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MixIT.Shared.Models
{

    public class Talk
    {
        public static readonly DateTime MixItFirstDay = new DateTime(2016, 04, 21);
        public static readonly DateTime MixItSecondDay = new DateTime(2016, 04, 22);

        public string Title { get; private set; }

        public string Summary { get; private set; }

        public string Description { get; private set; }

        public IList<Speaker> Speakers { get; private set; }
        
        public string Room { get; private set; }

        public LanguageEnum Language { get; private set; }

        public DateTime Date { get; private set; }

        public TimeSpan Start { get; private set; }

        public TimeSpan End { get; private set; }
        
        public bool IsDateUndefined { get; private set; }

        public Talk(string title, string summary, string description, IList<Speaker> speakers, string room, LanguageEnum language, DateTime date, TimeSpan start, TimeSpan end)
        {
            Title = title;
            Summary = summary;
            Description = description;
            Speakers = speakers;
            Room = room;
            Language = language;
            Date = date;
            Start = start;
            End = end;
        }

        public Talk(JToken jToken)
        {
            Title = (string)jToken["title"];
            Summary = (string)jToken["summary"];
            Description = (string)jToken["description"];
            Speakers = new List<Speaker>();
            Room = (string)jToken["room"] ?? Models.Room.Undefined;
            Language = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), (string)jToken["lang"]);

            var startToken = (string)jToken["start"];
            if (!string.IsNullOrEmpty(startToken))
            {
                Date = ((DateTime)jToken["start"]).Date;
                Start = ((DateTime)jToken["start"]).TimeOfDay;
                End = ((DateTime)jToken["end"]).TimeOfDay;                
            }
            else
            {
                IsDateUndefined = true;
            }
        }

        public void AddSpeaker(Speaker speaker)
        {
            Speakers.Add(speaker);
        }
    }
}