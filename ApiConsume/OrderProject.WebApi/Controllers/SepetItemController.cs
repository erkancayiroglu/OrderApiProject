using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.SepetItems;

using OrderProject.EntityLayer.Concrete;
using System.Security.Claims;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetItemController : ControllerBase
    {
        private readonly ISepetItemService _sepetItemService;
        private readonly UserManager<AppUser> _userManager; 
   

        public SepetItemController(ISepetItemService sepetItemService, UserManager<AppUser> userManager)
        {
            _sepetItemService = sepetItemService;
           _userManager = userManager;
            
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _sepetItemService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult AddItem(CreateSepetItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var price = _sepetItemService.TGetPrice(dto.ProductId);

            var sepetItem = new SepetItem
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId,
                Piece = dto.Piece,
                TotalPrice = dto.Piece * price
            };

            _sepetItemService.TInsert(sepetItem);

            return Ok();

        }
        [HttpGet("{id}")]
        public IActionResult GetSepetItem(int id)
        {
            var values = _sepetItemService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSepetItem(int id)
        {
            var values = _sepetItemService.TGetById(id);
            _sepetItemService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetUserSepet/{id}")]
        public IActionResult GetUserSepet(int id)
        {
            var values = _sepetItemService.TGetUserSepetItem(id);
            var totalAmount = values.Sum(s => s.Product.Price * s.Piece);

            var sepetDetails = new ResultSepetItemDto
            {
                SepetItems = values,
                TotalAmount = totalAmount
            };
            return Ok(sepetDetails);

        }
        [HttpDelete("ClearUserSepet/{id}")]
        public IActionResult ClearUserSepet(int id)
        {
            _sepetItemService.TDeleteUserSepet(id);
            return Ok();

        }
        [HttpPost("AddToCard/{productId}/{userId}")]
        public IActionResult AddToCard(int productId, int userId)
        {
            _sepetItemService.TAddToCard(productId, userId);
            return Ok();
        }
    }
}
