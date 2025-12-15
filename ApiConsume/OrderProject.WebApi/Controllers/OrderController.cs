using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.EntityLayer.Concrete;



namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {



        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet("GetOrder/{userId}")]
        public IActionResult GetOrder(int userId)
        {
            var value = _orderService.TGetOrder(userId);
            return Ok(value);
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);

            _orderService.TInsert(order);

            return Ok(new
            {
                orderId = order.Id
            });
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetDetails(int id)
        {
            var order = _orderService.TGetOrderDetails(id);
            return Ok(order);
        }
        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            var orders = _orderService.TGetOrders();
            return Ok(orders);
        }
        




    }


}
