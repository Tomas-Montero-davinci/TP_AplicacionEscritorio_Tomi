namespace ventaVideojuegos
{
    partial class VerDetalles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewV = new System.Windows.Forms.DataGridView();
            this.produc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrarDetails = new System.Windows.Forms.Button();
            this.lblVenta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewV
            // 
            this.dataGridViewV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewV.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.produc,
            this.precio,
            this.cant,
            this.valor});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewV.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewV.EnableHeadersVisualStyles = false;
            this.dataGridViewV.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewV.Location = new System.Drawing.Point(18, 55);
            this.dataGridViewV.Name = "dataGridViewV";
            this.dataGridViewV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewV.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridViewV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewV.Size = new System.Drawing.Size(352, 241);
            this.dataGridViewV.TabIndex = 32;
            // 
            // produc
            // 
            this.produc.HeaderText = "Producto";
            this.produc.Name = "produc";
            this.produc.Width = 74;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.Width = 61;
            // 
            // cant
            // 
            this.cant.HeaderText = "Cantidad";
            this.cant.Name = "cant";
            this.cant.Width = 73;
            // 
            // valor
            // 
            this.valor.HeaderText = "Total";
            this.valor.Name = "valor";
            this.valor.Width = 55;
            // 
            // btnCerrarDetails
            // 
            this.btnCerrarDetails.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCerrarDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrarDetails.Location = new System.Drawing.Point(261, 302);
            this.btnCerrarDetails.Name = "btnCerrarDetails";
            this.btnCerrarDetails.Size = new System.Drawing.Size(100, 26);
            this.btnCerrarDetails.TabIndex = 33;
            this.btnCerrarDetails.Text = "Cerrar";
            this.btnCerrarDetails.UseVisualStyleBackColor = false;
            this.btnCerrarDetails.Click += new System.EventHandler(this.btnCerrarDetails_Click);
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = false;
            this.lblVenta.BackColor = System.Drawing.Color.Transparent;
            this.lblVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVenta.Location = new System.Drawing.Point(93, 17);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(162, 32);
            this.lblVenta.TabIndex = 34;
            this.lblVenta.Text = "Venta";
            this.lblVenta.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VerDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(382, 343);
            this.Controls.Add(this.lblVenta);
            this.Controls.Add(this.btnCerrarDetails);
            this.Controls.Add(this.dataGridViewV);
            this.Name = "VerDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ver detalles de pedido";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewV;
        private System.Windows.Forms.DataGridViewTextBoxColumn produc;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.Button btnCerrarDetails;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVenta;
    }
}