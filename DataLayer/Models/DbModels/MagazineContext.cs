using DataLayer.Models;
using DataLayer.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DbModels
{
    public class MagazineContext:DbContext
    {
        public  DbSet<Order> Orders { get; set; }
        public  DbSet<Product> Products { get; set; }
        public MagazineContext(DbContextOptions<MagazineContext> options):base(options)
        {

        }
        
    }
}
