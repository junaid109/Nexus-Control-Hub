using Microsoft.AspNetCore.Mvc;

namespace NexusControl.Web.Controllers
{
    public class InfrastructureController : Controller
    {
        public IActionResult Index()
        {
            // Mock data for initial visualization
            var model = new ServerStatusViewModel
            {
                Region = "EU-West (Amsterdam)",
                Status = "Online",
                Ping = 24,
                ActiveInstances = 12,
                WebSocketUrl = "https://nexus-hub.azurewebsites.net/dashboardHub",
                ApiKey = "NEXUS_DEV_882910_X"
            };
            return View(model);
        }
    }

    public class ServerStatusViewModel
    {
        public string Region { get; set; }
        public string Status { get; set; }
        public int Ping { get; set; }
        public int ActiveInstances { get; set; }
        public string WebSocketUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
