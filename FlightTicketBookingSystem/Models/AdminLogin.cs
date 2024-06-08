using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace FlightTicketBookingSystem.Models
{
    [Table("TblAdminLogin")]
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }

        [Required (ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        [MinLength(3,ErrorMessage = "Min 3 char is required"), MaxLength(40,ErrorMessage = "Max 40 char is required")]

        public string AdName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min 3 char is required"), MaxLength(10, ErrorMessage = "Max 10 char is required")]

        public string Password { get; set; }
    }



    [Table("TblUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name Required"),MinLength(3),StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Req"), MinLength(3),StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailId Req"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Last Name Req"), MinLength(3), StringLength(20), RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$",ErrorMessage ="User name must be AlphaNumeric")]
         public string UserName { get; set; }

        [Required(ErrorMessage = "Password Req"), DataType(DataType.Password), MinLength(3), StringLength(20)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Age is Required"),Range(18,150)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone no is required"), RegularExpression(@"^(6|7|8|9)\d{9}$", ErrorMessage = "invalid phone number")]
        public string Phoneno { get; set; }

        [Required(ErrorMessage = "Adahar number is required"), RegularExpression(@"^[0-9]{12}", ErrorMessage = "Invalid Aadhaar number")]
        public string AdharNumber { get; set; }
    }

    public class AeroPlaneInfo
    {
        [Key]
        public int Planeid { get; set; }

        [Display(Name = "Aero Plane Name")]
        [Required(ErrorMessage = "Aeroplane Name Req")]
        [MaxLength(30, ErrorMessage = "Max 30 char allowed"), MinLength(3, ErrorMessage = "Min 3 char allowed")]
        public string APlaneName { get; set; }

        [Required(ErrorMessage = "Capacity Req")]
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        public float Price { get; set; }

        public virtual ICollection<TicketReserve_tbl> TicketReserve_Tbls { get; set; }

    }




    [Table("TblFlightBook")]
    public class FlightBooking
    {
        [Key]
        public int bid { get; set; }

        [Required, Display(Name = "Customer Name")]
        public string BCusName { get; set; }

        [Required, Display(Name = "Customer Address")]
        public string bCusAddress { get; set; }

        [Display(Name = "Customer Email"),Required(ErrorMessage = "EmailId Req"), DataType(DataType.EmailAddress)]

        public string bCusEmail { get; set; }

        [Required,Display(Name = "No of Seats")]
        public string bCusSeats { get; set; }

        [Required, Display(Name = "Phone Number")]
        public string bCusPhoneNum { get; set; }

        [Required, Display(Name = "Adhar Number")]
        public string AdharNumber { get; set; }

        public string ResId { get; set; }

        public virtual TicketReserve_tbl TicketReserve_tbls { get; set; }
        
    }

    public class TicketReserve_tbl
    {
        [Key]
        public int ResId { get; set; }

        [Required, Display(Name = "From City")]
        public string Resfrom { get; set; }

        [Required, Display(Name = "To City")]
        public string ResTo { get; set; }

        [Required, Display(Name = "Departure Date")]
        public string ResDepDate { get; set; }

        [Required, Display(Name = "Flight Time")]
        //[StringLength(15)]
        public string ResTime { get; set; }

        [Required, Display(Name = "Plane No")]
        public int PlaneId { get; set; }

        public virtual AeroPlaneInfo Plane_tbls { get; set; }

        [Required, Display(Name = "Seats Available")]
        //[StringLength(25)]
        public int PlaneSeat { get; set; }

        [Required, Display(Name = "Price")]
        public float ResTicketPrice { get; set;}

        [Required, Display(Name = "Plane Type")]
        public string ResTicketType { get; set; }

        public virtual ICollection<FlightBooking> tblFlightBookings { get; set; }

    }


    // created new table from here
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, Display(Name = "Phone Number")]
        public string bCusPhoneNum { get; set; }

        [Required, Display(Name = "Adhar Number")]
        public string AdharNumber { get; set; }

       /* [ForeignKey("TicketReservation")]
        public int ResId { get; set; }*/
        public virtual TicketReserve_tbl TicketReservation { get; set; }
    }


    public class BookingDetailsData
    {
        [Key]
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string bCusPhoneNum { get; set; }
        public string AdharNumber { get; set; }
        public float ResTicketPrice { get; set; }
        public string Resfrom { get; set; }
        public string ResTo { get; set; }
        //new
        public string Time { get; set; }
        public string Date { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual TicketReserve_tbl TicketReserve_tbls { get; set; }
    
    }



}