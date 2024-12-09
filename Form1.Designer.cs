namespace _046_tolentino_agustin_F1
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
            this.btnDep = new System.Windows.Forms.Button();
            this.btnEmp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDep
            // 
            this.btnDep.Location = new System.Drawing.Point(12, 12);
            this.btnDep.Name = "btnDep";
            this.btnDep.Size = new System.Drawing.Size(75, 59);
            this.btnDep.TabIndex = 0;
            this.btnDep.Text = "Department";
            this.btnDep.UseVisualStyleBackColor = true;
            this.btnDep.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEmp
            // 
            this.btnEmp.Location = new System.Drawing.Point(103, 12);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(75, 59);
            this.btnEmp.TabIndex = 1;
            this.btnEmp.Text = "Employee";
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 86);
            this.Controls.Add(this.btnEmp);
            this.Controls.Add(this.btnDep);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDep;
        private System.Windows.Forms.Button btnEmp;
    }
}

