using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeSeriesController : ControllerBase
{
    private readonly ILogger<TimeSeriesController> _logger;
    private readonly ITimeScaleDbContext _context;
    
    public TimeSeriesController(ILogger<TimeSeriesController> logger, ITimeScaleDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetAllSensors")]
    public async Task<IEnumerable<Sensor>> GetSensors()
    {
        return await _context.GetAllSensors();
    }
}