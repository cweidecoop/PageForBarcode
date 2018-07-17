﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class BarCodeDbContext : DbContext
    {
        public DbSet<BarcodeUser> BarcodeUsers { get; set; }
        public DbSet<CheckInTimes> CheckInTimes { get; set; }

        public BarCodeDbContext(DbContextOptions<BarCodeDbContext> options) : base(options)
        {

        }
    }
}
