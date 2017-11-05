using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.IntegrationEvents;
using TrainingManagement.IntegrationEvents.Events;
using TrainingManagementSystem.EventBus.Abstractions;

namespace TrainingManagement.Controllers
{
    [Route("TrainingManagement/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingSessionIntegrationEventService _trainingSessionIntegrationEventService;

        public TrainingController(ITrainingSessionIntegrationEventService trainingSessionIntegrationEventService)
        {
            _trainingSessionIntegrationEventService = trainingSessionIntegrationEventService;      
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Training Session 1", "Training Session 2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Training Session 1";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var trainingSessionChangedEvent = new TrainingSessionChangedIntegrationEvent(1, "Session 1", 12);

            _trainingSessionIntegrationEventService.PublishThroughEventBusAsync(trainingSessionChangedEvent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
