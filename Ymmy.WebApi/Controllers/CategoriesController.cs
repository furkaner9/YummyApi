﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Context.ApiContext _context;
        public CategoriesController(Context.ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {

            var values = _context.Categories.ToList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult Create(Entities.Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("KATEGORİ OLUŞTURULDU");
        }
    
    [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value= _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("KATEGORİ SİLİNDİ");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
           _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("KATEGORİ GÜNCELLENDİ");
        }
    }
}

