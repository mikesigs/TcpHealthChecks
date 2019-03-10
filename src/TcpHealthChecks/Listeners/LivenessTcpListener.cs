﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TcpHealthChecks.Core;

namespace TcpHealthChecks.Listeners
{
    public class LivenessTcpListener : HealthCheckTcpListener
    {
        public LivenessTcpListener(IConfiguration config, ILogger<LivenessTcpListener> logger, IServiceScopeFactory serviceScopeFactory)
            : base(
                HealthCheckKind.Liveness, 
                config.GetValue<int?>("HealthChecks:Liveness:Port") ?? 13000, 
                config.GetValue<int?>("HealthChecks:Liveness:Frequency") ?? 5,
                logger,
                serviceScopeFactory) {}
    }
}