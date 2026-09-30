namespace JobScheduler.Core;

public static class BackoffCalculator
{
    /// attempt is 1-based: delay = base * 2^(attempt-1), capped at max.
    public static TimeSpan Calculate(int attempt, TimeSpan baseDelay, TimeSpan maxDelay)
    {
        if (attempt < 1) throw new ArgumentOutOfRangeException(nameof(attempt));

        var ms = baseDelay.TotalMilliseconds * Math.Pow(2, attempt - 1);
        return TimeSpan.FromMilliseconds(Math.Min(ms, maxDelay.TotalMilliseconds));
    }
}