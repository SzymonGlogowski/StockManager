namespace StockManager
{
    partial class IndicatorIntervalConfigUltimate
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
            this.txtInterval1 = new System.Windows.Forms.TextBox();
            this.lblInterval1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtInterval2 = new System.Windows.Forms.TextBox();
            this.txtInterval3 = new System.Windows.Forms.TextBox();
            this.lblInterval2 = new System.Windows.Forms.Label();
            this.lblInterval3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInterval1
            // 
            this.txtInterval1.Location = new System.Drawing.Point(67, 6);
            this.txtInterval1.Name = "txtInterval1";
            this.txtInterval1.Size = new System.Drawing.Size(95, 20);
            this.txtInterval1.TabIndex = 5;
            // 
            // lblInterval1
            // 
            this.lblInterval1.AutoSize = true;
            this.lblInterval1.Location = new System.Drawing.Point(6, 9);
            this.lblInterval1.Name = "lblInterval1";
            this.lblInterval1.Size = new System.Drawing.Size(54, 13);
            this.lblInterval1.TabIndex = 4;
            this.lblInterval1.Text = "Interval 1:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(67, 84);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 25);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtInterval2
            // 
            this.txtInterval2.Location = new System.Drawing.Point(67, 32);
            this.txtInterval2.Name = "txtInterval2";
            this.txtInterval2.Size = new System.Drawing.Size(95, 20);
            this.txtInterval2.TabIndex = 6;
            // 
            // txtInterval3
            // 
            this.txtInterval3.Location = new System.Drawing.Point(67, 58);
            this.txtInterval3.Name = "txtInterval3";
            this.txtInterval3.Size = new System.Drawing.Size(95, 20);
            this.txtInterval3.TabIndex = 7;
            // 
            // lblInterval2
            // 
            this.lblInterval2.AutoSize = true;
            this.lblInterval2.Location = new System.Drawing.Point(6, 35);
            this.lblInterval2.Name = "lblInterval2";
            this.lblInterval2.Size = new System.Drawing.Size(54, 13);
            this.lblInterval2.TabIndex = 8;
            this.lblInterval2.Text = "Interval 2:";
            // 
            // lblInterval3
            // 
            this.lblInterval3.AutoSize = true;
            this.lblInterval3.Location = new System.Drawing.Point(6, 61);
            this.lblInterval3.Name = "lblInterval3";
            this.lblInterval3.Size = new System.Drawing.Size(54, 13);
            this.lblInterval3.TabIndex = 9;
            this.lblInterval3.Text = "Interval 3:";
            // 
            // IndicatorIntervalConfigUltimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 114);
            this.Controls.Add(this.lblInterval3);
            this.Controls.Add(this.lblInterval2);
            this.Controls.Add(this.txtInterval3);
            this.Controls.Add(this.txtInterval2);
            this.Controls.Add(this.txtInterval1);
            this.Controls.Add(this.lblInterval1);
            this.Controls.Add(this.btnApply);
            this.MaximumSize = new System.Drawing.Size(185, 153);
            this.MinimumSize = new System.Drawing.Size(185, 153);
            this.Name = "IndicatorIntervalConfigUltimate";
            this.Text = "IndicatorIntervalConfigUltimate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndicatorIntervalConfigUltimate_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInterval1;
        private System.Windows.Forms.Label lblInterval1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtInterval2;
        private System.Windows.Forms.TextBox txtInterval3;
        private System.Windows.Forms.Label lblInterval2;
        private System.Windows.Forms.Label lblInterval3;
    }
}