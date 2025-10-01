using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymmy.WebApi.Context;
using Ymmy.WebApi.Dtos.ProductDtos;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ProductsController(IValidator<Product> validator, ApiContext context,IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _context.Products.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (validationResult.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün Ekleme Başarılı");

             
            }
            else
            {
                return BadRequest(validationResult.Errors);

            }


        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Ürün Silme Başarılı");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) { 
        var value=_context.Products.Find(id);
            if (value == null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product) {
        _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Ürün Güncelleme Başarılı");

        }
        [HttpPost("CreataProductWithCategory")]
        public IActionResult CreataProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Kategori ile Ürün Ekleme Başarılı");


        }


    }
}
