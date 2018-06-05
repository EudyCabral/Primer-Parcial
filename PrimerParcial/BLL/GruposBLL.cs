using PrimerParcial.DAL;
using PrimerParcial.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrimerParcial.BLL
{
    public class GruposBLL
    {
        public static bool Guardar(Grupos grupo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.grupos.Add(grupo) != null)
                {
                    contexto.SaveChanges();
                    paso = true;

                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Grupos grupos = contexto.grupos.Find(id);
                if (grupos != null)
                {
                    contexto.Entry(grupos).State = EntityState.Deleted;
                }
                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        

        public static bool Editar(Grupos grupos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(grupos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            { throw; }
            return paso;
        }

        public static Grupos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Grupos grupos = new Grupos();

            try
            {
                grupos = contexto.grupos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return grupos;

        }

        public static List<Grupos> GetList(Expression<Func<Grupos, bool>> expression)
        {
            List<Grupos> articulos = new List<Grupos>();
            Contexto contexto = new Contexto();

            try
            {
                articulos = contexto.grupos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return articulos;
        }




    }
}