namespace DgsTakipSistemi_DGSTS_
{
    partial class FormAna
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAna));
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnHedef = new Button();
            btnGrafik = new Button();
            btnDeneme = new Button();
            btnGunluk = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnHedef
            // 
            resources.ApplyResources(btnHedef, "btnHedef");
            btnHedef.BackColor = Color.FromArgb(180, 83, 156);
            btnHedef.ForeColor = Color.White;
            btnHedef.Name = "btnHedef";
            btnHedef.UseVisualStyleBackColor = false;
            btnHedef.Click += btnHedef_Click;
            // 
            // btnGrafik
            // 
            resources.ApplyResources(btnGrafik, "btnGrafik");
            btnGrafik.BackColor = Color.FromArgb(56, 139, 213);
            btnGrafik.ForeColor = Color.White;
            btnGrafik.Name = "btnGrafik";
            btnGrafik.UseVisualStyleBackColor = false;
            btnGrafik.Click += btnGrafik_Click;
            // 
            // btnDeneme
            // 
            resources.ApplyResources(btnDeneme, "btnDeneme");
            btnDeneme.BackColor = Color.FromArgb(208, 90, 48);
            btnDeneme.ForeColor = Color.White;
            btnDeneme.Name = "btnDeneme";
            btnDeneme.UseVisualStyleBackColor = false;
            btnDeneme.Click += btnDeneme_Click;
            // 
            // btnGunluk
            // 
            resources.ApplyResources(btnGunluk, "btnGunluk");
            btnGunluk.BackColor = Color.FromArgb(64, 158, 117);
            btnGunluk.ForeColor = Color.White;
            btnGunluk.Name = "btnGunluk";
            btnGunluk.UseVisualStyleBackColor = false;
            btnGunluk.Click += btnGunluk_Click;
            // 
            // FormAna
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(btnHedef);
            Controls.Add(btnGrafik);
            Controls.Add(btnDeneme);
            Controls.Add(btnGunluk);
            Controls.Add(flowLayoutPanel1);
            MaximizeBox = false;
            Name = "FormAna";
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnHedef;
        private Button btnGrafik;
        private Button btnDeneme;
        private Button btnGunluk;
    }
}
