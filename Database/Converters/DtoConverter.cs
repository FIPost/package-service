using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using System.Collections.Generic;

namespace PakketService.Database.Converters
{
    public class DtoConverter: IDtoConverter<Package, PackageRequest, PackageResponse>
    {
        public Package DtoToModel(PackageRequest dto)
        {
            return new Package
            {
                Sender = dto.Sender,
                ReceiverId = dto.ReceiverId,
                Name = dto.Name,
                CollectionPointId = dto.CollectionPointId
            };
        }

        public PackageResponse ModelToDto(Package package)
        {
            return new PackageResponse
            {
                Id = package.Id,
                ReceiverId = package.ReceiverId,
                TrackAndTraceId = package.TrackAndTraceId,
                CollectionPointId = package.CollectionPointId,
                Sender = package.Sender,
                Name = package.Name,
                Status = package.Status,
                RouteFinished = package.RouteFinished,
                Tickets = package.Tickets
            };
        }

        public List<PackageResponse> ModelToDto(List<Package> packages)
        {
            List<PackageResponse> responseDtos = new();

            foreach (Package pkg in packages)
            {
                responseDtos.Add(ModelToDto(pkg));
            }

            return responseDtos;
        }
    }
}
