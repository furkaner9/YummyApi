using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
