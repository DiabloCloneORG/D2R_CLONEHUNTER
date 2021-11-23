
namespace D2R_CLONEHUNTER
{
    partial class frmCidrSelector
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
            this.lblCidrClass = new System.Windows.Forms.Label();
            this.ddCidrClass = new System.Windows.Forms.ComboBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCidrClass
            // 
            this.lblCidrClass.AutoSize = true;
            this.lblCidrClass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCidrClass.Location = new System.Drawing.Point(216, 16);
            this.lblCidrClass.Name = "lblCidrClass";
            this.lblCidrClass.Size = new System.Drawing.Size(90, 17);
            this.lblCidrClass.TabIndex = 101;
            this.lblCidrClass.Text = "Subnet Class:";
            // 
            // ddCidrClass
            // 
            this.ddCidrClass.FormattingEnabled = true;
            this.ddCidrClass.Items.AddRange(new object[] {
            "/0",
            "/1",
            "/2",
            "/3",
            "/4",
            "/5",
            "/6",
            "/7",
            "/8",
            "/9",
            "/10",
            "/11",
            "/12",
            "/13",
            "/14",
            "/15",
            "/16",
            "/17",
            "/18",
            "/19",
            "/20",
            "/21",
            "/22",
            "/23",
            "/24",
            "/25",
            "/26",
            "/27",
            "/28",
            "/29",
            "/30",
            "/31",
            "/32"});
            this.ddCidrClass.Location = new System.Drawing.Point(216, 40);
            this.ddCidrClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddCidrClass.Name = "ddCidrClass";
            this.ddCidrClass.Size = new System.Drawing.Size(152, 25);
            this.ddCidrClass.TabIndex = 100;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(16, 16);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(77, 17);
            this.lblIpAddress.TabIndex = 99;
            this.lblIpAddress.Text = "IP Address:";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(16, 40);
            this.txtIpAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(192, 25);
            this.txtIpAddress.TabIndex = 98;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(280, 88);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 32);
            this.btnOK.TabIndex = 97;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCANCEL.Location = new System.Drawing.Point(184, 88);
            this.btnCANCEL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(89, 32);
            this.btnCANCEL.TabIndex = 102;
            this.btnCANCEL.Text = "CANCEL";
            this.btnCANCEL.UseVisualStyleBackColor = true;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // frmCidrSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 136);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.lblCidrClass);
            this.Controls.Add(this.ddCidrClass);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCidrSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CIDR Selector";
            this.Load += new System.EventHandler(this.frmCidrSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCidrClass;
        private System.Windows.Forms.ComboBox ddCidrClass;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCANCEL;
    }
}