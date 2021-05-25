using PakketService.Database.Contexts;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using System;
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
            Ticket ticket = _converter.DtoToModel(request);
            ticket.FinishedAt = DateTimeOffset.Now.ToUnixTimeSeconds();

            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return _converter.ModelToDto(ticket);
        }
    }
}
