using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models;
using MVCCRUD.Models.TableViewModels;
using MVCCRUD.Models.ViewModels;
namespace MVCCRUD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (cursomvcEntities db = new cursomvcEntities())
            {

                lst = (from d in db.usuario
                       where d.idStatus == 1
                       orderby d.correo
                       select new UserTableViewModel
                       {
                           correo = d.correo,
                           idUsuario = d.idUser,
                           edad = d.edad
                       }).ToList();

            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            using (var db = new cursomvcEntities()) 
            {
                usuario oUsuario = new usuario();
                oUsuario.idStatus = 1;
                oUsuario.correo = model.Email;
                oUsuario.edad = model.edad;
                oUsuario.password = model.Password;

                db.usuario.Add(oUsuario);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/User/"));
        }

        //[Route("Update/{idPerfil:int}")] otra forma de  renombrar el id para que funcione 
        public ActionResult Edit(int id) //el id del edit es segun la configuracion del App_Start/RouterConfig  
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new cursomvcEntities()) 
            {
                var oUsuario = db.usuario.Find(id);
                model.edad = (int)oUsuario.edad;
                model.Email = oUsuario.correo;
                model.idUsuario = oUsuario.idUser;


            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursomvcEntities())
            {
                var oUsuario = db.usuario.Find(model.idUsuario);
                oUsuario.correo = model.Email;
                oUsuario.edad = model.edad;

                if (model.Password!=null && model.Password.Trim() != "")
                {
                    oUsuario.password = model.Password;
                }
                db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
 
            return Redirect(Url.Content("~/User/"));
        }


        //eliminar
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new cursomvcEntities())
            {
                var oUser = db.usuario.Find(Id);
                oUser.idStatus = 3; //eliminaremos

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }


    }
}