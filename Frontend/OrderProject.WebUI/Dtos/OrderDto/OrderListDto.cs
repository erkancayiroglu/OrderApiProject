namespace OrderProject.WebUI.Dtos.OrderDto
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }

        public string Name { get; set; }
    }
}
