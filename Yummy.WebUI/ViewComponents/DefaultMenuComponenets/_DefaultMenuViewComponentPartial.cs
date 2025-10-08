using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.ViewComponents.DefaultMenuComponenets
{
    public class _DefaultMenuViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
