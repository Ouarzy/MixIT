using System;
using System.Threading.Tasks;
using MixIT.Shared.Models.Queries;

namespace MixIT.Shared.Repositories
{
    public interface IProxy
    {
        Task<ITalksQuery> LoadTalksAsync();

        Task<ITalksQuery> LoadLightTalksAsync();
    }
}
