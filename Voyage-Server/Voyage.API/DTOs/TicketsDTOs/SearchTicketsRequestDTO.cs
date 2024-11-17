namespace Voyage.API.DTOs.TicketsDTOs
{
    public class SearchTicketsRequestDTO
    {
        public string StartLocationCity { get; set; }
        public string EndLocationCity { get; set; }
        public DateOnly OutboundTicketDate { get; set; }

        /// <summary>
        /// Default = Empty
        /// </summary>
        public DateOnly InboundTicketDate { get; set; }

        /// <summary>
        /// Default = False
        /// </summary>
        public bool IsTwoWay { get; set; }

        /// <summary>
        /// Bus or Air
        /// </summary>
        public int TravelMeans { get; set; }
    }
}
