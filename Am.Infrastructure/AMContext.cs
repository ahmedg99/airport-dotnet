using Am.Infrastructure.Configuration;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure
{
    public class AMContext : DbContext
    {





       
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }
        public DbSet<Ticket> Ticket { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }



        // appliquer fluent api 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1er methode pour appliquer  fluent api 

            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlighConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationTicketConfiguration());


            // 2eme methode pour appliquer  fluent api 
            modelBuilder.Entity<Passenger>()
                
               .OwnsOne(p => p.FullName, Full =>
            {
                Full.Property(p => p.FirstName).HasMaxLength(30).HasColumnName("passFirstName");
                Full.Property(p => p.LastName).HasColumnName("passLastName").IsRequired(true);
               
            })





               // configuration de l'héritage : TPH 
               /*
               .HasDiscriminator<int>("PassengerType")
               .HasValue<Passenger>(0)
               .HasValue<Staff>(1)
               .HasValue<Traveller>(2) 
               */
               

               



               ;
            // config de tpt :

            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            modelBuilder.Entity<Staff>().ToTable("Staffs");




        }

        // 
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }


    }


}
