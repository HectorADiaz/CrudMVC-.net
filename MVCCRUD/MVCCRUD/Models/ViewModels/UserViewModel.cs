using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCRUD.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]//para que sea obligatorio
        [EmailAddress]//para que solo acepte correos Electronicos
        [Display(Name = "Correo Electronico")]//Para mostrar en el "label"
        [StringLength(100, ErrorMessage ="La {0} debe tener al menos {1} caracteres",MinimumLength =1)]//longitud minima y maxima del campo email 
        public string Email { get;set; }
        
        [Required]//para que sea obligatorio
        [DataType(DataType.Password)]//ya se envia como tipo password  
        [Display(Name = "Contraseña")]//Para mostrar en el "label"
        public string Password { get; set; }

        [DataType(DataType.Password)]//ya se envia como tipo password
        [Compare("Password", ErrorMessage ="Las contraseñas no son iguales")]// el comprare nos sirve para validar que las dos contraeñas sean iguales, ya no necesitamos realizar un if
        public string ConfirmPassword { get; set; }
        
        [Required]//para que sea obligatorio
        public int edad { get; set; }
    }



    public class EditUserViewModel
    {
        public int idUsuario {get; set; }
        [Required] 
        [EmailAddress] 
        [Display(Name = "Correo Electronico")] 
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)] 
        public string Email { get; set; }

        [DataType(DataType.Password)]   
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int edad { get; set; }
    }

}