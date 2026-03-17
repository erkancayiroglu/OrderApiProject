using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DtoLayer.Products;
using OrderProject.DtoLayer.Staff;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;
        public StaffController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetStaffs()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff(CreateStaffDto createStaffDto)
        {
            var values = _mapper.Map<Staff>(createStaffDto);
            _staffService.TInsert(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(UpdateStaffDto updateStaffDto)
        {
            if (ModelState.IsValid == null)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Staff>(updateStaffDto);
            _staffService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values = _staffService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetFirst4Staff")]
        public IActionResult GetFirst4Staff()
        {
            var values = _staffService.TGetFirst4Staff();
            return Ok(values);
        }
    }
}
