using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CheckInViewModel
    {
        public BarcodeUser NewUser { get; set; }
        public IList<CheckInTimes> UserCheckInTimes { get; set; }
        public int Barcode { get; set; }

        public IList<BarcodeUser> Users { get; set; }
        public BarcodeUser UserName { get; set; }
        public List<SelectListItem> UserNames { get; set; }

        public CheckInViewModel() { }

        public CheckInViewModel(IEnumerable<BarcodeUser> userNames)
        {
            UserNames = new List<SelectListItem>();

            foreach (var user in userNames)
            {
                UserNames.Add(new SelectListItem
                {
                    Value = ((int)user.ID).ToString(),
                    Text = user.Name.ToString() + " " + " - " + user.Barcode
                });
            }
        
        }

       

    }
}
