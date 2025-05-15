using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PROG3A_Part2.Repository;
using PROG3A_Part2.Models;
using PROG3A_Part2.Models;
using PROG3A_Part2.Repository;

public class FarmerController : Controller
{
    private readonly IProductRepository _productRepo;
    private readonly IFarmerRepository _farmerRepo;

    public FarmerController(IProductRepository productRepo, IFarmerRepository farmerRepo)
    {
        _productRepo = productRepo;
        _farmerRepo = farmerRepo;
    }

    public IActionResult Login() => View();
//*********************************************************************************************************************
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var farmer = _farmerRepo.GetByCredentials(email, password);
        if (farmer != null)
        {
            HttpContext.Session.SetInt32("FarmerId", farmer.Id);
            HttpContext.Session.SetString("FarmerEmail", farmer.Email);
            return RedirectToAction("MyProducts");
        }

        ViewBag.Error = "Invalid login credentials.";
        return View();
    }
//*********************************************************************************************************************
    public IActionResult MyProducts()
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");
        if (!farmerId.HasValue)
            return RedirectToAction("Login");

        var products = _productRepo.GetProductsByFarmerId(farmerId.Value);
        return View(products);
    }    
//*********************************************************************************************************************
    [HttpGet]
    public IActionResult AddProduct() => View();

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");
        if (!farmerId.HasValue)
            return RedirectToAction("Login");

        product.FarmerId = farmerId.Value;
        _productRepo.AddProduct(product);
        return RedirectToAction("MyProducts");
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
