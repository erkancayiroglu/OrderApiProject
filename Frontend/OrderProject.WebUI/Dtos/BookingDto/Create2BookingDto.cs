namespace OrderProject.WebUI.Dtos.BookingDto
{
    public class Create2BookingDto
    {
        public string Name { get; set; }
        public string UserMail { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public string BookingTime { get; set; }

        public string BookingDay { get; set; }

        public string RestaurantName { get; set; }

        public int NumberOfPeople { get; set; }
        public string Message { get; set; }
    }
}
