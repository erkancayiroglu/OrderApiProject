using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;
using OrderProject.DtoLayer.Products;
using OrderProject.EntityLayer.Concrete;
using System.Security.Claims;


namespace OrderProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private IMapper _mapper;
       
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        

        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var values = _productService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
            var values =_mapper.Map<Product>(createProductDto);
            _productService.TInsert(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid == null)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(values);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetById(id);
            if (product == null)
            {
                return BadRequest();
            }
            _productService.TDelete(product);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetProductList")]
        public IActionResult GetProductList(int id)
        {
            var products = _productService.TGetProductList(id);
            var dtoList = products.Select(x => new IndexProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price= x.Price,
                Stock= x.Stock,
                ImageUrl= x.ImageUrl,
                CategoryId= x.CategoryId,
            }).ToList();

            return Ok(dtoList);
          
        }
       
    }
}
