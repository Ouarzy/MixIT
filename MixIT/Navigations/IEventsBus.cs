using System;

namespace MixIT.Navigations
{
    public interface IEventsBus
    {
        void On<TEvent>(Action<TEvent> handler) where TEvent : IApplicationEvent;
        void Raise(IApplicationEvent evt);
    }
}