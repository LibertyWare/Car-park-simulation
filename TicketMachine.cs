using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketMachine
    {
        CarPark carpark;
        ActiveTickets activetickets;
        private string message;
        public TicketMachine(ActiveTickets tickets)
        {
            this.activetickets = tickets;
            message = "";
        }
        public void AssignCarPark(CarPark cp)
        {
            this.carpark = cp;
        }
        public void CarArrived()
        {
            message = "Please press to get a ticket.";
        }
        public void PrintTicket()
        {
            message = "Thank you, enjoy your stay.";
            activetickets.AddTicket(new Ticket());
            carpark.TicketDispensed();
        }
        public void ClearMessage()
        {
            message = "";
        }
        public string GetMessage()
        {
            return message;
        }
    }
}
