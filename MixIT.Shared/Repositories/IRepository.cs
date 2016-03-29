using System;
using System.Threading.Tasks;
using MixIT.Shared.Models.Queries;

namespace MixIT.Shared.Repositories
{
    public interface IRepository
    {
        Task<IRoomsQuery> LoadRoomsTalksAsync(DateTime dateTalk);

        Task<IRoomsQuery> LoadRoomsLightTalksAsync(DateTime dateTalk);
    }
}