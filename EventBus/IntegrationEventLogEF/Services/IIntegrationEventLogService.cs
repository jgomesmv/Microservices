﻿using TrainingManagementSystem.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingManagementSystem.IntegrationEventLogEF.Services
{
    public interface IIntegrationEventLogService
    {
        Task SaveEventAsync(IntegrationEvent @event, DbTransaction transaction);
        Task MarkEventAsPublishedAsync(IntegrationEvent @event);
    }
}
