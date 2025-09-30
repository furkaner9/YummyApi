using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymmy.WebApi.Context;
using Ymmy.WebApi.Dtos.FeatureDtos;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _contex;
        public FeaturesController(IMapper mapper, ApiContext contex)
        {
            _mapper = mapper;
            _contex = contex;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _contex.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDtos>>(values));

        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDtos createFeatureDtos)
        {
            var value = _mapper.Map<Feature>(createFeatureDtos);
            _contex.Features.Add(value);
            _contex.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _contex.Features.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _contex.Features.Remove(value);
            _contex.SaveChanges();
            return Ok();
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _contex.Features.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetByIdFeatureDtos>(value));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDtos updateFeatureDtos)
        {
            var value = _mapper.Map<Feature>(updateFeatureDtos);
            _contex.Features.Update(value);
            _contex.SaveChanges();
            return Ok("Güncleme Tamamlandı ");

        }

    }
}
