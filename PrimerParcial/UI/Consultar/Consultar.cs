using PrimerParcial.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace PrimerParcial.UI.Consultar
{
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Grupos grupos = new Grupos();
            Expression<Func<Grupos, bool>> Filtro = x => true; 


            switch(FiltrocomboBox.SelectedIndex)
            {
               

                case 0://Grupo ID
                   
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        int id = Convert.ToInt32(criteriotextBox.Text);
                        if (FechacheckBox.Checked == true)
                        {
                            Filtro = x => x.Grupoid==id && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year) && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);
                            GeneralerrorProvider.Clear();
                        }
                        else
                        {
                            Filtro = x => x.Grupoid==id;
                            GeneralerrorProvider.Clear();
                        }

                        if(BLL.GruposBLL.GetList(Filtro).Count()==0)
                        {
                            MessageBox.Show("Este ID, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    break;
                
                case 1://Descripcion
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        if (FechacheckBox.Checked == true)
                        {
                            Filtro = x => x.Descripcion.Contains(criteriotextBox.Text) && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year) && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);
                            GeneralerrorProvider.Clear();
                        }
                        else
                        {
                            Filtro = x => x.Descripcion.Contains(criteriotextBox.Text);
                            GeneralerrorProvider.Clear();
                        }

                        if (BLL.GruposBLL.GetList(Filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Descripcion, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    break;
                case 2://Cantidad

                    
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        int Cantidades = Convert.ToInt32(criteriotextBox.Text);
                        if (FechacheckBox.Checked == true)
                        {
                            Filtro = x => x.Cantidad==Cantidades && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year) && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);
                            GeneralerrorProvider.Clear();
                        }
                        else
                        {
                            Filtro = x => x.Cantidad==Cantidades;
                            GeneralerrorProvider.Clear();
                        }


                        if (BLL.GruposBLL.GetList(Filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Cantidad, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                    }
                    break;
                case 3://Grupos

                    
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        int grupo = Convert.ToInt32(criteriotextBox.Text);
                        if (FechacheckBox.Checked == true)
                        {
                            Filtro = x => x.Grupo == grupo && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year) && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);
                            GeneralerrorProvider.Clear();
                        }
                        else
                        {
                            Filtro = x => x.Grupo == grupo;
                            GeneralerrorProvider.Clear();
                        }
                        if (BLL.GruposBLL.GetList(Filtro).Count() == 0)
                        {
                            MessageBox.Show("Este # de Grupos No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    break;
                case 4://Integrantes
                    {
                        

                        if (Validar(1))

                        {
                            MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            int Integrantes = Convert.ToInt32(criteriotextBox.Text);
                            if (FechacheckBox.Checked == true)
                            {
                                Filtro = x => x.integrantes == Integrantes && (x.Fecha.Day >= DesdedateTimePicker.Value.Day) && (x.Fecha.Month >= DesdedateTimePicker.Value.Month) && (x.Fecha.Year >= DesdedateTimePicker.Value.Year) && (x.Fecha.Day <= HastadateTimePicker.Value.Day) && (x.Fecha.Month <= HastadateTimePicker.Value.Month) && (x.Fecha.Year <= HastadateTimePicker.Value.Year);
                                GeneralerrorProvider.Clear();
                            }
                            else
                            {
                                Filtro = x => x.integrantes == Integrantes;
                                GeneralerrorProvider.Clear();
                            }
                            if (BLL.GruposBLL.GetList(Filtro).Count() == 0)
                            {
                                MessageBox.Show("Este # de Integrantes, No Existe ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                        }
                    }
                    break;
                case 5://Todo
                    ConsultardataGridView.DataSource = BLL.GruposBLL.GetList(Filtro);
                    if (BLL.GruposBLL.GetList(Filtro).Count() == 0)
                    {
                        MessageBox.Show("Lista esta Vacia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    break;
            }
            ConsultardataGridView.DataSource = BLL.GruposBLL.GetList(Filtro);
           
        }

        private bool Validar(int error)
        {
            bool paso = false;
            int num = 0;

            if (error == 1 && string.IsNullOrEmpty(criteriotextBox.Text))
            {
                GeneralerrorProvider.SetError(criteriotextBox, "Por Favor, LLenar Casilla!");
                paso = true;
            }
            if (error == 2 && int.TryParse(criteriotextBox.Text, out num) == false)
            {
                GeneralerrorProvider.SetError(criteriotextBox, "Debe Digitar un Numero");
                paso = true;
            }

            if (error == 3 && int.TryParse(criteriotextBox.Text, out num) == true)
            {
                GeneralerrorProvider.SetError(criteriotextBox, "Debe Digitar Caracteses");
                paso = true;
            }

            return paso;
        }

        private void Consultar_Load(object sender, EventArgs e)
        {

        }
    }
}
