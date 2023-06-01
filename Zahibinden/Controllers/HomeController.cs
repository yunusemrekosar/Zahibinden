using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zahibinden.Models;
using Zahibinden.Services.StorageAbs;

namespace Zahibinden.Controllers
{
    public class HomeController : Controller
    {
        readonly IStorage _storage;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }
        public IActionResult MyAddverts()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Image(IFormFileCollection files )
        {
            await _storage.UploadAsync("deneme", files);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}