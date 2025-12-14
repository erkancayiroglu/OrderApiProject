using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.Category;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var values = _categoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto createCategoryDto)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TInsert(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var value =_mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.TDelete(category);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
     
      
    }
}
