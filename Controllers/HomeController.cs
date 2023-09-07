using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System.Security.Cryptography.X509Certificates;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        SimpleRepository Repository = SimpleRepository.SharedRepository;
        public IActionResult Index()
            => View(SimpleRepository.SharedRepository.Products.Where(p => p?.Price < 50));
        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}
