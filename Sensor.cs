using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    abstract class Sensor
    {
        protected bool carOnSensor;
        public virtual void CarDetected(){
            carOnSensor = true;
        }
        public virtual bool CarLeftSensor()
        {
            carOnSensor = false;
            return false;
        }
        public bool IsCarOnSensor()
        {
            return carOnSensor;
        }
    }
}
