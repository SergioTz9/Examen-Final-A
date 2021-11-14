using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlCatedratico.Models
{
    public class CursosModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo Curso")]
        public int CodigoCurso { get; set; }

        [Required(ErrorMessage = "Campo Nombre es Obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Nombre Curso")]
        public String NombreCurso { get; set; }

        [Required(ErrorMessage = "Campo Fecha es Obligatorio")]
        [Column(TypeName = "DATETIME")]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }


        [Required(ErrorMessage = "Campo Fecha es Obligatorio")]
        [Column(TypeName = "DATETIME")]
        [Display(Name = "Fecha Finaliza")]
        public DateTime FechaFinaliza { get; set; }

        public string EstadoCurso { get; set; } = "ACTIVO";

        public List<CatedraticoModel> CatedraticoModels { get; set; }

        public int CodigoCatedratico { get; set; }
        public CatedraticoModel CatedraticoModel = new CatedraticoModel();
    }
}
