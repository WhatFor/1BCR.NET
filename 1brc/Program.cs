using brc.Attempts;
using System.Diagnostics;
using brc.Infrastructure;

// Which attempts to run
string[] enabled = ["1"];

var solvers = new Dictionary<string, IAttempt>
{
    { "1", new Attempt01(new BrcOptions($@"C:\\1brc\measurements.txt", false)) },
};

var timings = new Dictionary<string, long>();

foreach (var (attemptNumber, attempt) in solvers)
{
    if (enabled.Contains(attemptNumber))
    {
        var sw = Stopwatch.StartNew();
        await attempt.Solve();
        sw.Stop();
        timings.Add(attemptNumber, sw.ElapsedMilliseconds);
    }
}

Console.WriteLine("\n\n");
foreach (var (attemptNumber, time) in timings)
    Console.WriteLine($"Attempt {attemptNumber} total: {time}ms");