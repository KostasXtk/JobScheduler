namespace JobScheduler.Core;

public class Job
{
   public Guid Id { get; init; }
   public string Type { get; init; } = "";
   public string Payload { get; init; }
   public JobStatus Status { get; init; }
   public DateTime RunAt { get; init; }
   public int Attempts { get; init; }
   public int MaxAttempts { get; init; }
   public DateTime? LockedUntil { get; init; }
   public string? LockedBy { get; init; }
   public string? LastError { get; init; }
   public string? Cron { get; init; }
   public DateTime CreatedAt { get; init; }
   public DateTime UpdatedAt { get; init; }
   
   public bool HasRetriesLeft => Attempts < MaxAttempts;
}