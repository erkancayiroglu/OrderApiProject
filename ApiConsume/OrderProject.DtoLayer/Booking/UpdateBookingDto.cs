using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.Booking
{
    public class UpdateBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string UserMail { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public string BookingTime { get; set; }
        public string BookingDay { get; set; }
        public string Status { get; set; }

        public string RestaurantName { get; set; }

        public int NumberOfPeople { get; set; }
        public string Message { get; set; }
    }
}
