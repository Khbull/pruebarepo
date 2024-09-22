using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Atributos;
using Dominio.Crud;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Variables
        CPersona personas = new CPersona();
        AtributosPersona atributos = new AtributosPersona();
        bool edit = false;



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getData()
        {
            CPersona cPersona = new CPersona();
            DvgDatos.DataSource = cPersona.Mostrar();


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cbSexo.SelectedIndex = 0;
            btnGuardar.Enabled = false;

            getData();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre") txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") txtNombre.Text = "Nombre";
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido") txtApellido.Text = "";
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "") txtApellido.Text = "Apellido";
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            if (txtId.Text == "ID") txtId.Text = "";
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text == "") txtId.Text = "ID";
        }


        private void ClearTextBoxs()
        {

            txtId.Text = "ID";
            txtApellido.Text = "Apellido";
            txtNombre.Text = "Nombre";

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DvgDatos.SelectedRows.Count > 0)
            { 
            DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("¿DESEAS ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    try { 
                    atributos.Id = Convert.ToInt32(DvgDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(atributos);
                        getData();
                        MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "ELIMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {

                //INSERTAR
                try
                {

                    atributos.Id = Convert.ToInt32(txtId.Text);
                    atributos.Nombres = txtNombre.Text;
                    atributos.Apellido = txtApellido.Text;
                    atributos.Sexo = cbSexo.Text;
                    personas.Insertar(atributos);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show("SE GUARDO UN REGISTRO DE FORMA EXITOSA", "INSERTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (edit == true)
            {
                //ACTUALIZAR
                try {
                    atributos.Id = Convert.ToInt32(txtId.Text);
                    atributos.Nombres = txtNombre.Text;
                    atributos.Apellido = txtApellido.Text;
                    atributos.Sexo = cbSexo.Text;
                    personas.Modificar(atributos);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtId.Enabled = true;
                    edit = false;
                    MessageBox.Show("SE ACTUALIZO UN REGISTRO DE FORMA EXITOSA", "MODIFICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (DvgDatos.SelectedRows.Count > 0)
            {
                txtId.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;
                //CARGAR DATOS
                txtId.Text = DvgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = DvgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = DvgDatos.CurrentRow.Cells[2].Value.ToString();
                cbSexo.Text = DvgDatos.CurrentRow.Cells[3].Value.ToString();

            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar...") txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "") 
            {
                txtBuscar.Text = "Buscar...";
                getData();
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CPersona cPersona = new CPersona();
            DvgDatos.DataSource = cPersona.Buscar(txtBuscar.Text);
        }
    }
}