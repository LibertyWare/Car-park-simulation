using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class EntrySensor : Sensor
    {
        CarPark carpark;
        public EntrySensor(CarPark cp)
        {
            this.carpark = cp;
        }
        public override void CarDetected()
        {
            base.CarDetected();
            carpark.CarArrivedAtEntrance();
        }
        public override bool CarLeftSensor()
        {
            carOnSensor = false;
            carpark.CarEnteredCarPark();
            if (carpark.IsFull())
                return false;
            else
                return true;
        }
    }
}