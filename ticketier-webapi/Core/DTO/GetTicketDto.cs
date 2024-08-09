using System.ComponentModel.DataAnnotations;

namespace ticketier_webapi.Core.DTO
{
    public class GetTicketDto
    {
        [Key]
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public string PassengerName { get; set; }
        public long PassenegerSSN { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        
    }
}
