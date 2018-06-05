using PrimerParcial.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrimerParcial.UI.Registro
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        private Grupos LlenaClase()
        {
            Grupos grupos = new Grupos();
            grupos.Grupoid = Convert.ToInt32(grupoidNumericUpDown.Value);
            grupos.Fecha = fechaDateTimePicker.Value;
            grupos.Descripcion = descripcionTextBox.Text;
            grupos.Cantidad = Convert.ToInt32(cantidadNumericUpDown.Value);
            grupos.Grupo = Convert.ToInt32(grupoNumericUpDown.Value);
            grupos.integrantes = Convert.ToInt32(cantidadNumericUpDown.Value) / Convert.ToInt32(grupoNumericUpDown.Value);
           
            return grupos;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(grupoidNumericUpDown.Value);
            Grupos grupos = BLL.GruposBLL.Buscar(id);
            if(validar(1))
            {
                MessageBox.Show("Llene la Casilla Grupo ID", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            if(grupos != null)
            {


                 grupoidNumericUpDown.Value = grupos.Grupoid ;
                fechaDateTimePicker.Value = grupos.Fecha  ;
                 descripcionTextBox.Text = grupos.Descripcion ;
                cantidadNumericUpDown.Value = grupos.Cantidad ;
                grupoNumericUpDown.Value = grupos.Grupo;
                integrantesNumericUpDown.Value = grupos.integrantes ;
                GeneralerrorProvider.Clear();
            }
            else
            {
                MessageBox.Show("No Encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Grupos grupo = LlenaClase();

            if (validar(2))
            {
                MessageBox.Show("Llene las Casilla  Correspondiente", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (grupoidNumericUpDown.Value == 0)
                {
                    paso = BLL.GruposBLL.Guardar(LlenaClase());
                }
                else
                {
                    paso = BLL.GruposBLL.Editar(LlenaClase());
                }

                if (paso)
                {
                    MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Pudo Guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           


        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grupoidNumericUpDown.Value);

            if(validar(1))
            {
                MessageBox.Show("Llene la Casilla Grupo ID", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            }
            else

            if(BLL.GruposBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Pudo Eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GeneralerrorProvider.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

            grupoidNumericUpDown.Value = 0;
            fechaDateTimePicker.Value = DateTime.Now;
            descripcionTextBox.Clear();
            cantidadNumericUpDown.Value = 0;
            grupoNumericUpDown.Value = 0;
            integrantesNumericUpDown.Value = 0;
            GeneralerrorProvider.Clear();
        }

        public bool validar(int error)
        {
            bool paso = false;

            if (error == 1 && grupoidNumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(grupoidNumericUpDown, "Llenar Grupo ID");
                paso = true;
            }


            if (error == 2 && string.IsNullOrEmpty(descripcionTextBox.Text))
            {
                GeneralerrorProvider.SetError(descripcionTextBox, "Lllenar Descripcion");
                paso = false;
            }

            if (error == 2 && cantidadNumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(cantidadNumericUpDown, "Llenar Cantidad De Estudiantes");
                paso = true;
            }
            if (error == 2 && grupoNumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(grupoNumericUpDown, "Llenar Existencia");
                paso = true;
            }
          
            return paso;
        }

        private void integrantesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
          
        }
    }
}
