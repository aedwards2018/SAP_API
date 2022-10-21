namespace SAP_API
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_refrescar = new System.Windows.Forms.Button();
            this.bnt_aplicar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LstLinea = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_selecionar = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_refrescar);
            this.panel1.Controls.Add(this.bnt_aplicar);
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Location = new System.Drawing.Point(931, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 97);
            this.panel1.TabIndex = 6;
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refrescar.Image = ((System.Drawing.Image)(resources.GetObject("btn_refrescar.Image")));
            this.btn_refrescar.Location = new System.Drawing.Point(124, 3);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(86, 91);
            this.btn_refrescar.TabIndex = 6;
            this.btn_refrescar.Text = "&Refrescar";
            this.btn_refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_refrescar.UseVisualStyleBackColor = true;
            this.btn_refrescar.Click += new System.EventHandler(this.btn_refrescar_Click);
            // 
            // bnt_aplicar
            // 
            this.bnt_aplicar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_aplicar.Image = ((System.Drawing.Image)(resources.GetObject("bnt_aplicar.Image")));
            this.bnt_aplicar.Location = new System.Drawing.Point(21, 3);
            this.bnt_aplicar.Name = "bnt_aplicar";
            this.bnt_aplicar.Size = new System.Drawing.Size(97, 91);
            this.bnt_aplicar.TabIndex = 5;
            this.bnt_aplicar.Text = "&Procesar";
            this.bnt_aplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bnt_aplicar.UseVisualStyleBackColor = true;
            this.bnt_aplicar.Click += new System.EventHandler(this.bnt_aplicar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.Location = new System.Drawing.Point(216, 3);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(87, 91);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LstLinea);
            this.panel2.Location = new System.Drawing.Point(12, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1240, 502);
            this.panel2.TabIndex = 7;
            // 
            // LstLinea
            // 
            this.LstLinea.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.LstLinea.AllowColumnReorder = true;
            this.LstLinea.AllowDrop = true;
            this.LstLinea.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LstLinea.CheckBoxes = true;
            this.LstLinea.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstLinea.FullRowSelect = true;
            this.LstLinea.GridLines = true;
            this.LstLinea.HideSelection = false;
            this.LstLinea.HoverSelection = true;
            this.LstLinea.Location = new System.Drawing.Point(15, 9);
            this.LstLinea.Name = "LstLinea";
            this.LstLinea.ShowItemToolTips = true;
            this.LstLinea.Size = new System.Drawing.Size(1210, 483);
            this.LstLinea.TabIndex = 6;
            this.LstLinea.UseCompatibleStateImageBehavior = false;
            this.LstLinea.View = System.Windows.Forms.View.Details;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(12, 538);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 77);
            this.panel3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btn_selecionar
            // 
            this.btn_selecionar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selecionar.Location = new System.Drawing.Point(12, 4);
            this.btn_selecionar.Name = "btn_selecionar";
            this.btn_selecionar.Size = new System.Drawing.Size(167, 23);
            this.btn_selecionar.TabIndex = 9;
            this.btn_selecionar.Text = "Seleccionar Todos";
            this.btn_selecionar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_selecionar.UseVisualStyleBackColor = true;
            this.btn_selecionar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_version.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_version.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_version.Location = new System.Drawing.Point(169, 597);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(233, 18);
            this.lbl_version.TabIndex = 10;
            this.lbl_version.Text = "Versión  Octubre.13.2022";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(419, 605);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 573);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 12;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1261, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btn_selecionar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.Text = "Interface Uber";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView LstLinea;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_selecionar;
        private System.Windows.Forms.Button bnt_aplicar;
        private System.Windows.Forms.Button btn_refrescar;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}

