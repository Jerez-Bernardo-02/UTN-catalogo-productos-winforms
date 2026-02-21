namespace Presentacion
{
    partial class FrmMarcas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxCategorias = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtFiltroRapido = new System.Windows.Forms.TextBox();
            this.gbxCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCategorias
            // 
            this.gbxCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbxCategorias.Controls.Add(this.btnEliminar);
            this.gbxCategorias.Controls.Add(this.dgvMarcas);
            this.gbxCategorias.Controls.Add(this.btnModificar);
            this.gbxCategorias.Controls.Add(this.lblFiltro);
            this.gbxCategorias.Controls.Add(this.btnAgregar);
            this.gbxCategorias.Controls.Add(this.txtFiltroRapido);
            this.gbxCategorias.Location = new System.Drawing.Point(12, 12);
            this.gbxCategorias.Name = "gbxCategorias";
            this.gbxCategorias.Size = new System.Drawing.Size(391, 404);
            this.gbxCategorias.TabIndex = 0;
            this.gbxCategorias.TabStop = false;
            this.gbxCategorias.Text = "Listado de Marcas";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(248, 344);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 35);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMarcas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.ColumnHeadersVisible = false;
            this.dgvMarcas.Location = new System.Drawing.Point(28, 88);
            this.dgvMarcas.MultiSelect = false;
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.RowHeadersVisible = false;
            this.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarcas.Size = new System.Drawing.Size(329, 234);
            this.dgvMarcas.TabIndex = 5;
            this.dgvMarcas.SelectionChanged += new System.EventHandler(this.dgvMarcas_SelectionChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(29, 344);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(110, 35);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(25, 33);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(40, 13);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Buscar";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(248, 34);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(110, 35);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtFiltroRapido
            // 
            this.txtFiltroRapido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroRapido.Location = new System.Drawing.Point(28, 49);
            this.txtFiltroRapido.Name = "txtFiltroRapido";
            this.txtFiltroRapido.Size = new System.Drawing.Size(188, 20);
            this.txtFiltroRapido.TabIndex = 3;
            this.txtFiltroRapido.TextChanged += new System.EventHandler(this.txtFiltroRapido_TextChanged);
            // 
            // FrmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 428);
            this.Controls.Add(this.gbxCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marcas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMarcas_Load);
            this.gbxCategorias.ResumeLayout(false);
            this.gbxCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCategorias;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtFiltroRapido;
    }
}