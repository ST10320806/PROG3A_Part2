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
    public IActionResult Login(string email, string password)//Action for farmer login
    {
        var farmer = _farmerRepo.GetByCredentials(email, password);//Validate farmer credentials via repository
        if (farmer != null)//Checking if the farmer exists  
        {
            HttpContext.Session.SetInt32("FarmerId", farmer.Id);//storing ID and email in the session
            HttpContext.Session.SetString("FarmerEmail", farmer.Email);
            return RedirectToAction("MyProducts");
        }

        ViewBag.Error = "Invalid login credentials.";//Error handling if farmer doesnt exist
        return View();
    }
//*********************************************************************************************************************
    public IActionResult MyProducts()//Action for displaying all products of the logged in farmer
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");//retrieve previously stored farmer ID
        if (!farmerId.HasValue)//Check that farmer is logged in
            return RedirectToAction("Login");

        var products = _productRepo.GetProductsByFarmerId(farmerId.Value);//retrieve and pass products to the view
        return View(products);
    }    
//*********************************************************************************************************************
    [HttpGet]
    public IActionResult AddProduct() => View();

    [HttpPost]
    public IActionResult AddProduct(Product product)//Action allowing logged in farmer to add a product
    {
        var farmerId = HttpContext.Session.GetInt32("FarmerId");
        if (!farmerId.HasValue)//check that farmer is logged in
            return RedirectToAction("Login");

        product.FarmerId = farmerId.Value;//Assign the logged in farmer's ID to the new product 
        _productRepo.AddProduct(product);//Add product to database via repository
        return RedirectToAction("MyProducts");
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
