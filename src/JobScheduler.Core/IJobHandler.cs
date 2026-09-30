namespace JobScheduler.Core;

public interface IJobHandler
{
   string Type { get; }
   Task HandleAsync(Job job, CancellationToken ct);
}