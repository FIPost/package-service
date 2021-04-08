using System;
using System.Collections.Generic;

namespace PakketService.Database.Datamodels.Dtos
{
    public class PackageResponse
    {
        public Guid Id { get; set; }
        public string ReceiverId { get; set; }
        public string TrackAndTraceId { get; set; }
        public string CollectionPointId { get; set; }
        public string Sender { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public bool RouteFinished { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
