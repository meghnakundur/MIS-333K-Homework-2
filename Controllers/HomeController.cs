//Name: Meghna Kundur
//Date: 9/24/2022
//Description: HW2 – Bookstore Checkout

using Microsoft.AspNetCore.Mvc;
using Kundur_Meghna_HW2.Models;

namespace Kundur_Meghna_HW2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckoutDirect()
        {
            return View();
        }

        public IActionResult DirectTotals(DirectOrder directOrder)
        {
            //validating the object against data annotations
            TryValidateModel(directOrder);
            //If the object is not valid we will it send back to our view
            if (ModelState.IsValid == false)
            {
                return View("CheckoutDirect", directOrder);
            }
            //If the object is valid, let's set the type, calculate totals, and display the view
            directOrder.CustomerType = CustomerType.Direct;
            try
            {
                directOrder.CalcTotals();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("CheckoutDirect", directOrder);
            }

           
            return View("DirectTotals", directOrder);
        }

        public IActionResult CheckoutWholesale()
        {
            return View();
        }

        public IActionResult WholesaleTotals(WholesaleOrder wholesaleOrder)
        {
            //validate object against data annotations
            TryValidateModel(wholesaleOrder);
            //if not valid, send back to view
            if (ModelState.IsValid == false)
            {
                return View("CheckoutWholesale", wholesaleOrder);
            }
            //if valid, set type, calc totals and display view
            wholesaleOrder.CustomerType = CustomerType.Wholesale;
            try
            {
                wholesaleOrder.CalcTotals();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("CheckoutWholesale", wholesaleOrder);
            }

           
            return View("WholesaleTotals", wholesaleOrder);
        }
    }
}
