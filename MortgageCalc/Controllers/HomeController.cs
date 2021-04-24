using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MortgageCalc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MortgageCalc.LoanHelpers;
using static MortgageCalc.Models.LoanPayment;


namespace MortgageCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        //GET ACTION
        public IActionResult App()
        {
            var model = new Loan();

            return View(model);

        }

        //post Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult App(Loan loan)
        {
            var loanHelper = new LoanUtilities(loan);

            var model = loanHelper.CreateSchedule();

            return View(model);
           
        }

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
