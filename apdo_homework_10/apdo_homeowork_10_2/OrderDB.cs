using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apdo_homeowork_10_2
{
    public class OrderDB : DbContext
    {
        public OrderDB() : base("OrderDataBase")
        {
        }
        public DbSet<Order> Order { get; set; }
    }
}
