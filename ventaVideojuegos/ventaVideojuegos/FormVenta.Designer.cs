namespace ventaVideojuegos
{
    partial class FormVenta
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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarProducto = new Guna.UI2.WinForms.Guna2Button();
            this.errCantidad = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(26, 52);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(141, 13);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Ingrese la cantidad deseada";
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(214, 45);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(43, 20);
            this.numCantidad.TabIndex = 1;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarProducto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregarProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregarProducto.FillColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarProducto.Location = new System.Drawing.Point(70, 117);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(141, 30);
            this.btnAgregarProducto.TabIndex = 9;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // errCantidad
            // 
            this.errCantidad.BackColor = System.Drawing.Color.Transparent;
            this.errCantidad.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errCantidad.ForeColor = System.Drawing.Color.Red;
            this.errCantidad.Location = new System.Drawing.Point(29, 68);
            this.errCantidad.Name = "errCantidad";
            this.errCantidad.Size = new System.Drawing.Size(182, 17);
            this.errCantidad.TabIndex = 34;
            this.errCantidad.Text = "Debe ingresar la cantidad deseada";
            // 
            // FormVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 175);
            this.Controls.Add(this.errCantidad);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Name = "FormVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private Guna.UI2.WinForms.Guna2Button btnAgregarProducto;
        private Guna.UI2.WinForms.Guna2HtmlLabel errCantidad;
    }
}