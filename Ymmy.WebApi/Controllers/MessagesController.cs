using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymmy.WebApi.Context;
using Ymmy.WebApi.Dtos.MessageDtos;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _contex;

        public MessagesController(IMapper mapper, ApiContext contex)
        {
            _mapper = mapper;
            _contex = contex;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _contex.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDtos>>(values));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDtos createMessageDtos)
        {

            var value = _mapper.Map<Entities.Message>(createMessageDtos);
            _contex.Messages.Add(value);
            _contex.SaveChanges();
            return Ok("Mesaj Ekleme Başarılı ");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _contex.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Mesaj Bulunamadı");
            }
            _contex.Messages.Remove(value);
            _contex.SaveChanges();
            return Ok("Mesaj Silme Başarılı");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _contex.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Mesaj Bulunamadı");
            }
            return Ok(_mapper.Map<GetByIdMessageDtos>(value));
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDtos updateMessageDtos)
        {
            var value = _mapper.Map<Message>(updateMessageDtos);
            _contex.Messages.Update(value);
            _contex.SaveChanges();
            return Ok("Mesaj Güncelleme Başarılı");
        }
    }
}
