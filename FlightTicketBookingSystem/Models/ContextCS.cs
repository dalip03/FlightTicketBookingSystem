using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FlightTicketBookingSystem.Models
{
    public class ContextCS : DbContext
    {
        public ContextCS():base("cs") 
        { 
             
        }

        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }
        public DbSet<AeroPlaneInfo> aeroPlaneInfos { get; set;}
        public DbSet<FlightBooking> flightBookings { get; set; }

        public DbSet<TicketReserve_tbl> TicketReserve_tbls { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingDetailsData> bookingDetailsDatas { get; set; }
        /*public DbSet<Booking> Bookings { get; set; }*/
    }
}