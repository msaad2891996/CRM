using CRM.Core.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL
{
    public class CRMDBContext:DbContext
    {
        public CRMDBContext(DbContextOptions options):base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }
    }
}
