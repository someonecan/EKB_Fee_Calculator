
namespace EKB_Fee_Calculator
{
    partial class Form1
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
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.txtReferenceValue = new System.Windows.Forms.TextBox();
            this.btnSetReferenceValue = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(140, 114);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(189, 112);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "excel yükle";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // txtReferenceValue
            // 
            this.txtReferenceValue.Location = new System.Drawing.Point(186, 58);
            this.txtReferenceValue.Name = "txtReferenceValue";
            this.txtReferenceValue.Size = new System.Drawing.Size(100, 20);
            this.txtReferenceValue.TabIndex = 1;
            // 
            // btnSetReferenceValue
            // 
            this.btnSetReferenceValue.Location = new System.Drawing.Point(140, 232);
            this.btnSetReferenceValue.Name = "btnSetReferenceValue";
            this.btnSetReferenceValue.Size = new System.Drawing.Size(189, 123);
            this.btnSetReferenceValue.TabIndex = 2;
            this.btnSetReferenceValue.Text = "referans değer ayarla";
            this.btnSetReferenceValue.UseVisualStyleBackColor = true;
            this.btnSetReferenceValue.Click += new System.EventHandler(this.btnSetReferenceValue_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(27, 321);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(35, 13);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 436);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnSetReferenceValue);
            this.Controls.Add(this.txtReferenceValue);
            this.Controls.Add(this.btnLoadExcel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.TextBox txtReferenceValue;
        private System.Windows.Forms.Button btnSetReferenceValue;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}

