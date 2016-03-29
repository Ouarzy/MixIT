using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MixIT.Shared.Models;
using MixIT.Shared.Models.Queries;
using Newtonsoft.Json.Linq;

namespace MixIT.Shared.Repositories
{
    public class WebServicesProxy : IProxy
    {
        private const string MixItWebService = "http://www.mix-it.fr/api/session";
        private readonly HttpClient _mixItClient;

        public WebServicesProxy()
        {
            _mixItClient = new HttpClient();
        }

        public async Task<ITalksQuery> LoadTalksAsync()
        {
            var requestUri = new Uri(MixItWebService + "/talk");
            return await GetTalksFromRequestedQuery(requestUri);
        }

        public async Task<ITalksQuery> LoadLightTalksAsync()
        {
            var requestUri = new Uri(MixItWebService + "/lightningtalks");
            return await GetTalksFromRequestedQuery(requestUri);
        }

        private async Task<ITalksQuery> GetTalksFromRequestedQuery(Uri requestUri)
        {
            var response = await _mixItClient.GetAsync(requestUri);
            var content = await response.Content.ReadAsStreamAsync();
            return await ConvertResultToTalksQuery(content);
        }

        private async Task<ITalksQuery> ConvertResultToTalksQuery(Stream result)
        {
            var reader = new StreamReader(result);
            var json = reader.ReadToEnd();
            var jArray = JArray.Parse(json);

            IList<ITalkQuery> talksQueries = new List<ITalkQuery>();
            foreach (var jToken in jArray)
            {
                var talkQuery = await TryCreateTalk(jToken);
                talksQueries.Add(talkQuery);
            }

            return new TalksQuery(talksQueries);
        }

        private async Task<ITalkQuery> TryCreateTalk(JToken jToken)
        {
            Exception exception = null;
            Talk talk = null;

            try
            {
                talk = new Talk(jToken);
                await AddSpeakersToTalkAsync(jToken, talk);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return new TalkQuery(talk, exception);
        }

        private async Task AddSpeakersToTalkAsync(JToken jTokenLinks, Talk talk)
        {
            var speakerLinks = GetSpeakersLinks(jTokenLinks["links"]);
            foreach (var speakerLink in speakerLinks)
            {
                var speaker = await GetSpeakerFromUrl(speakerLink);
                talk.AddSpeaker(speaker);
            }
        }

        private async Task<Speaker> GetSpeakerFromUrl(string speakerUrl)
        {
            var response = await _mixItClient.GetAsync(speakerUrl);
            var content = await response.Content.ReadAsStreamAsync();

            var reader = new StreamReader(content);
            var json = reader.ReadToEnd();
            var jToken = JToken.Parse(json);

            return new Speaker(jToken);
        }

        private IList<string> GetSpeakersLinks(IEnumerable<JToken> speakersLinkToken)
        {
            return speakersLinkToken.Where(linkToken => string.Equals((string)linkToken["rel"], "speaker")).Select(speakerToken => (string)speakerToken["href"]).ToList();
        }
    }
}
