namespace Exam1
{
    partial class AddRegistrationForm
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
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.nudNoOfPasses = new System.Windows.Forms.NumericUpDown();
            this.cbAccessPackage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfPasses)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(194, 110);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(271, 22);
            this.tbCompanyName.TabIndex = 0;
            // 
            // nudNoOfPasses
            // 
            this.nudNoOfPasses.Location = new System.Drawing.Point(194, 153);
            this.nudNoOfPasses.Name = "nudNoOfPasses";
            this.nudNoOfPasses.Size = new System.Drawing.Size(271, 22);
            this.nudNoOfPasses.TabIndex = 1;
            // 
            // cbAccessPackage
            // 
            this.cbAccessPackage.FormattingEnabled = true;
            this.cbAccessPackage.Location = new System.Drawing.Point(194, 198);
            this.cbAccessPackage.Name = "cbAccessPackage";
            this.cbAccessPackage.Size = new System.Drawing.Size(271, 24);
            this.cbAccessPackage.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Passes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Access Package";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(100, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAccessPackage);
            this.Controls.Add(this.nudNoOfPasses);
            this.Controls.Add(this.tbCompanyName);
            this.Name = "AddRegistrationForm";
            this.Text = "AddRegistrationForm";
            this.Load += new System.EventHandler(this.AddRegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfPasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.NumericUpDown nudNoOfPasses;
        private System.Windows.Forms.ComboBox cbAccessPackage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
    }
}