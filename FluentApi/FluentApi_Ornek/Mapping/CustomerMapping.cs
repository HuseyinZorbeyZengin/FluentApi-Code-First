using FluentApi_Ornek.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi_Ornek.Mapping
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            ToTable("Musteri");
            HasKey(c => c.ID);
            Ignore(c => c.FullName);

            Property(c => c.FirstName).IsRequired().HasColumnName("Ad").HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.LastName).IsRequired().HasColumnName("Soyad").HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.TC).HasMaxLength(11).HasColumnType("char").HasColumnName("T.C Numarası").IsRequired();

            //İlişkiler

            HasMany(c => c.Contacts).WithRequired(c => c.Customer).HasForeignKey(c => c.CustomerID).WillCascadeOnDelete(false);

            HasMany(c => c.Courses).WithMany(c => c.Customers).Map(cc =>
            {
                cc.ToTable("KursKursiyer_Islem");
                cc.MapLeftKey("KursiyerID");
                cc.MapRightKey("KursID");

            });
        }
    }
}
