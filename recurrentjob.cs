using System;

namespace potatoproducer;

public class recurrentjob : BackgroundService
{
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try {
            while(!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("executing background job 🦛");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
        catch (Exception ex) {
            Console.WriteLine("stopping the backgroung job 🫎");
        }

            
    }
}
