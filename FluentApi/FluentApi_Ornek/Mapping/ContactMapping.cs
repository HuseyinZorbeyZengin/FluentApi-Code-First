using FluentApi_Ornek.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi_Ornek.Mapping
{
    public class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            ToTable("İletişim");
            HasKey(con => con.ID);

            Property(p => p.ID).HasColumnName("İletişimID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Primary key adını değiştirip ondan sonra identity verildi.

            DisplayFormatAttribute adresYok = new DisplayFormatAttribute();
            adresYok.NullDisplayText = "Adres yok";

            Property(p => p.Adress).HasColumnName("Adres").HasColumnType("varchar").HasColumnAnnotation("DisplayFormat", adresYok).HasMaxLength(250); // Database de veri girilmediğinde kolonda ''Null'' yerine ''Adres Yok'' yazacak.

            Property(p => p.Phone).IsFixedLength().HasMaxLength(13);

            //İlişki

            HasRequired(c => c.Customer).WithMany(c => c.Contacts).HasForeignKey(c => c.CustomerID).WillCascadeOnDelete(false);
        }
    }
}
