using System;
using System.Collections.Generic;

namespace server.Models
{
    public class Data
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Pump1State { get; set; }
        public bool Pump2State { get; set; }
        public bool Pump3State { get; set; }
        public bool Pump4State { get; set; }
        public bool WaterLevelSensor1State { get; set; }
        public bool WaterLevelSensor2State { get; set; }
        public bool WaterLevelSensor3State { get; set; }
        public bool WaterLevelSensor4State { get; set; }
    }
}