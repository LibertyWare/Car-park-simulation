using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ExitSensor : Sensor
    {
        CarPark carpark;
        public ExitSensor(CarPark cp)
        {
            this.carpark = cp;
        }
        public override void CarDetected()
        {
            base.CarDetected();
            carpark.CarArrivedAtExit();
        }
        public override bool CarLeftSensor()
        {
            carpark.CarExitedCarPark();
            if (carpark.IsEmpty())
                return true;
            else
                return false;
        }
    }
}
