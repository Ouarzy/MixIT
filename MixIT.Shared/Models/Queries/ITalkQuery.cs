using System;

namespace MixIT.Shared.Models.Queries
{
    public interface ITalkQuery
    {
        Exception Exception { get; }

        Talk Talk { get; }
    }
}