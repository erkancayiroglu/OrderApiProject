using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.Restaurant;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            var values = _restaurantService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
           var restaurant=_mapper.Map<Restaurant>(createRestaurantDto);
            _restaurantService.TInsert(restaurant);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var restaurant = _mapper.Map<Restaurant>(updateRestaurantDto);
            _restaurantService.TUpdate(restaurant);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            var values = _restaurantService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = _restaurantService.TGetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _restaurantService.TDelete(restaurant);
            return Ok();
        }
    }
}
