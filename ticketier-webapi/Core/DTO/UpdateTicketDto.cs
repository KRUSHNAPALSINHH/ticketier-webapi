namespace ticketier_webapi.Core.DTO
{
    public class UpdateTicketDto
    {
        public DateTime Time { get; set; }
        public string PassengerName { get; set; }
        public long PassenegerSSN { get; set; }
        //public string From { get; set; }
        //public string To { get; set; }
        public int Price { get; set; }
        public string ConfidentialComment { get; set; } = "Normal";

    }
}
