//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCCRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public int idUser { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public Nullable<int> idStatus { get; set; }
        public Nullable<int> edad { get; set; }
    
        public virtual cstate cstate { get; set; }
    }
}
