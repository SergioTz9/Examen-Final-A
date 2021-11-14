using ControlCatedratico.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCatedratico.Connection;
using ControlCatedratico.Models;
using ControlCatedratico.Repository.iRepository;

namespace ControlCatedratico.Repository
{
    public class CursosRepository : iCursosRepository
    {
        private readonly Conn _db;

        public CursosRepository(Conn db)//metodo contructor inicializa obj de la cxlase
        {
            _db = db;
        }

        public bool ActualizarCurso(CursosModel curso)
        {
            _db.tbl_RegistroCursos.Update(curso);
            return GuardarCurso();
        }

        public bool BorrarCurso(CursosModel curso)
        {
            _db.tbl_RegistroCursos.Remove(curso);
            return GuardarCurso();
        }

        public bool CrearCurso(CursosModel curso)
        {
            _db.tbl_RegistroCursos.Add(curso);
            return GuardarCurso();
        }

        public ICollection<CursosModel> GetCursosModels()
        {
            return _db.tbl_RegistroCursos.OrderBy(p => p.NombreCurso).ToList();
        }

        public CursosModel GetCursosModels(int CodigoCurso)
        {
            return _db.tbl_RegistroCursos.FirstOrDefault(p => p.CodigoCurso == CodigoCurso); ;
        }

        public bool GuardarCurso()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}