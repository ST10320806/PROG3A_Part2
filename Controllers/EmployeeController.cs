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
    public IActionResult Login(string email, string password)
    {
        var employee = _employeeRepo.GetByCredentials(email, password);
        if (employee != null)
        {
            HttpContext.Session.SetInt32("EmployeeId", employee.Id);
            return RedirectToAction("FarmerList");
        }

        ViewBag.Error = "Invalid login credentials.";
        return View();
    }
//*********************************************************************************************************************

    public IActionResult AddFarmer() => View();

    [HttpPost]
    public IActionResult AddFarmer(Farmer farmer)
    {
        _farmerRepo.Add(farmer);
        return RedirectToAction("FarmerList");
    }
//*********************************************************************************************************************

    public IActionResult FarmerList()
    {
        var farmers = _farmerRepo.GetAll();
        return View(farmers);
    }
//*********************************************************************************************************************

    public IActionResult FilterProducts(string category, DateTime? startDate, DateTime? endDate)
    {
        var products = _productRepo.FilterProducts(category, startDate, endDate);
        return View(products);
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
