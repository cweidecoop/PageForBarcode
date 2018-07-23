using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private BarCodeDbContext _context;

        public HomeController(BarCodeDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        //MainFunctionToCheckIn
        public IActionResult CheckIn()
        {
            IEnumerable<BarcodeUser> userNames = _context.BarcodeUsers.OrderBy(c => c.Name).ToList();
          
            return View(new CheckInViewModel(userNames));
        }

        [HttpPost]
        public IActionResult CheckIn(int barcode)
        {
            var date = DateTime.Now;
            var dateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0).AddHours(-5);

            var uploadDataBaseLogic = new UploadDataBaseLogic(_context);
            List<BarcodeUser> users = _context.BarcodeUsers.Where(i => i.CheckedIn == true).ToList();
            BarcodeUser newUser = _context.BarcodeUsers.Where(i => i.Barcode == barcode).FirstOrDefault();
            List<CheckInTimes> times = _context.CheckInTimes.OrderByDescending(i => i.Barcode).ToList();
            IEnumerable<BarcodeUser> userNames = _context.BarcodeUsers.OrderBy(c => c.Name).ToList();

            ViewBag.Error = "";

            

            if (newUser == null)
            {
                ViewBag.Error = "Barcode not found";
               
                return View(new CheckInViewModel(userNames));
            }
            if (newUser != null)
            {
                CheckInViewModel checkInViewModel = new CheckInViewModel(userNames)
                {
                    Users = users,
                    NewUser = newUser,
                    UserCheckInTimes = times,

                };
                uploadDataBaseLogic.CheckIn(barcode, dateTime);
                return View(checkInViewModel);
            }

            return View();


        }


        public IActionResult Reset()
        {
            var uploadDataBaseLogic = new UploadDataBaseLogic(_context);
            uploadDataBaseLogic.Reset();
            return Redirect("/Home");
        }

        public IActionResult UploadCSV()
        {
            var uploadDataBaseLogic = new UploadDataBaseLogic(_context);
            uploadDataBaseLogic.UpdateDataBase();
            return Redirect("/Home");
        }
    }
}
