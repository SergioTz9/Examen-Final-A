using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlCatedratico.Models
{
    public class CatedraticoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo Catedratico")]
        public int CodigoCatedratico { get; set; }

        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Nombre Catedratico")]
        public String NombreCatedratico { get; set; }


        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Genero Catedratico")]
        public String Genero { get; set; }


        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Estado Civil")]
        public String EstadoCivil { get; set; }

        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Telefono Catedratico")]
        public String TelCatedratico { get; set; }

        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Correo Catedratico")]
        public String CorreoCatedratico { get; set; }

        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "int")]
        [Display(Name = "No DPI ")]
        public int NoDpi { get; set; }

        [Required(ErrorMessage = "Campo Fecha es Obligatorio")]
        [Column(TypeName = "DATETIME")]
        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        public string EstadoCatedratico { get; set; } = "ACTIVO";

        public ICollection<CursosModel> CursosModels { get; set; }
       

    }
}
