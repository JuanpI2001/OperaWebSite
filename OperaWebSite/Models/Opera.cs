using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//agregar 
using System.ComponentModel.DataAnnotations.Schema;//agregar
using System.Linq;
using System.Web;
using OperaWebSite.Validations;//agregar carpeta validaciones

namespace OperaWebSite.Models
{
    [Table("Opera")]//Para La Base de datos 
    public class Opera
    {
        public int OperaId { get; set; }

        [Required(ErrorMessage ="Is required")]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Composer { get; set; }
        [CheckValidYear]
        public int Year { get; set; }
    }
}