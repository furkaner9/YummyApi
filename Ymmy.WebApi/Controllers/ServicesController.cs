using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymmy.WebApi.Context;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {

            var values = _context.Services.ToList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet OLUŞTURULDU");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet SİLİNDİ");
        }
        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Hizmet GÜNCELLENDİ");
        }
    }
}
