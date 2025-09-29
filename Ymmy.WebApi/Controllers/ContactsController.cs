using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymmy.WebApi.Context;
using Ymmy.WebApi.Dtos.ContactDtos;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Email = createContactDto.Email;
            contact.Address = createContactDto.Address;
            contact.MapLocation = createContactDto.MapLocation;
            contact.Phone = createContactDto.Phone;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _context.Contacts.Find(updateContactDto.ContactId);
            if (value == null)
            {
                return NotFound();
            }
            value.MapLocation = updateContactDto.MapLocation;
            value.Phone = updateContactDto.Phone;
            value.Address = updateContactDto.Address;
            value.Email = updateContactDto.Email;
            value.OpenHours = updateContactDto.OpenHours;
            _context.SaveChanges();
            return Ok("Günceleme Başarılı ");

        }
    }
}
