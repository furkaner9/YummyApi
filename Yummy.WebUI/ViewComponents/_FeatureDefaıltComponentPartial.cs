using Microsoft.AspNetCore.Mvc;

namespace Yummy.WebUI.ViewComponents
{
    public class _FeatureDefaıltComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
