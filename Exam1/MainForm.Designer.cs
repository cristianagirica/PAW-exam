namespace Exam1
{
    partial class MainForm
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
            this.btnAddRegistration = new System.Windows.Forms.Button();
            this.lvRegistrations = new System.Windows.Forms.ListView();
            this.colCompanyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNoOfPasses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAccessPackageId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRegistration
            // 
            this.btnAddRegistration.Location = new System.Drawing.Point(258, 114);
            this.btnAddRegistration.Name = "btnAddRegistration";
            this.btnAddRegistration.Size = new System.Drawing.Size(255, 49);
            this.btnAddRegistration.TabIndex = 0;
            this.btnAddRegistration.Text = "Add Registration";
            this.btnAddRegistration.UseVisualStyleBackColor = true;
            this.btnAddRegistration.Click += new System.EventHandler(this.btnAddRegistration_Click);
            // 
            // lvRegistrations
            // 
            this.lvRegistrations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompanyName,
            this.colNoOfPasses,
            this.colAccessPackageId});
            this.lvRegistrations.ContextMenuStrip = this.contextMenuStrip1;
            this.lvRegistrations.HideSelection = false;
            this.lvRegistrations.Location = new System.Drawing.Point(40, 231);
            this.lvRegistrations.Name = "lvRegistrations";
            this.lvRegistrations.Size = new System.Drawing.Size(710, 189);
            this.lvRegistrations.TabIndex = 1;
            this.lvRegistrations.UseCompatibleStateImageBehavior = false;
            this.lvRegistrations.View = System.Windows.Forms.View.Details;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Text = "Company Name";
            this.colCompanyName.Width = 291;
            // 
            // colNoOfPasses
            // 
            this.colNoOfPasses.Text = "Number of Passes";
            this.colNoOfPasses.Width = 218;
            // 
            // colAccessPackageId
            // 
            this.colAccessPackageId.Text = "Access Package Id";
            this.colAccessPackageId.Width = 166;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 52);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // cbSortBy
            // 
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Items.AddRange(new object[] {
            "Access Package",
            "Company Name"});
            this.cbSortBy.Location = new System.Drawing.Point(40, 192);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(132, 24);
            this.cbSortBy.TabIndex = 4;
            this.cbSortBy.Text = "Sort By";
            this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvRegistrations);
            this.Controls.Add(this.btnAddRegistration);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRegistration;
        private System.Windows.Forms.ListView lvRegistrations;
        private System.Windows.Forms.ColumnHeader colCompanyName;
        private System.Windows.Forms.ColumnHeader colNoOfPasses;
        private System.Windows.Forms.ColumnHeader colAccessPackageId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox cbSortBy;
    }
}

