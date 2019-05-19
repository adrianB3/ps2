using System;
using System.ComponentModel.DataAnnotations;

namespace server.Resources
{
    public class SaveDataResource
    {
        [Required]
        public bool Pump1State { get; set; }
        [Required]
        public bool Pump2State { get; set; }
        [Required]
        public bool Pump3State { get; set; }
        [Required]
        public bool Pump4State { get; set; }
        [Required]
        public bool WaterLevelSensor1State { get; set; }
        [Required]
        public bool WaterLevelSensor2State { get; set; }
        [Required]
        public bool WaterLevelSensor3State { get; set; }
        [Required]
        public bool WaterLevelSensor4State { get; set; }
    }
}