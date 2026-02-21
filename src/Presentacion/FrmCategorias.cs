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
    public partial class FrmCategorias : Form
    {
        // ---------- Campos privados ----------
        private List<Categoria> listaCategorias;
        private Categoria categoriaActual;

        public FrmCategorias()
        {
            InitializeComponent();
        }

        // ---------- Inicialización ----------
        private void FrmCategorias_Load(object sender, EventArgs e)
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
            CargarListaCategorias();

            // IU
            LimpiarFiltros();
            MostrarGrilla();
        }

        // ---------- Carga de Datos ----------
        private void CargarListaCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            listaCategorias = negocio.Listar();
        }

        // ---------- Eventos Principales ----------
        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            CargarCategoriaSeleccionada();

            if(categoriaActual == null)
            {
                return;
            }
        }

        // ---------- Eventos ABM ----------
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaCategoria formulario = new FrmAltaCategoria();

            formulario.ShowDialog();

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!HayCategoriaSeleccionada())
            {
                return;
            }

            Categoria seleccionada = categoriaActual;

            // TODO: Crear constructor del formulario que reciba por parametro la categoria a modificar

            // FrmAltaCategoria formulario = new FrmAltaCategoria(seleccionada);
            // formulario.ShowDialog();

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!HayCategoriaSeleccionada())
            {
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Seguro que deseas eliminar la categoría?", "Eliminar categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        
            if(resultado == DialogResult.Yes)
            {
                EliminarCategoriaSeleccionada();
            }

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void EliminarCategoriaSeleccionada()
        {
            try
            {
                int id = categoriaActual.Id;
                string nombre = categoriaActual.Descripcion;

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.Eliminar(id);

                MessageBox.Show("La categoría '" + nombre + "' fue eliminada correctamente.", "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoría: " + ex.Message);
            }
        }

        // ---------- Eventos de UI ----------
        private void CargarCategoriaSeleccionada()
        {
            if(dgvCategorias.CurrentRow == null)
            {
                categoriaActual = null;
                return;
            }

            categoriaActual = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
        }

        private void MostrarGrilla(List<Categoria> lista = null)
        {
            if(lista == null)
            {
                lista = listaCategorias;
            }

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = lista;
            dgvCategorias.ClearSelection();

            OcultarColumnas();
        }

        private void LimpiarFiltros()
        {
            txtFiltroRapido.Clear();
        }

        private bool HayCategoriaSeleccionada()
        {
            if(dgvCategorias.CurrentRow == null || dgvCategorias.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No hay una categoría seleccionada. Por favor seleccione una.", "Gestionar categoría", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void OcultarColumnas()
        {
            dgvCategorias.Columns["Id"].Visible = false;
        }

        // ---------- Filtros ----------
        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> listaFiltrada;
            string filtro = txtFiltroRapido.Text;

            if (filtro.Length >= 3) // Solo filtra a partir de 3 caracteres
            {
                listaFiltrada = listaCategorias.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaCategorias;
            }

            MostrarGrilla(listaFiltrada);
        }
    }
}
