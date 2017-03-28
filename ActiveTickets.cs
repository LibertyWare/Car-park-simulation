using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ActiveTickets
    {
        List<Ticket> tickets = new List<Ticket>();
        List<string> IDs = new List<string>();
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
            IDs.Add(ticket.GetHashCode().ToString("D8"));
        }
        public void RemoveTicket()
        {
            tickets.RemoveAt(0);
            IDs.RemoveAt(0);
        }
        public List<Ticket> getTickets()
        {
            return tickets;
        }
        public List<string> getIDs()
        {
            return IDs;
        }
    }
}
