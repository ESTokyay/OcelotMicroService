using Microsoft.EntityFrameworkCore;
using ShopiAPI.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ShopiDbContext : DbContext
    {
        public ShopiDbContext(DbContextOptions<ShopiDbContext> options) : base(options)
        {

        }        

        public DbSet<Order> Order { get; set; }        
    }
}
