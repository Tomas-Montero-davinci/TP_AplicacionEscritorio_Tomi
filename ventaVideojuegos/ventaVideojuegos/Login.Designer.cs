namespace ventaVideojuegos
{
    partial class Login
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
            this.txtContrasenaLogin = new System.Windows.Forms.TextBox();
            this.txtUsuarioLogin = new System.Windows.Forms.TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.errLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.bttnAcceder = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContrasenaLogin
            // 
            this.txtContrasenaLogin.Location = new System.Drawing.Point(137, 174);
            this.txtContrasenaLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContrasenaLogin.Name = "txtContrasenaLogin";
            this.txtContrasenaLogin.Size = new System.Drawing.Size(163, 22);
            this.txtContrasenaLogin.TabIndex = 9;
            this.txtContrasenaLogin.UseSystemPasswordChar = true;
            // 
            // txtUsuarioLogin
            // 
            this.txtUsuarioLogin.Location = new System.Drawing.Point(137, 114);
            this.txtUsuarioLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuarioLogin.Name = "txtUsuarioLogin";
            this.txtUsuarioLogin.Size = new System.Drawing.Size(163, 22);
            this.txtUsuarioLogin.TabIndex = 8;
            this.txtUsuarioLogin.TextChanged += new System.EventHandler(this.txtUsuarioLogin_TextChanged);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.bttnAcceder);
            this.guna2GradientPanel1.Controls.Add(this.errLogin);
            this.guna2GradientPanel1.Controls.Add(this.txtContrasenaLogin);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel4);
            this.guna2GradientPanel1.Controls.Add(this.txtUsuarioLogin);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Teal;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightCyan;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(403, 337);
            this.guna2GradientPanel1.TabIndex = 12;
            // 
            // errLogin
            // 
            this.errLogin.BackColor = System.Drawing.Color.Transparent;
            this.errLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errLogin.ForeColor = System.Drawing.Color.Red;
            this.errLogin.Location = new System.Drawing.Point(33, 233);
            this.errLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.errLogin.Name = "errLogin";
            this.errLogin.Size = new System.Drawing.Size(181, 22);
            this.errLogin.TabIndex = 10;
            this.errLogin.Text = "Credenciales invalidas";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(33, 174);
            this.guna2HtmlLabel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(86, 22);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "Contraseña";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(64, 114);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(58, 22);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Usuario";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(145, 82);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(130, 22);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Ingrese sus datos";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(145, 26);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(130, 31);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Bienvenido!";
            // 
            // bttnAcceder
            // 
            this.bttnAcceder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bttnAcceder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bttnAcceder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bttnAcceder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bttnAcceder.FillColor = System.Drawing.Color.White;
            this.bttnAcceder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bttnAcceder.ForeColor = System.Drawing.Color.Black;
            this.bttnAcceder.Location = new System.Drawing.Point(120, 272);
            this.bttnAcceder.Name = "bttnAcceder";
            this.bttnAcceder.Size = new System.Drawing.Size(180, 34);
            this.bttnAcceder.TabIndex = 11;
            this.bttnAcceder.Text = "Iniciar Sesión";
            this.bttnAcceder.Click += new System.EventHandler(this.bttnAcceder_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 334);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtContrasenaLogin;
        private System.Windows.Forms.TextBox txtUsuarioLogin;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel errLogin;
        private Guna.UI2.WinForms.Guna2Button bttnAcceder;
    }
}