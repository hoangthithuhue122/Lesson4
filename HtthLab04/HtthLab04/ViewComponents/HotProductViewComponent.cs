using Microsoft.AspNetCore.Mvc;

namespace HtthLab04.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
