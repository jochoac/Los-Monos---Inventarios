namespace VistaLM
{
    partial class Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Caja_telefono = new System.Windows.Forms.TextBox();
            this.Caja_correo = new System.Windows.Forms.TextBox();
            this.Combo_Estado = new System.Windows.Forms.ComboBox();
            this.Caja_ID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Combo_cargo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Caja_Empleado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Caja_Usu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(727, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 54);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(256, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 69);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(337, 42);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(384, 366);
            this.dataGrid.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(98, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 19);
            this.label11.TabIndex = 84;
            this.label11.Text = "Teléfono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 83;
            this.label1.Text = "Correo";
            // 
            // Caja_telefono
            // 
            this.Caja_telefono.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Caja_telefono.Location = new System.Drawing.Point(177, 247);
            this.Caja_telefono.MaxLength = 10;
            this.Caja_telefono.Name = "Caja_telefono";
            this.Caja_telefono.Size = new System.Drawing.Size(154, 27);
            this.Caja_telefono.TabIndex = 82;
            // 
            // Caja_correo
            // 
            this.Caja_correo.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Caja_correo.Location = new System.Drawing.Point(177, 214);
            this.Caja_correo.Name = "Caja_correo";
            this.Caja_correo.Size = new System.Drawing.Size(154, 27);
            this.Caja_correo.TabIndex = 81;
            // 
            // Combo_Estado
            // 
            this.Combo_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Estado.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_Estado.FormattingEnabled = true;
            this.Combo_Estado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.Combo_Estado.Location = new System.Drawing.Point(177, 82);
            this.Combo_Estado.Name = "Combo_Estado";
            this.Combo_Estado.Size = new System.Drawing.Size(154, 27);
            this.Combo_Estado.TabIndex = 80;
            // 
            // Caja_ID
            // 
            this.Caja_ID.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Caja_ID.Location = new System.Drawing.Point(177, 148);
            this.Caja_ID.MaxLength = 15;
            this.Caja_ID.Name = "Caja_ID";
            this.Caja_ID.Size = new System.Drawing.Size(154, 27);
            this.Caja_ID.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 78;
            this.label7.Text = "ID usuario";
            // 
            // Combo_cargo
            // 
            this.Combo_cargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_cargo.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_cargo.FormattingEnabled = true;
            this.Combo_cargo.Items.AddRange(new object[] {
            "Administrador",
            "Empleado"});
            this.Combo_cargo.Location = new System.Drawing.Point(177, 181);
            this.Combo_cargo.Name = "Combo_cargo";
            this.Combo_cargo.Size = new System.Drawing.Size(154, 27);
            this.Combo_cargo.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 76;
            this.label6.Text = "Cargo";
            // 
            // Caja_Empleado
            // 
            this.Caja_Empleado.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Caja_Empleado.Location = new System.Drawing.Point(177, 115);
            this.Caja_Empleado.Name = "Caja_Empleado";
            this.Caja_Empleado.Size = new System.Drawing.Size(154, 27);
            this.Caja_Empleado.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 74;
            this.label5.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 19);
            this.label3.TabIndex = 73;
            this.label3.Text = "Nombre empleado";
            // 
            // Caja_Usu
            // 
            this.Caja_Usu.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Caja_Usu.Location = new System.Drawing.Point(177, 49);
            this.Caja_Usu.MaxLength = 30;
            this.Caja_Usu.Name = "Caja_Usu";
            this.Caja_Usu.Size = new System.Drawing.Size(154, 27);
            this.Caja_Usu.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 71;
            this.label2.Text = "Nombre cuenta";
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 419);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Caja_telefono);
            this.Controls.Add(this.Caja_correo);
            this.Controls.Add(this.Combo_Estado);
            this.Controls.Add(this.Caja_ID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Combo_cargo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Caja_Empleado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Caja_Usu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Usuarios_FormClosing);
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Caja_telefono;
        private System.Windows.Forms.TextBox Caja_correo;
        private System.Windows.Forms.ComboBox Combo_Estado;
        private System.Windows.Forms.TextBox Caja_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Combo_cargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Caja_Empleado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Caja_Usu;
        private System.Windows.Forms.Label label2;
    }
}