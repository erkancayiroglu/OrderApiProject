using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.MessageCategory;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;
        private readonly IMapper _mapper;
        public MessageCategoryController(IMessageCategoryService messageCategoryService, IMapper mapper)
        {
            _messageCategoryService = messageCategoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(CreateMessageCategoryDto createMessageCategoryDto)
        {
            var messageCategory = _mapper.Map<MessageCategory>(createMessageCategoryDto);
            _messageCategoryService.TInsert(messageCategory);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(UpdateMessageCategoryDto updateMessageCategoryDto)
        {
            var messageCategory = _mapper.Map<MessageCategory>(updateMessageCategoryDto);
            _messageCategoryService.TUpdate(messageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            _messageCategoryService.TDelete(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            return Ok(values);
        }
    }
}
