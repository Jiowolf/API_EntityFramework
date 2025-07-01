using API_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;

namespace API_EntityFramework.Data
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options) { }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(u => u.LastName)
                    .HasMaxLength(10);
                entity.Property(u=> u.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                //entity.HasOne<Address>()
                //    .WithMany()
                //    .HasForeignKey(fk => fk.IdAdress)
                //    .OnDelete(DeleteBehavior.Restrict);
            });

            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.HasKey(a => a.Id);

            //    entity.Property(a => a.StreetNumber)
            //        .IsRequired()
            //        .HasMaxLength(10);
            //    entity.Property(a => a.ZipCode)
            //        .IsRequired();
            //    entity.Property(a=>a.Town)
            //        .IsRequired()
            //        .HasMaxLength(10);
            //    entity.Property(a=> a.Country)
            //        .IsRequired()
            //        .HasMaxLength(10);
            //});



            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1, // Ensure IDs are provided for seeding
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "johndoe@domain.be",
                        //IdAdress = 1
                    }
                );

                modelBuilder.Entity<Address>().HasData
                (
                    new Address
                    {
                        Id = 1,
                        StreetNumber = "8",
                        ZipCode = 4530,
                        Town = "Villers-le-bouillet",
                        Country = "Belgium"
                    }
                );
            }



        }
    }
}
