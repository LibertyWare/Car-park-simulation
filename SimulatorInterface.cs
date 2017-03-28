using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace CarParkSimulator
{
    public partial class SimulatorInterface : Form
    {
        // Attributes ///        
        private TicketMachine ticketMachine;
        private ActiveTickets activeTickets;
        private TicketValidator ticketValidator;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private FullSign fullSign;
        private CarPark carPark;
        private EntrySensor entrySensor;
        private ExitSensor exitSensor;
        //for images
        private string appPath;
        private string imagesPath;
        /////////////////


        // Constructor //
        public SimulatorInterface()
        {
            InitializeComponent();
        }
        /////////////////


        // Operations ///
        private void ResetSystem(object sender, EventArgs e)
        {
            // STUDENTS:
            ///// Class contructors are not defined so there will be errors
            ///// This code is correct for the basic version though
            activeTickets = new ActiveTickets();
            ticketMachine = new TicketMachine(activeTickets);
            ticketValidator = new TicketValidator(activeTickets);
            entryBarrier = new Barrier();
            exitBarrier = new Barrier();
            fullSign = new FullSign();
            carPark = new CarPark(ticketMachine, ticketValidator, fullSign, entryBarrier, exitBarrier);
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);

            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            /////////////////////////////////////////

            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;


            appPath = AppDomain.CurrentDomain.BaseDirectory;
            imagesPath = Path.GetFullPath(Path.Combine(appPath, @"..\..\carpark pictures"));
            UpdateDisplay();
        }

        private void CarArrivesAtEntrance(object sender, EventArgs e)
        {
            btnCarArrivesAtEntrance.Visible = false;
            btnDriverPressesForTicket.Visible = true;
            entrySensor.CarDetected();
            UpdateDisplay();
        }

        private void DriverPressesForTicket(object sender, EventArgs e)
        {
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = true;
            ticketMachine.PrintTicket();
            UpdateDisplay();
        }

        private void CarEntersCarPark(object sender, EventArgs e)
        {
            bool emptySpaces = false;
            btnCarArrivesAtEntrance.Visible = true;
            btnCarEntersCarPark.Visible = false;
            emptySpaces = entrySensor.CarLeftSensor();
            if (!emptySpaces)
                btnCarArrivesAtEntrance.Visible = false;
            if((btnDriverEntersTicket.Visible == false) && (btnCarExitsCarPark.Visible == false))
                btnCarArrivesAtExit.Visible = true;
            UpdateDisplay();
        }

        private void CarArrivesAtExit(object sender, EventArgs e)
        {
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = true;
            exitSensor.CarDetected();
            UpdateDisplay();
        }

        private void DriverEntersTicket(object sender, EventArgs e)
        {
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = true;
            ticketValidator.TicketEntered();
            UpdateDisplay();

        }

        private void CarExitsCarPark(object sender, EventArgs e)
        {
            bool empty;
            empty = exitSensor.CarLeftSensor();
            btnCarExitsCarPark.Visible = false;
            if (empty)
                btnCarArrivesAtExit.Visible = false;
            else
                btnCarArrivesAtExit.Visible = true;
            btnCarArrivesAtEntrance.Visible = true;
            if (btnCarArrivesAtEntrance.Visible == false)
                btnCarArrivesAtEntrance.Visible = true;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblSpaces.Text = carPark.GetCurrentSpaces().ToString();
            lblFullSign.Text = fullSign.IsLit().ToString();
            //barriers
            if (exitBarrier.IsLifted())
                lblExitBarrier.Text = "Raised";
            else
                lblExitBarrier.Text = "Lowered";
            if (entryBarrier.IsLifted())
                lblEntryBarrier.Text = "Raised";
            else
                lblEntryBarrier.Text = "Lowered";
            //Ticket machine messages
            lblTicketMachine.Text = ticketMachine.GetMessage();
            //Ticket validator messages
            lblTicketValidator.Text = ticketValidator.GetMessage();
            //Ticket list
            lstActiveTickets.Items.Clear();
            List<Ticket> tickets = activeTickets.getTickets();
            List<string> IDs = activeTickets.getIDs();
            int currentTicket = 0;
            foreach (Ticket ticket in tickets)
            {
                string ticketStat = "#" + IDs.ElementAt(currentTicket) + ": " + ticket.IsPaid().ToString();
                lstActiveTickets.Items.Add(ticketStat);
                currentTicket += 1;
            }
            //sensors
            lblEntrySensor.Text = entrySensor.IsCarOnSensor().ToString();
            lblExitSensor.Text = exitSensor.IsCarOnSensor().ToString();
            //Car park image
            int cars = 6-carPark.GetCurrentSpaces();
            string image = "cp" + cars.ToString() + ".png";
            pbxCarPark.Image = Image.FromFile(Path.GetFullPath(Path.Combine(imagesPath, image)));
        }


        ///To Do:
        private void DriverPaysForTicket(object sender, EventArgs e)
        {

        }
    }
}
