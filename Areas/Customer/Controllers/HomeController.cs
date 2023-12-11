using Microsoft.AspNetCore.Mvc;
using ShopApp.DataAccess.Repository.IRepository;
using ShopApp.Models;
using System.Diagnostics;

namespace ShopApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category");
            return View(productList);
        }

        public IActionResult Details(int productid)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productid, includeProperties: "Category"),
                Count = 1,
                ProductId = productid
            };
           
            return View(cart);
        }
        //[HttpPost]
        //public IActionResult Details(ShoppingCart shoppingCart)
        //{
        //    ShoppingCart cart = new()
        //    {
        //        Product = _unitOfWork.Product.Get(u => u.Id == productid, includeProperties: "Category"),
        //        Count = 1,
        //        ProductId = productid
        //    };

        //    return View(cart);
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
