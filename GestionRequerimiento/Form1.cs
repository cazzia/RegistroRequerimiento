using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionRequerimiento.Properties;
using AccesoDatos;

namespace GestionRequerimiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            GestionRequerimientoEntities db = new GestionRequerimientoEntities();

            cboUsuarioCreacion.DataSource = db.Usuarios.ToList();
            cboUsuarioCreacion.ValueMember = "Id";
            cboUsuarioCreacion.DisplayMember = "Nombres";


            cboUsuarioResponsable.DataSource = db.Usuarios.ToList();
            cboUsuarioResponsable.ValueMember = "Id";
            cboUsuarioResponsable.DisplayMember = "Nombres";

            cboEstado.DataSource = db.Estados.ToList();
            cboEstado.ValueMember = "Id";
            cboEstado.DisplayMember = "Nombre";

            cboSeveridad.DataSource = db.Severidad.ToList();
            cboSeveridad.ValueMember = "Id";
            cboSeveridad.DisplayMember = "Nombre";

            cboCategoria.DataSource = db.Categoria.ToList();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Nombre";




        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                GestionRequerimientoEntities db = new GestionRequerimientoEntities();
                Requerimiento requerimiento = new Requerimiento();

                String nombre = txtNombre.Text;
                String descripcion = txtDescripcion.Text;
                int usuarioCreacion = int.Parse(cboUsuarioCreacion.SelectedValue.ToString());
                int usuarioResponsable = int.Parse(cboUsuarioResponsable.SelectedValue.ToString());
                int estado = int.Parse(cboEstado.SelectedValue.ToString());
                int severidad = int.Parse(cboSeveridad.SelectedValue.ToString());
                int categoria = int.Parse(cboCategoria.SelectedValue.ToString());
                DateTime fechaCreacion = dtpFechaCreacion.Value;
                DateTime fechaSolucion = dtpFechaSolucion.Value;

                requerimiento.NombreRequerimiento = nombre;
                requerimiento.Descripcion = descripcion;
                requerimiento.UsuarioCreacion = usuarioCreacion;
                requerimiento.UsuarioResponsable = usuarioResponsable;
                requerimiento.Estado = estado;
                requerimiento.Severidad = severidad;
                requerimiento.Categoria = categoria;
                requerimiento.FechaCreacion = fechaCreacion;
                requerimiento.FechaSolucion = fechaSolucion;

                db.Requerimiento.Add(requerimiento);
                db.SaveChanges();

                MessageBox.Show("El requerimiento se guardo correctamente");
            }
            catch (Exception x)
            {
                MessageBox.Show("ERROR : " );
            }

            



        }




        }
    }

