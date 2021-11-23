
namespace D2R_CLONEHUNTER
{
    partial class frmIpRangeSelector
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
            this.lblIpAddressStart = new System.Windows.Forms.Label();
            this.txtIpAddressStart = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.lblIpAddressEnd = new System.Windows.Forms.Label();
            this.txtIpAddressEnd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIpAddressStart
            // 
            this.lblIpAddressStart.AutoSize = true;
            this.lblIpAddressStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddressStart.Location = new System.Drawing.Point(16, 16);
            this.lblIpAddressStart.Name = "lblIpAddressStart";
            this.lblIpAddressStart.Size = new System.Drawing.Size(110, 17);
            this.lblIpAddressStart.TabIndex = 99;
            this.lblIpAddressStart.Text = "IP Address Start:";
            // 
            // txtIpAddressStart
            // 
            this.txtIpAddressStart.Location = new System.Drawing.Point(16, 40);
            this.txtIpAddressStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIpAddressStart.Name = "txtIpAddressStart";
            this.txtIpAddressStart.Size = new System.Drawing.Size(168, 25);
            this.txtIpAddressStart.TabIndex = 98;
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
            // lblIpAddressEnd
            // 
            this.lblIpAddressEnd.AutoSize = true;
            this.lblIpAddressEnd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddressEnd.Location = new System.Drawing.Point(192, 16);
            this.lblIpAddressEnd.Name = "lblIpAddressEnd";
            this.lblIpAddressEnd.Size = new System.Drawing.Size(104, 17);
            this.lblIpAddressEnd.TabIndex = 104;
            this.lblIpAddressEnd.Text = "IP Address End:";
            // 
            // txtIpAddressEnd
            // 
            this.txtIpAddressEnd.Location = new System.Drawing.Point(192, 40);
            this.txtIpAddressEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIpAddressEnd.Name = "txtIpAddressEnd";
            this.txtIpAddressEnd.Size = new System.Drawing.Size(168, 25);
            this.txtIpAddressEnd.TabIndex = 103;
            // 
            // frmIpRangeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 136);
            this.Controls.Add(this.lblIpAddressEnd);
            this.Controls.Add(this.txtIpAddressEnd);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.lblIpAddressStart);
            this.Controls.Add(this.txtIpAddressStart);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIpRangeSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IP Range Selector";
            this.Load += new System.EventHandler(this.frmCidrSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIpAddressStart;
        private System.Windows.Forms.TextBox txtIpAddressStart;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Label lblIpAddressEnd;
        private System.Windows.Forms.TextBox txtIpAddressEnd;
    }
}