using DemoApp.Data;
using DemoApp.DTOs;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly ApiDbContext _context;

    public DriversController(ILogger<DriversController> logger, ApiDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetAllDrivers")]
    public async Task<IActionResult> GetAllDrivers()
    {
        var allDrivers = await _context.Drivers.ToListAsync();
        return Ok(allDrivers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver(CreateDriverRequest request)
    {
        _context.Add(request);
        await _context.SaveChangesAsync();
        return Ok();
    }
}