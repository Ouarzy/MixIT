using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using MixIT.Shared.Models;
using MixIT.Shared.Models.Queries;

namespace MixIT.Shared.Repositories
{
    public class MixItRepository : IRepository
    {
        private readonly CoreDispatcher _uiDispatcher;
        private readonly IProxy _proxy;
        private DateTime _dateTalk;

        private ITalksQuery _talksQueryCache;

        private ITalksQuery _lightTalksQueryCache;

        public MixItRepository(CoreDispatcher uiDispatcher)
        {
            _uiDispatcher = uiDispatcher;
#if DEBUG
            _proxy = new LocalProxy();
#else
            _proxy = new WebServicesProxy();
#endif
        }

        public async Task<IRoomsQuery> LoadRoomsTalksAsync(DateTime dateTalk)
        {
            _dateTalk = dateTalk;

            if (_talksQueryCache == null)
            {
                _talksQueryCache = await _proxy.LoadTalksAsync();
            }

            return ConvertServerTalksToRoomsQuery(_talksQueryCache);
        }

        public async Task<IRoomsQuery> LoadRoomsLightTalksAsync(DateTime dateTalk)
        {
            _dateTalk = dateTalk;

            if (_lightTalksQueryCache == null)
            {
                _lightTalksQueryCache = await _proxy.LoadLightTalksAsync();
            }

            return ConvertServerTalksToRoomsQuery(_lightTalksQueryCache);
        }

        private IRoomsQuery ConvertServerTalksToRoomsQuery(ITalksQuery talksQuery)
        {
            var talks = talksQuery.TalkQueries.Select(o => o.Talk).ToList();
            var roomNamesOfTheDay = talks.Where(o => o.Date.Equals(_dateTalk) || o.IsDateUndefined).Select(o => o.Room).Distinct();
            var talksOfTheDay = talks.Where(o => o.Date.Equals(_dateTalk) || o.IsDateUndefined);
            return new RoomsQuery(roomNamesOfTheDay.Select(roomName => new Room(roomName, _dateTalk, talksOfTheDay.Where(o => o.Room.Equals(roomName)).OrderBy(o => o.Start).ToList())), talksQuery.Exceptions);
        }
    }
}