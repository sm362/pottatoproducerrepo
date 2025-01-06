using System;

namespace potatoproducer;

public class lifecyclebackgroundjob : IHostedLifecycleService
{
    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[1] before starting the job 🦬");
        return Task.CompletedTask;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[2] initiating the job 🫎");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[3] job started 🐂");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[4] before stopping the job 🦦");
        return Task.CompletedTask;   
   }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[5] stopping the job 🦗");
        return Task.CompletedTask;  
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[6] stopped the job 🦖");
        return Task.CompletedTask;  
        
    }

    
}
