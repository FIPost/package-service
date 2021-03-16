﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Database.Datamodels
{
    public class Package
    {
        [Key]
        public Guid Id { get; set; }
        public string ReceiverId { get; set; }
        public string TrackAndTraceId { get; set; }
        public string CollectionPointId { get; set; }
        public string Sender { get; set; }
        public string Name { get; set; }
        public Status status { get; set; }
        public bool RouteFinished { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
