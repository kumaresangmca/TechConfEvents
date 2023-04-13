using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechConf.Models.Models;

namespace TechConf.Data
{
    public class TechConfDbContext : DbContext
    {
        public TechConfDbContext(DbContextOptions<TechConfDbContext> options) : base(options) { }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<SpeakerSession> SpeakerSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Organization> organizations = new List<Organization>();
            organizations.Add(new Organization() { Id = 1, Name = "Polaris Consulting & Services Limited", Code ="POLARIS", ApiKey = "p1o2l3a4r5i6s7", CreatedDate = DateTime.Now });
            organizations.Add(new Organization() { Id = 2, Name = "Virtusa Consulting Services Pvt Ltd", Code= "VIR", ApiKey = "v1i2r3t4u5s6a7", CreatedDate = DateTime.Now });
            organizations.Add(new Organization() { Id = 3, Name = "Softcrylic", Code= "SOFT", ApiKey = "s1o2f3t4c5r6y7l8i9c0", CreatedDate = DateTime.Now });
            organizations.Add(new Organization() { Id = 4, Name = "Tata Consultancy Services", Code="TCS", ApiKey = "t1c2c3", CreatedDate = DateTime.Now });
            organizations.Add(new Organization() { Id = 5, Name = "Cognizant Technology Solutions Corp", Code ="CTS", ApiKey = "c1t2s3", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Organization>().HasData(organizations);
        }
    }
}
