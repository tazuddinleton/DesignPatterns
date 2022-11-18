using Serilog;
internal class Program
{
    private static void Main(string[] args)
    {
        using var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Logger = log;
        
        log.Information("Hello World!");
    }

}