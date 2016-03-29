using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace MixIT.Navigations
{
    public class EventsBus : IEventsBus
    {
        private readonly ConcurrentDictionary<Type, ConcurrentBag<Action<IApplicationEvent>>> _handlers =
            new ConcurrentDictionary<Type, ConcurrentBag<Action<IApplicationEvent>>>();

        public void On<TEvent>(Action<TEvent> handler) where TEvent : IApplicationEvent
        {
            GetHandlersForThisEvent(typeof(TEvent)).Add(e => handler((TEvent)e));
        }

        public void Raise(IApplicationEvent evt)
        {
            var handlers = GetHandlersForThisEvent(evt.GetType());
            foreach (var handler in handlers)
            {
                handler(evt);
            }
        }

        private ConcurrentBag<Action<IApplicationEvent>> GetHandlersForThisEvent(Type eventType)
        {
            ConcurrentBag<Action<IApplicationEvent>> handlersForThisEvent;
            if (!_handlers.TryGetValue(eventType, out handlersForThisEvent))
            {
                handlersForThisEvent = new ConcurrentBag<Action<IApplicationEvent>>();
                _handlers.AddOrUpdate(eventType, handlersForThisEvent, (type, currentList) =>
                {
                    handlersForThisEvent = currentList;
                    return currentList;
                });
            }

            return handlersForThisEvent;
        }
    }
}