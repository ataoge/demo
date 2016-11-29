using Microsoft.AspNetCore.Mvc;

namespace Ataoge.TestPlugIn.ViewComponents
{
    [ViewComponent(Name = "Ataoge.TestPlugIn.Simple")]
    public class SimpleViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int number)
        {
            return View(number + 1);
        }
    }
}