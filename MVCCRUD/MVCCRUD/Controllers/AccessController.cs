 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string u, string password) 
        {
            try
            {
                using (cursomvcEntities db = new cursomvcEntities ())
                {
                    var lst = from d in db.usuario
                              where d.correo == u && d.password == password && d.idStatus == 1
                              select d;
                    if (lst.Count() > 0)
                    {

                        usuario oUser = lst.First();
                        Session["Usuario"] = oUser;
                        return Content("1");
                    }
                    else {
                        return Content("Usuario no Valido");
                    }
                }
                
            }
            catch (Exception ex) 
            {
                return Content("Ocurrio un error " + ex.Message);
            }
        }
 
    }
}