using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CheckInViewModel
    {
        public IList<BarcodeUser> Users { get; set; }
        public BarcodeUser NewUser { get; set; }
        public IList<CheckInTimes> UserCheckInTimes { get; set; }
        public int Barcode { get; set; }
    }
}
