using FluentApi_Ornek.Mapping;
using FluentApi_Ornek.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi_Ornek.Context
{
    public class CRMContext : DbContext
    {
        public CRMContext()
        {
            Database.Connection.ConnectionString = @"server=DESKTOP-U6M907R\SQLEXPRESS; Database=CRMDatabase; uid=sa; pwd=123;";
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FluentApi
            modelBuilder.Configurations.Add(new ContactMapping());
            modelBuilder.Configurations.Add(new CustomerMapping());
            modelBuilder.Configurations.Add(new CourseMapping());

            //Silmiyoruz en altta kalıyor.
            base.OnModelCreating(modelBuilder);
        }
    }
}
