using PakketService.Database.Contexts;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using PakketService.helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Services
{
    public class TicketService : ITicketService
    {
        private readonly PackageServiceContext _context;
        private readonly IDtoConverter<Ticket, TicketRequest, TicketResponse> _converter;

        public TicketService(PackageServiceContext context, IDtoConverter<Ticket, TicketRequest, TicketResponse> converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<TicketResponse> AddAsync(TicketRequest request)
        {
            if (!_context.Package.Any(p => p.Id == request.PackageId))
            {
                throw new NotFoundException($"Package with id {request.PackageId} not found.");
            }

            Ticket ticket = _converter.DtoToModel(request);
            ticket.FinishedAt = DateTimeOffset.Now.ToUnixTimeSeconds();

            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return _converter.ModelToDto(ticket);
        }
    }
}
