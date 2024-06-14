namespace ModelRo
{
    partial class AddSmartphonesForm
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
            this.components = new System.ComponentModel.Container();
            this.nudId = new System.Windows.Forms.NumericUpDown();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.nudUnits = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbProd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nudId
            // 
            this.nudId.Location = new System.Drawing.Point(203, 92);
            this.nudId.Name = "nudId";
            this.nudId.Size = new System.Drawing.Size(285, 22);
            this.nudId.TabIndex = 0;
            this.nudId.Validating += new System.ComponentModel.CancelEventHandler(this.nudId_Validating);
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(203, 136);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(285, 22);
            this.tbModel.TabIndex = 1;
            this.tbModel.Validating += new System.ComponentModel.CancelEventHandler(this.tbModel_Validating);
            // 
            // nudUnits
            // 
            this.nudUnits.Location = new System.Drawing.Point(203, 181);
            this.nudUnits.Name = "nudUnits";
            this.nudUnits.Size = new System.Drawing.Size(285, 22);
            this.nudUnits.TabIndex = 2;
            this.nudUnits.Validating += new System.ComponentModel.CancelEventHandler(this.nudUnits_Validating);
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPrice.Location = new System.Drawing.Point(203, 229);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(285, 22);
            this.nudPrice.TabIndex = 3;
            this.nudPrice.Validating += new System.ComponentModel.CancelEventHandler(this.nudPrice_Validating);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(203, 274);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(285, 22);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDate_Validating);
            // 
            // cbProd
            // 
            this.cbProd.FormattingEnabled = true;
            this.cbProd.Location = new System.Drawing.Point(203, 326);
            this.cbProd.Name = "cbProd";
            this.cbProd.Size = new System.Drawing.Size(285, 24);
            this.cbProd.TabIndex = 5;
            this.cbProd.Validating += new System.ComponentModel.CancelEventHandler(this.cbProd_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Available Units";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Release Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Producer";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(178, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(404, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddSmartphonesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProd);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudUnits);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.nudId);
            this.Name = "AddSmartphonesForm";
            this.Text = "AddSmartphonesForm";
          
            ((System.ComponentModel.ISupportInitialize)(this.nudId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudId;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.NumericUpDown nudUnits;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}