using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class TimeScaleDbContextInitializer
{
    private readonly ILogger<TimeScaleDbContextInitializer> _logger;
    private readonly TimeScaleDbContext _context;


    public TimeScaleDbContextInitializer(ILogger<TimeScaleDbContextInitializer> logger, TimeScaleDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task Initialize()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
                await SetUpTimeScale(1, new TimeSpan(1, 0, 0, 0));
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while initialising the database.");
            throw;
        }
    }

    private async Task SetUpTimeScale(int nPartitions, TimeSpan timeSpan)
    {
        long test = (long)timeSpan.TotalMicroseconds;
        string sql = @$"SELECT create_hypertable('""{_context.SchemaName}"".""Measurements""', 'Time', 'Id', 
               number_partitions => {nPartitions}, chunk_time_interval => {test}, 
               if_not_exists => TRUE);";
        
        await _context.Database.ExecuteSqlRawAsync(sql);

        // string index =
        //     @$"CREATE INDEX ON ""{_context.SchemaName}"".""Measurements""(""Id"", ""Time"" DESC) WITH (timescaledb.transaction_per_chunk);";
        // await _context.Database.ExecuteSqlRawAsync(index);
    }
}