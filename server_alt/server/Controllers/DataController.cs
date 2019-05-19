using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using server.Models;
using server.Services;
using server.Extensions;
using server.Hubs;
using server.Resources;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IHubContext<DataHub, IDataHub> _hubContext;

        public DataController(IDataService dataService, IMapper mapper, IHubContext<DataHub, IDataHub> dataHub)
        {
            _dataService = dataService;
            _mapper = mapper;
            _hubContext = dataHub;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DataResource>> GetAllAsync()
        {
            var data = await _dataService.ListAsync();
            var res = _mapper.Map<IEnumerable<Data>, IEnumerable<DataResource>>(data);
            
            return res;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDataResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var data = _mapper.Map<SaveDataResource, Data>(resource);
            var result = await _dataService.SaveAsync(data);
            
            if (!result.Success)
                return BadRequest(result.Message);

            await _hubContext.Clients.All.StateChange(
                data.Id,
                data.TimeStamp,
                data.Pump1State, data.Pump2State, data.Pump3State, data.Pump4State,
                data.WaterLevelSensor1State, data.WaterLevelSensor2State, data.WaterLevelSensor3State, data.WaterLevelSensor4State
                );

            var dataRes = _mapper.Map<Data, DataResource>(result.Data);
            return Ok(dataRes);
        }
        
    }
}