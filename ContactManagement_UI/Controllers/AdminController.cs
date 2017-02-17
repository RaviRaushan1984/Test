using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManagement_UI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            if (!Generic.UserProfile.IsSessionValid())
                return RedirectToAction("LogOn", "Account");
            return View();
        }

        public ActionResult ShowError()
        {
            return View();
        }

    }
}
