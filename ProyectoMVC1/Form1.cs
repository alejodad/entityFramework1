using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMVC1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnModificar.Visible = false;
            listarProfe();
            llenaCmb();
        }
        MaestrosEntities db = new MaestrosEntities();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                tbl_profesor profe = new tbl_profesor();
                profe.idProfesor = Convert.ToInt32(txtId.Text);
                profe.nombreProfesor = txtNombre.Text;
                profe.apellidoProfesor = txtApellido.Text;
                addProfe(profe);
                listarProfe();
                limpiar();
            }
            else
            {
                MessageBox.Show("Debe llenar los campos");
            }


        }

        private void addProfe(tbl_profesor profe)
        {
            using (MaestrosEntities bd = new MaestrosEntities())
            {
                tbl_profesor newProfe = bd.tbl_profesor.Find(profe.idProfesor);
                if(newProfe != null)
                {
                    MessageBox.Show("El profesor ya existe");
                }
                else
                {
                    newProfe = profe;
                    bd.tbl_profesor.Add(newProfe);
                    db.SaveChanges();
                    MessageBox.Show("Se hizo");
                }
                
            }
        }

        private void listarProfe()
        {

            dgvDatosProfe.DataSource = db.tbl_profesor.ToList();
        }

        private void llenaCmb()
        {
            cmbMaterias.DataSource = db.tbl_materia.ToList();
            cmbMaterias.DisplayMember = "nombreMateria";
            cmbMaterias.ValueMember = "idMateria";
        }

        private void buscarProfe()
        {
            tbl_profesor profe = new tbl_profesor();
            profe = db.tbl_profesor.Find(Convert.ToInt32(txtId.Text));
            if (profe != null)
            {
                txtNombre.Text = profe.nombreProfesor;
                txtApellido.Text = profe.apellidoProfesor;
                if (profe != null)
                {
                    btnModificar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron coincidencias");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarProfe();
        }

        private void modificar(int id)
        {
            tbl_profesor profe = new tbl_profesor();
            profe = db.tbl_profesor.Find(id);
            profe.nombreProfesor = txtNombre.Text;
            profe.apellidoProfesor = txtApellido.Text;
            db.SaveChanges();
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificar(Convert.ToInt32(txtId.Text));
            listarProfe();
            btnModificar.Visible = false;
            limpiar();
        }
        private void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }


        private void eliminar(int id)
        {
            tbl_profesor profe = new tbl_profesor();
            profe = db.tbl_profesor.Find(id);
            db.tbl_profesor.Remove(profe);
            db.SaveChanges();
            listarProfe();
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que dese eliminar?", "Eliminar", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                eliminar(Convert.ToInt32(txtId.Text));
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }


        private void dgvDatosProfe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvDatosProfe.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvDatosProfe.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtApellido.Text = dgvDatosProfe.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnModificar.Visible = true;
        }
    }
}
