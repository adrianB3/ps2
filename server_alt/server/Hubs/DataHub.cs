using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Hubs
{
    public interface IDataHub
    {
        Task StateChange(
            Guid Id,
            DateTime TimeStamp,
            bool Pump1State,
            bool Pump2State,
            bool Pump3State,
            bool Pump4State,
            bool WaterLevelSensor1State,
            bool WaterLevelSensor2State,
            bool WaterLevelSensor3State,
            bool WaterLevelSensor4State
            );
    }
    public class DataHub: Hub<IDataHub>
    {
        
    }
}