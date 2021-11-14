using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlCatedratico.Models;

namespace ControlCatedratico.Connection
{
    public class Conn : DbContext
    {
        public Conn(DbContextOptions<Conn> options) : base(options) { }

        public DbSet<CatedraticoModel> tbl_RegistroCatedratico { get; set; }
        public DbSet<CursosModel> tbl_RegistroCursos{ get; set; }
   
    }
}

