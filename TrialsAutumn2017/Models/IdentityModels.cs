using Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace TrialsAutumn2017.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public bool IsActivated { get; set; }
        public string ActivationKey { get; set; }
        public string PasswordRestoreKey { get; set; }
    }

    public class Customer : ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Artist : ApplicationUser
    {
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public City City { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        //the school section
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        
        //the makeup section
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        public SchoolDbContext()
            : base("LocalDbConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Artist>().ToTable("Artists");
        }
    }

    public enum ReservationStatus
    {
        Pending = 1, Expired, Approved, DeclinedByArtist, Completed, CancelledByClient, ReportedIssue
    }

    public class Reservation
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime Time { get; set; }
        
        ReservationStatus _status;
        public ReservationStatus Status
        {
            get
            {
                if (_status == ReservationStatus.Pending && (DateTime.Now - CreatedTime).Days >= 2)
                {
                    _status = ReservationStatus.Expired;
                }
                if (_status == ReservationStatus.Approved && DateTime.Now > Time)
                {
                    _status = ReservationStatus.Completed;
                }
                return _status;
            }
            private set
            {
                _status = value;
            }
        }

        public void UpdateMyStatus(ReservationStatus status)
        {
            Status = status;
        }
    }

    public class TestPrivatePartsDb : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
    }
}