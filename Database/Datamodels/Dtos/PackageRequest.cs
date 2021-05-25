using System;
using System.ComponentModel.DataAnnotations;

namespace PakketService.Database.Datamodels.Dtos
{
    public class PackageRequest
    {
        [Required]
        public string Sender { get; set; }
        [Required]
        public string ReceiverId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CollectionPointId { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
