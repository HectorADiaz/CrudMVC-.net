using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public int? edad { get; set; }
       
    }
}