using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class CarPark
    {
        TicketMachine ticketMachine;
        TicketValidator ticketValidator;
        FullSign fullSign; 
        Barrier entryBarrier;
        Barrier exitBarrier;
        private int currentSpaces;
        private int maxSpace = 6;
        public CarPark(TicketMachine TMachine, TicketValidator TValidator, FullSign Fsign, Barrier entryBarrier, Barrier exitBarrier)
        {
            this.ticketMachine = TMachine;
            this.ticketValidator = TValidator;
            this.fullSign = Fsign;
            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;
            currentSpaces = maxSpace;
        }
        public void CarArrivedAtEntrance()
        {
            ticketMachine.CarArrived();
        }
        public void TicketDispensed()
        {
            entryBarrier.Raise();
        }
        public void CarEnteredCarPark()
        {
            currentSpaces -= 1;
            entryBarrier.Lower();
            ticketMachine.ClearMessage();
            if (IsFull())
                fullSign.SetLit(true);
        }
        public void CarArrivedAtExit()
        {
            ticketValidator.CarArrived();
        }
        public void TicketValidated()
        {
            exitBarrier.Raise();
        }
        public void CarExitedCarPark()
        {
            currentSpaces += 1;
            exitBarrier.Lower();
            if (fullSign.IsLit())
                fullSign.SetLit(false);
            ticketValidator.ClearMessage();
        }
        public bool IsFull()
        {
            bool isFull = false;
            if (currentSpaces == 0)
                isFull = true;
            return isFull;
        }
        public bool IsEmpty()
        {
            bool isEmpty = false;
            if (currentSpaces == maxSpace)
                isEmpty = true;
            return isEmpty;
        }
        public bool HasSpace()
        {
            bool space = true;

            return space;
        }
        public int GetCurrentSpaces()
        {
            return currentSpaces;
        }
    }
}
