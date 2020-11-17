using AspNetMvc_Fileupload_DropzoneJs.Context;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc_Fileupload_DropzoneJs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            db.Customers.ToList();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
