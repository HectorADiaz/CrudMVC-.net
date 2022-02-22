using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models;
using MVCCRUD.Controllers;

namespace MVCCRUD.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (usuario)HttpContext.Current.Session["Usuario"];

            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {

                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {

                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            
            
            base.OnActionExecuting(filterContext);

            
        }
    }
}