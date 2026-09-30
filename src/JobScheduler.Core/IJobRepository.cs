namespace JobScheduler.Core;

public interface IJobRepository
{
    Task<Guid> EnqueueAsync(string type, string payloadJson, DateTime? runAt = null,
        int maxAttempts = 5, string? cron = null, CancellationToken ct = default);

    Task<Job?> GetAsync(Guid id, CancellationToken ct = default);

    Task<Job?> ClaimNextAsync(string workerId, TimeSpan lease, CancellationToken ct = default);

    Task CompleteAsync(Guid id, string workerId, CancellationToken ct = default);
    Task ScheduleRetryAsync(Guid id, string workerId, string error, DateTime runAt, CancellationToken ct = default);
    Task MarkDeadAsync(Guid id, string workerId, string error, CancellationToken ct = default);
    
    
    Task<int> RecoverExpiredLeasesAsync(CancellationToken ct = default);
}