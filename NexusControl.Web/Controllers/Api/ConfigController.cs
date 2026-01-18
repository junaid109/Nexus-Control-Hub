using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusControl.Infrastructure.Data;

namespace NexusControl.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConfigController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/config
        // Used by Unity Client to poll for active features
        [HttpGet]
        public async Task<IActionResult> GetConfig([FromQuery] string clientVersion)
        {
            var flags = await _context.FeatureFlags
                .Where(f => f.IsEnabled)
                .Select(f => new 
                { 
                    f.Key, 
                    f.RulesJson 
                })
                .ToListAsync();

            // FUTURE: Implement complex rule evaluation logic here based on clientVersion
            
            return Ok(new 
            { 
                generatedAt = DateTime.UtcNow,
                features = flags.ToDictionary(k => k.Key, v => v.RulesJson)
            });
        }
    }
}
