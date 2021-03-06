﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TcpHealthChecks.Extensions;

namespace SimpleExampleWithDefaults
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config
                        .SetBasePath(Environment.CurrentDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) => { services.AddTcpHealthChecks(); })
                .ConfigureLogging((context, logging) =>
                {
                    logging
                        .SetMinimumLevel(LogLevel.Debug)
                        .AddConsole();
                });

            await builder.RunConsoleAsync();
        }
    }
}