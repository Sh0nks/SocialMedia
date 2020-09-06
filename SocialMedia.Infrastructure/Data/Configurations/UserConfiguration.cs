using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastruncture.Data.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdUsario");
            builder.Property(e => e.LastName).HasColumnName("Apellidos")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
            
            builder.Property(e => e.DateBorn).HasColumnType("date").HasColumnName("FechaNacimiento");
            
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            
            builder.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}