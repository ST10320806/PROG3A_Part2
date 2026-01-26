using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PROG3A_Part2.Repository;
using PROG3A_Part2.Models;
using PROG3A_Part2.Models;
using PROG3A_Part2.Repository;

public class EmployeeController : Controller
{
    private readonly IFarmerRepository _farmerRepo;
    private readonly IEmployeeRepository _employeeRepo;
    private readonly IProductRepository _productRepo;

    public EmployeeController(IFarmerRepository farmerRepo, IEmployeeRepository employeeRepo, IProductRepository productRepo)
    {
        _farmerRepo = farmerRepo;
        _employeeRepo = employeeRepo;
        _productRepo = productRepo;
    }
//*********************************************************************************************************************
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)//Method for the login of employees
    {
        var employee = _employeeRepo.GetByCredentials(email, password);//Calling credentials from the repository
        if (employee != null)
        {
            HttpContext.Session.SetInt32("EmployeeId", employee.Id);
            return RedirectToAction("FarmerList");
        }

        ViewBag.Error = "Invalid login credentials.";// Error message for invalid login 
        return View();
    }
//*********************************************************************************************************************

    public IActionResult AddFarmer() => View();

    [HttpPost]
    public IActionResult AddFarmer(Farmer farmer)//Method for adding a farmer to the database
    {
        _farmerRepo.Add(farmer);
        return RedirectToAction("FarmerList");
    }
//*********************************************************************************************************************

    public IActionResult FarmerList()//Method for displaying the list of farmers
    {
        var farmers = _farmerRepo.GetAll();//Getting all farmers from the database via the repository
        return View(farmers);
    }
//*********************************************************************************************************************

    public IActionResult FilterProducts(string category, DateTime? productionDate)//Action for the filtering of products
    {
        var products = _productRepo.FilterProducts(category, productionDate);//Call repo to filter based off category and production date
        return View(products);
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
