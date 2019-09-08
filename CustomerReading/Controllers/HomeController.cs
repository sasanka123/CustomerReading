using CustomerReading.Bussiness;
using CustomerReading.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerReading.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerRepo customerRepo;

        public HomeController(CustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        #region LoadCustomerData
        public ActionResult Index()
        {
          
            return View();
        }

        [HttpGet]
        public ActionResult Customers()
        {
            List<Customer> custList = customerRepo.GetCustomer();
            return View(custList);
        }
        #endregion

        #region ViewCustomerData
        [HttpGet]
        public ActionResult Details(string id)
        {
            Customer customer = customerRepo.GetCustomer(id);
            return View(customer);
        }
        #endregion

        #region CreateCustomerData
        [HttpGet]
        public ActionResult Create(string id)
        {
            Customer customer = new Customer();
            if (!String.IsNullOrEmpty(id))
                customer = customerRepo.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                int id = customerRepo.CreateCustomer(customer);
                return RedirectToAction("Customers", "Home");
            }
            return View(customer);
        }
        #endregion

        #region DeleteCustomer
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            int result = customerRepo.DeleteCustomer(customer.Id.ToString());
            return RedirectToAction("Customers", "Home");
        }
        #endregion

        #region Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        #endregion

    }
}