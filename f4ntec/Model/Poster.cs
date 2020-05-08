using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f4ntec.Model
{
    public class Spectacle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableTickets { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public class SpectacleDto
    {
        public string Name { get; set; }
        public int AvailableTickets { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Duration { get; set; }
    }

    public class TicketBalance
    {
        public Spectacle Spectacle { get; set; }
        public int Balance { get; set; }
    }

    public class TicketUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BookingTicket
    {
        public int SpectacleId { get; set; }
        public int TicketUserId { get; set; }
        public int ReservedTickets { get; set; }
    }
}
