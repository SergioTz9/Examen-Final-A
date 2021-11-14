
using ControlCatedratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCatedratico.Repository.iRepository
{
    interface iCursosRepository
    {

        ICollection<CursosModel> GetCursosModels();
        CursosModel GetCursosModels(int CodigoCurso);//obtener segun codigo envio

        bool CrearCurso(CursosModel curso);//crear datos area
        bool ActualizarCurso(CursosModel curso);

        bool BorrarCurso(CursosModel curso);

        bool GuardarCurso();
    }
}
