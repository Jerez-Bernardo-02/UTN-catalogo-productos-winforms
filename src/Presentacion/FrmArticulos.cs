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
    public partial class FrmArticulos : Form
    {
        // ---------- Campos privados ----------
        private List<Articulo> listaArticulos;
        private List<Imagen> listaImagenes;
        private List<Categoria> listaCategorias;
        private List<Marca> listaMarcas;

        private Articulo articuloActual;
        private int indiceImagenActual;

        // ---------- Inicialización ----------
        public FrmArticulos()
        {
            InitializeComponent();
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
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
            // Articulos
            CargarListaArticulos();
            CargarListaImagenes();
            AsociarImagenesPorArticulo();

            // Filtros
            CargarListaCategorias();
            CargarListaMarcas();
            CargarFiltros();

            // IU
            CargarLabelTotalArticulos();
            CargarLabelUltimaActualizacion();
            LimpiarFiltros();
            MostrarGrilla();
        }

        // ---------- Carga de Datos ----------
        private void CargarListaArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.Listar();
        }

        private void CargarListaImagenes()
        {
            ImagenNegocio negocio = new ImagenNegocio();
            listaImagenes = negocio.Listar();
        }

        private void AsociarImagenesPorArticulo()
        {
            if (listaArticulos == null || listaImagenes == null)
            {
                return;
            }

            foreach (Articulo articulo in listaArticulos)
            {
                articulo.Imagenes = listaImagenes.FindAll(img => img.IdArticulo == articulo.Id);
            }
        }

        private void CargarListaCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            listaCategorias = negocio.Listar();

            listaCategorias.Insert(0, new Categoria { Id = 0, Descripcion = "Todas" });
        }

        private void CargarListaMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            listaMarcas = negocio.Listar();

            listaMarcas.Insert(0, new Marca { Id = 0, Descripcion = "Todas" });
        }

        private void CargarFiltros()
        {
            cbxCategorias.DataSource = listaCategorias;
            cbxCategorias.DisplayMember = "Descripcion";
            cbxCategorias.ValueMember = "Id";

            cbxMarcas.DataSource = listaMarcas;
            cbxMarcas.DisplayMember = "Descripcion";
            cbxMarcas.ValueMember = "Id";
        }

        private void CargarLabelTotalArticulos()
        {
            lblTotalArticulos.Text = "Total de artículos: " + listaArticulos.Count.ToString();
        }

        private void CargarLabelUltimaActualizacion()
        {
            lblUltimaActualización.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // ---------- Eventos Principales ----------
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            CargarArticuloSeleccionado();

            if (articuloActual == null)
            {
                return;
            }

            MostrarDetalle();
            MostrarImagen(articuloActual.Imagenes[indiceImagenActual].UrlImagen);
            ActualizarBotonesImagen();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceImagenActual <= 0)
            {
                return;
            }

            indiceImagenActual--;
            MostrarImagen(articuloActual.Imagenes[indiceImagenActual].UrlImagen);
            ActualizarBotonesImagen();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indiceImagenActual >= articuloActual.Imagenes.Count - 1)
            {
                return;
            }

            indiceImagenActual++;
            MostrarImagen(articuloActual.Imagenes[indiceImagenActual].UrlImagen);
            ActualizarBotonesImagen();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void btnActaulizarDatos_Click(object sender, EventArgs e)
        {
            CargarFormulario();
        }

        private void txtPrecioMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Evitar más de una coma o punto
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txtPrecioMinimo.Text.Contains(",") || txtPrecioMinimo.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Evitar más de una coma o punto
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txtPrecioMaximo.Text.Contains(",") || txtPrecioMaximo.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        // ---------- Eventos ABM ----------
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo formulario = new FrmAltaArticulo();

            formulario.ShowDialog();

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!HayArticuloSeleccionado())
            {
                return;
            }

            Articulo seleccionado = articuloActual;

            // TODO: Crear constructor del formulario que reciba por parametro el articulo a modificar

            // FrmAltaArticulo formulario = new FrmAltaArticulo(seleccionado);
            // formulario.ShowDialog();

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!HayArticuloSeleccionado())
            {
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Seguro que deseas eliminar el artículo?", "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                EliminarArticuloSeleccionado();
            }

            CargarFormulario(); // Se recarga el formulario sin importar de si se realizó un cambio o no
        }

        private void EliminarArticuloSeleccionado()
        {
            try
            {
                int id = articuloActual.Id;
                string nombre = articuloActual.Nombre;

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Eliminar(id);

                MessageBox.Show("El artículo '" + nombre + "' fue eliminado correctamente.", "Eliminar artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el artículo: " + ex.Message);
            }
        }

        // ---------- Eventos de UI ----------
        private void CargarArticuloSeleccionado()
        {
            if (dgvArticulos.CurrentRow == null)
            {
                articuloActual = null;
                return;
            }

            articuloActual = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            indiceImagenActual = 0;
        }

        private void MostrarGrilla(List<Articulo> lista = null)
        {
            if (lista == null)
            {
                lista = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = lista;
            dgvArticulos.ClearSelection();

            OcultarColumnas();
        }

        private void MostrarDetalle()
        {
            if (articuloActual == null)
            {
                return;
            }

            lblNombre.Text = articuloActual.Nombre;
            lblPrecio.Text = "AR$ " + articuloActual.Precio.ToString("N2");
            txtDescripcion.Text = articuloActual.Descripcion;
        }

        private void MostrarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
                // Si la URL es inválida, el sistema espera a que el
                // request HTTP falle (timeout) y recien ahi pasa al catch
            }
            catch
            {
                pbxImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void ActualizarBotonesImagen()
        {
            if (articuloActual.Imagenes == null || articuloActual.Imagenes.Count <= 1)
            {
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = false;
                return;
            }

            btnAnterior.Enabled = indiceImagenActual > 0;
            btnSiguiente.Enabled = indiceImagenActual < articuloActual.Imagenes.Count - 1;

            dgvArticulos.Focus(); // Evita que al cambiar de imagen se seleccione el control "txtDescripcion"
        }

        private void OcultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Precio"].Visible = false;
        }

        private void LimpiarFiltros()
        {
            cbxCategorias.SelectedIndex = 0;
            cbxMarcas.SelectedIndex = 0;
            txtFiltroRapido.Clear();
            txtPrecioMinimo.Clear();
            txtPrecioMaximo.Clear();

            MostrarGrilla();
        }

        private bool HayArticuloSeleccionado()
        {
            if (dgvArticulos.CurrentRow == null || dgvArticulos.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No hay un artículo seleccionado. Por favor seleccione uno.", "Modificar artículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // ---------- Filtros ----------
        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltroRapido.Text;

            if (filtro.Length >= 3) // Solo filtra a partir de 3 caracteres
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            MostrarGrilla(listaFiltrada);
        }

        private void filtroAvanzado()
        {
            List<Articulo> listaFiltrada = listaArticulos;

            if (cbxCategorias.SelectedIndex > 0)
            {
                int idCategoria = (int)cbxCategorias.SelectedValue;
                listaFiltrada = listaFiltrada.FindAll(x => x.Categoria.Id == idCategoria);
            }

            if (cbxMarcas.SelectedIndex > 0)
            {
                int idMarca = (int)cbxMarcas.SelectedValue;
                listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == idMarca);
            }

            if (!string.IsNullOrEmpty(txtPrecioMinimo.Text))
            {
                decimal precioMinimo = decimal.Parse(txtPrecioMinimo.Text);
                listaFiltrada = listaFiltrada.FindAll(x => x.Precio >= precioMinimo);
            }

            if (!string.IsNullOrEmpty(txtPrecioMaximo.Text))
            {
                decimal precioMaximo = decimal.Parse(txtPrecioMaximo.Text);
                listaFiltrada = listaFiltrada.FindAll(x => x.Precio <= precioMaximo);
            }

            MostrarGrilla(listaFiltrada);
        }

        private void cbxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroAvanzado();
        }

        private void cbxMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroAvanzado();
        }

        private void txtPrecioMinimo_TextChanged(object sender, EventArgs e)
        {
            filtroAvanzado();
        }

        private void txtPrecioMaximo_TextChanged(object sender, EventArgs e)
        {
            filtroAvanzado();
        }
    }
}
