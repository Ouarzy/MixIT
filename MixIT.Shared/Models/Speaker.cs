using Newtonsoft.Json.Linq;

namespace MixIT.Shared.Models
{
    public class Speaker
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Avatar { get; private set; }

        public Speaker(string firstName, string lastName, string avatar)
        {
            Avatar = avatar;
            LastName = lastName;
            FirstName = firstName;
        }

        public Speaker(JToken jToken)
        {
            Avatar = string.Format("{0}{1}", "https://www.gravatar.com/avatar/", (string)jToken["hash"]);
            LastName = (string)jToken["lastname"];
            FirstName = (string)jToken["firstname"];
        }
    }
}