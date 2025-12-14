public class CreateUIOrderDto
{
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public string OrderStatus { get; set; }
    public List<CreateOrderBookDto> OrderBooks { get; set; }
}