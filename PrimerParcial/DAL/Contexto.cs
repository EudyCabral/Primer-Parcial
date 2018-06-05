using PrimerParcial.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PrimerParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Grupos> grupos { get; set; }

        public Contexto() : base ("ConStr")
        {
        }
    }
}
