using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Identity.Models;

namespace Notes.Identity.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property<string>(u=>u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property<string>(u=>u.LastName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
