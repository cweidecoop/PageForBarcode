using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class UploadDataBaseLogic
    {
        private BarCodeDbContext _context;

        public UploadDataBaseLogic(BarCodeDbContext dbContext)
        {
            _context = dbContext;
        }

        public void UpdateDataBase()
        {
            using (var reader = new StreamReader(@"C:\Users\IT\source\repos\WebApplication1\WebApplication1\CSV\ID CARD MASTER LIST 2013-14.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    BarcodeUser newUser = new BarcodeUser()
                    {
                        Barcode = int.Parse(values[3]),
                        Name = values[0] + " " + values[1],
                        CheckedIn = false

                    };

                    _context.BarcodeUsers.Add(newUser);
                }
                _context.SaveChanges();
            }
        }

        public void CheckIn(int barcode, DateTime dateTime)
        {
            BarcodeUser user = _context.BarcodeUsers.Where(b => b.Barcode == barcode).FirstOrDefault();
            if (user != null)
            {
                CheckInTimes newTime = new CheckInTimes()
                {
                    Name = user.Name,
                    Barcode = user.Barcode,
                    CheckInTime = dateTime
                };
                _context.CheckInTimes.Add(newTime);
            }

            _context.SaveChanges();
        }

        public void Reset()
        {
            foreach (var user in _context.BarcodeUsers)
            {
                user.CheckedIn = false;
            }

            foreach (var time in _context.CheckInTimes)
            {
                _context.CheckInTimes.Remove(time);
            }
            _context.SaveChanges();
        }
    }
}
