using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Voyage.Domain.Enums;

namespace Voyage.Domain.Models
{
    public class AvailableTicket
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(City))]
        public int? StartLocationCityId { get; set; }

        [NotMapped]
        public City StartLocationCity { get; set; }

        [ForeignKey(nameof(City))]
        public int? EndLocationCityId { get; set; }
        
        [NotMapped]
        public City EndLocationCity { get; set; }

        public DateOnly TicketDate { get; set; }
        public TimeOnly TicketTime { get; set; }

        public EnTravelMeans TravelMeans { get; set; }

        public float Rating { get; set; }
        public float Price { get; set; }
    }
}
