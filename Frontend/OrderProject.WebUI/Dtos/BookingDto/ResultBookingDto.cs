namespace OrderProject.WebUI.Dtos.BookingDto
{
    public class ResultBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string UserMail { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime BookingDate { get; set; }

        public string BookingTime { get; set; }

        public string BookingDay { get; set; }

        public string Status { get; set; }

        public string RestaurantName { get; set; }

        public int NumberOfPeople { get; set; }
        public string Message { get; set; }
    }
}
