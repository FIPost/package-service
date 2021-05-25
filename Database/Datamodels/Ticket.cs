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
        public Guid ActionLocation{ get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double FinishedAt { get; set; }
        public string ActionCompletedBy { get; set; }
        public Guid PackageId { get; set; }
    }
}
