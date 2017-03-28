using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketValidator
    {
        CarPark carpark;
        ActiveTickets activetickets;
        private string message;
        public TicketValidator(ActiveTickets tickets)
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
            message = "Please insert your ticket.";
        }
        public void TicketEntered()
        {
            message = "Thank you, drive safely.";
            activetickets.RemoveTicket();
            carpark.TicketValidated();
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
