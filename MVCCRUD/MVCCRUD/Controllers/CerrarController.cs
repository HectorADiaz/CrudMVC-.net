using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult Logoff()
        {

            Session["Usuario"] = null;
            return RedirectToAction("Index","Access");
        }
    }
}