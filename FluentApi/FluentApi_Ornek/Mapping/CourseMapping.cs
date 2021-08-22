using FluentApi_Ornek.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi_Ornek.Mapping
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            ToTable("Kurs");
            HasKey(x => x.ID);

            Property(x => x.Name).IsRequired().HasMaxLength(20).HasColumnName("KursAdı").HasColumnType("nvarchar");
            Property(x => x.Description).IsOptional().HasMaxLength(250).HasColumnName("Açıklama").HasColumnType("nvarchar");
            Property(x => x.BeginDate).IsRequired().HasColumnName("BaşlangıçTarihi").HasColumnType("datetime2");

            //İlişki

            HasMany(c => c.Customers).WithMany(c => c.Courses).Map(cc =>
            {
                cc.ToTable("KursKursiyer_Islem");
                cc.MapLeftKey("KursID");
                cc.MapRightKey("KursiyerID");

            });
        }
    }
}
