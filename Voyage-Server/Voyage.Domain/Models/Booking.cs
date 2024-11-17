using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Voyage.Domain.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [NotMapped]
        public User User { get; set; }

        [ForeignKey(nameof(Ticket))]
        public int TicketId { get; set; }

        [NotMapped]
        public AvailableTicket Ticket { get; set; }
    }
}
