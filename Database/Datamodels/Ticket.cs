using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Database.Datamodels
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public string ToDoLocationId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double CreatedAt { get; set; }
        public string CreatedByPCN { get; set; }
        public double FinishedAt { get; set; }
        public string FinishedByPCN { get; set; }
        public bool IsFinished { get; set; }
        public string NextTicketId { get; set; }
        public TicketAction TicketAction { get; set; }
    }
}
