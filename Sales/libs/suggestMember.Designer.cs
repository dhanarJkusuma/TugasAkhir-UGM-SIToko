﻿namespace Sales.libs
{
    partial class suggestMember
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
            this.memberGrid = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rName = new System.Windows.Forms.RadioButton();
            this.rID = new System.Windows.Forms.RadioButton();
            this.tBindGrid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.memberGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memberGrid
            // 
            this.memberGrid.AllowUserToAddRows = false;
            this.memberGrid.AllowUserToDeleteRows = false;
            this.memberGrid.AllowUserToResizeColumns = false;
            this.memberGrid.AllowUserToResizeRows = false;
            this.memberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memberGrid.Location = new System.Drawing.Point(12, 70);
            this.memberGrid.MultiSelect = false;
            this.memberGrid.Name = "memberGrid";
            this.memberGrid.RowHeadersVisible = false;
            this.memberGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.memberGrid.Size = new System.Drawing.Size(376, 383);
            this.memberGrid.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 460);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(119, 47);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 47);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rName);
            this.groupBox1.Controls.Add(this.rID);
            this.groupBox1.Controls.Add(this.tBindGrid);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 52);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By";
            // 
            // rName
            // 
            this.rName.AutoSize = true;
            this.rName.Location = new System.Drawing.Point(302, 19);
            this.rName.Name = "rName";
            this.rName.Size = new System.Drawing.Size(53, 17);
            this.rName.TabIndex = 7;
            this.rName.TabStop = true;
            this.rName.Text = "Name";
            this.rName.UseVisualStyleBackColor = true;
            // 
            // rID
            // 
            this.rID.AutoSize = true;
            this.rID.Location = new System.Drawing.Point(260, 19);
            this.rID.Name = "rID";
            this.rID.Size = new System.Drawing.Size(36, 17);
            this.rID.TabIndex = 7;
            this.rID.TabStop = true;
            this.rID.Text = "ID";
            this.rID.UseVisualStyleBackColor = true;
            // 
            // tBindGrid
            // 
            this.tBindGrid.Location = new System.Drawing.Point(20, 16);
            this.tBindGrid.Name = "tBindGrid";
            this.tBindGrid.Size = new System.Drawing.Size(224, 20);
            this.tBindGrid.TabIndex = 4;
            this.tBindGrid.TextChanged += new System.EventHandler(this.tBindGrid_TextChanged);
            this.tBindGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBindGrid_KeyPress);
            // 
            // suggestMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.memberGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "suggestMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "suggestMember";
            ((System.ComponentModel.ISupportInitialize)(this.memberGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView memberGrid;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rName;
        private System.Windows.Forms.RadioButton rID;
        private System.Windows.Forms.TextBox tBindGrid;
    }
}