namespace OrderProject.WebUI.Dtos.OrderDto
{
    public class OrderUserUIDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }

    }
}
