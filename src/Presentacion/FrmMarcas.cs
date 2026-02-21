using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmMarcas : Form
    {
        // ---------- Campos privados ----------
        private List<Marca> listaMarcas;
        private Marca marcaActual;

        // ---------- Inicialización ----------
        public FrmMarcas()
        {
            InitializeComponent();
        }
        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.ToString());
            }
        }

        private void CargarFormulario()
        {
            // Categorias
            CargarListaMarcas();
            CargarMarcaSeleccionada();

            // IU
            LimpiarFiltros();
            MostrarGrilla();
        }

        // ---------- Carga de Datos ----------
        private void CargarListaMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            listaMarcas = negocio.Listar();
        }

        // ---------- Eventos Principales ----------
        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            CargarMarcaSeleccionada();

            if (marcaActual == null)
            {
                return;
            }
        }

        // ---------- Eventos ABM ----------
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaMarca formulario = new FrmAltaMarca();

            formulario.ShowDialog();

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!HayMarcaSeleccionada())
            {
                return;
            }

            Marca seleccionada = marcaActual;

            // TODO: Crear constructor del formulario que reciba por parametro la marca a modificar

            // FrmAltaMarca formulario = new FrmAltaMarca(seleccionada);
            // formulario.ShowDialog();

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!HayMarcaSeleccionada())
            {
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Seguro que deseas eliminar la marca?", "Eliminar marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                EliminarMarcaSeleccionada();
            }

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void EliminarMarcaSeleccionada()
        {
            try
            {
                int id = marcaActual.Id;
                string nombre = marcaActual.Descripcion;

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Eliminar(id);

                MessageBox.Show("La marca '" + nombre + "' fue eliminada correctamente.", "Eliminar marca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la marca: " + ex.Message);
            }
        }

        // ---------- Eventos de UI ----------
        private void CargarMarcaSeleccionada()
        {
            if (dgvMarcas.CurrentRow == null)
            {
                marcaActual = null;
                return;
            }

            marcaActual = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
        }

        private void MostrarGrilla(List<Marca> lista = null)
        {
            if (lista == null)
            {
                lista = listaMarcas;
            }

            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = lista;
            dgvMarcas.ClearSelection();

            OcultarColumnas();
        }

        private void LimpiarFiltros()
        {
            txtFiltroRapido.Clear();
        }

        private bool HayMarcaSeleccionada()
        {
            if (dgvMarcas.CurrentRow == null || dgvMarcas.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No hay una marca seleccionada. Por favor seleccione una.", "Gestionar marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void OcultarColumnas()
        {
            dgvMarcas.Columns["Id"].Visible = false;
        }

        // ---------- Filtros ----------
        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Marca> listaFiltrada;
            string filtro = txtFiltroRapido.Text;

            if (filtro.Length >= 3) // Solo filtra a partir de 3 caracteres
            {
                listaFiltrada = listaMarcas.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaMarcas;
            }

            MostrarGrilla(listaFiltrada);
        }
    }
}
