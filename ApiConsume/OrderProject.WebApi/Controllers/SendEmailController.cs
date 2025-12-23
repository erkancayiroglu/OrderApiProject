using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DtoLayer.Mail;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;
        private readonly IMapper _mapper;
        public SendEmailController(ISendEmailService sendEmailService,IMapper mapper)
            {
            
            _sendEmailService=sendEmailService;
            _mapper=mapper;
            
            }

        [HttpGet]
        public IActionResult GetSendEmail()
        {
            var values = _sendEmailService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSendEmail(AddSendEmailDto addSendEmailDto)
        {
            _sendEmailService.TAddSendEmail(addSendEmailDto);
            var value = _mapper.Map<SendEmail>(addSendEmailDto);
           
            _sendEmailService.TInsert(value);
            return Ok();
        }
        [HttpPost("ForgotPassword")]
        public IActionResult PasswordSendEmail(AddSendEmailDto addSendEmailDto)
        {
            
            _sendEmailService.TPasswordSendEmail(addSendEmailDto);
            

         
            return Ok();
        }
    }
}
