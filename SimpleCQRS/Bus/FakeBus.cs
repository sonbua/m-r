using System;
using System.Collections.Generic;
using System.Threading;
using SimpleCQRS.Commands;
using SimpleCQRS.Events;

namespace SimpleCQRS.Bus
{
    public class FakeBus : ICommandSender, IEventPublisher
    {
        private readonly Dictionary<Type, List<Action<Message>>> _routes = new Dictionary<Type, List<Action<Message>>>();

        public void Send<TCommand>(TCommand command) where TCommand : Command
        {
            List<Action<Message>> handlers;

            if (!_routes.TryGetValue(typeof (TCommand), out handlers))
            {
                throw new InvalidOperationException("no handler registered");
            }

            if (handlers.Count != 1)
            {
                throw new InvalidOperationException("cannot send to more than one handler");
            }

            handlers[0].Invoke(command);
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            List<Action<Message>> handlers;

            if (!_routes.TryGetValue(@event.GetType(), out handlers))
            {
                return;
            }

            foreach (var handler in handlers)
            {
                //dispatch on thread pool for added awesomeness
                var handlerCopy = handler;
                ThreadPool.QueueUserWorkItem(x => handlerCopy.Invoke(@event));
            }
        }

        public void RegisterHandler<TMessage>(Action<TMessage> handler) where TMessage : Message
        {
            MessageHandlers<TMessage>().Add(x => handler.Invoke((TMessage) x));
        }

        private List<Action<Message>> MessageHandlers<TMessage>() where TMessage : Message
        {
            List<Action<Message>> handlers;

            if (_routes.TryGetValue(typeof (TMessage), out handlers))
            {
                return handlers;
            }

            handlers = new List<Action<Message>>();
            _routes.Add(typeof (TMessage), handlers);

            return handlers;
        }
    }
}
