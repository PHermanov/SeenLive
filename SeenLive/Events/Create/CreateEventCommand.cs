using MediatR;
using SeenLive.Infrastructure;
using System;

namespace SeenLive.Events.Create
{
    public class CreateEventCommand
    : IRequest<IHandlerResult<EventViewModel>>
    {
        public string Name { get; init; } = string.Empty;
        public DateTime Date { get; init; }
        public string? Info { get; init; }
        public string EventType { get; init; } = string.Empty;

        public EventEntity ToEntity()
            => new()
            {
                Name = Name.Trim(),
                Date = Date,
                Info = Info,
                EventType = Enum.Parse<EventType>(EventType, true)
            };

    }
}
