using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimerParcial.BLL;
using PrimerParcial.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerParcial.BLL.Tests
{
    [TestClass()]
    public class GruposBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Grupos grupos = new Grupos();
            grupos.Grupoid = 6;
            grupos.Fecha = DateTime.Now;
            grupos.Descripcion = "Grupo Nuevo";
            grupos.Cantidad = 75;
            grupos.Grupo = 3;
            paso = GruposBLL.Guardar(grupos);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = GruposBLL.Eliminar(5);
            Assert.AreEqual(paso,false);
        }

        [TestMethod()]
        public void EditarTest()
        {
            bool paso = false;

            Grupos grupos = new Grupos();

            grupos.Grupoid = 2;
            grupos.Fecha = DateTime.Now;
            grupos.Descripcion = "Grupo Nuevo";
            grupos.Cantidad = 75;
            grupos.Grupo = 3;

            paso = GruposBLL.Editar(grupos);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Grupos grupos = new Grupos();
            
            grupos =GruposBLL.Buscar(2);
            Assert.IsNotNull(grupos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = GruposBLL.GetList(x => true);

            Assert.IsNotNull(lista);
        }
    }
}