using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.Booking;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values=_bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking (CreateBookingDto createBookingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
           createBookingDto.Status = "Onay Bekliyor";
            var values = _mapper.Map<Booking>(createBookingDto);//Bunu yapmazsak tek tek atamamız gerekir
            _bookingService.TInsert(values);//Entity sınıfını kullanırız
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var values = new Booking
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,  //Görüldüğü gibi tek tek atama yapıyoruz
                UserMail = updateBookingDto.UserMail,
                Status=updateBookingDto.Status,
                PhoneNumber = updateBookingDto.PhoneNumber,
                BookingDate = updateBookingDto.BookingDate,
                BookingDay= updateBookingDto.BookingDay,
                BookingTime = updateBookingDto.BookingTime,
                RestaurantName = updateBookingDto.RestaurantName,
                NumberOfPeople = updateBookingDto.NumberOfPeople,
                Message = updateBookingDto.Message
            };//Bunu mapper kullanmazsak tek tek atamamız gerekir
            _bookingService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok();
        }

    }
}
