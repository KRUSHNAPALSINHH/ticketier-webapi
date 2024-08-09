using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketier_webapi.Core.Context;
using ticketier_webapi.Core.DTO;
using ticketier_webapi.Core.Entities;

namespace ticketier_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TicketsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                         
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTicket([FromBody]CreateTicketDto createTicketDto)
        {
            var newTicket = new Ticket();
            _mapper.Map(createTicketDto,newTicket);
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
            return Ok("Ticket Saved Successfully");
            

        }
        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            var convertedTickets= _mapper.Map<IEnumerable<GetTicketDto>>(tickets);
           
         return Ok(convertedTickets);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTicketById([FromRoute]long id)
        {
           var ticket=await _context.Tickets.FirstOrDefaultAsync(t=>t.Id==id);
            if (ticket == null)
            {
                return NotFound("Ticket not found");

            }
            var convetedTicket=_mapper.Map<GetTicketDto>(ticket);
            return Ok(convetedTicket);

        }
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditTickets([FromRoute]long id,[FromBody]UpdateTicketDto updateTicketDto)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound("Ticket not found");

            }
            _mapper.Map(updateTicketDto, ticket);
            ticket.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok("Ticket updated successfully");

        }
        [HttpDelete]
        [Route("Delete/{id}")]
         public async Task<IActionResult> DeleteTask([FromRoute]long id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound("Ticket not found");

            }
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return Ok("Ticket deleted successfully");

        }

        
        }
}
