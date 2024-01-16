using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;

namespace RentCar.Persistance.Context
{
    public class RentCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PURPLE;Database=RentCarDB;Trusted_Connection=True; Trust Server Certificate=True;Integrated Security =True;Encrypt=False");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<CarRentalProcess> CarRentalProcesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarRentalProcess>()
                .HasOne(crp => crp.PickUpLocation)
                .WithMany(l => l.CarRentalProcessesForPickUp)
                .HasForeignKey(crp => crp.PickUpLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarRentalProcess>()
                .HasOne(crp => crp.DropOffLocation)
                .WithMany(l => l.CarRentalProcessesForDropOff)
                .HasForeignKey(crp => crp.DropOffLocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
