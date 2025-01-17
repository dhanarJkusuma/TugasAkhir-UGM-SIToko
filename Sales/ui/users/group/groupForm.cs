﻿using Sales.libs;
using Sales.model;
using Sales.ui.users.group.processForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales.ui.users.group
{
    public partial class groupForm : Form
    {
        public groupForm()
        {
            InitializeComponent();
            refreshData();
            setMenu();
        }

        public void refreshData() 
        {
            groupGrid.DataSource = Group.All();
            groupGrid.ReadOnly = true;
            groupGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            groupGrid.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupNew newForm = new groupNew(this);
            Helper.Forms.startForm(newForm);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (groupGrid.SelectedRows.Count == 1) 
            {
                groupEdit editForm = new groupEdit(this);
                editForm.CurrentGroup = Group.Find(groupGrid.SelectedRows[0].Cells[0].Value.ToString());
                Helper.Forms.startForm(editForm);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this group?", "Dialog Konfirmasi", MessageBoxButtons.YesNo);
            //MessageBox.Show(dialogResult.ToString())
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in groupGrid.SelectedRows)
                {
                    if (!Group.isAdmin(row.Cells[0].Value.ToString()))
                    {
                        Group.Destroy(row.Cells[0].Value.ToString());
                    }
                    else 
                    {
                        MessageBox.Show("You cannot delete admin group");
                    }
                    
                }
                refreshData();
            }
        }

        private void setMenu()
        {
            List<Sales.model.SalesMenu.CompareRole> role = SalesMenu.getAuth(VariableBuilder.Session.userLogged.Group, 2, "T001B1");
            Sales.model.SalesMenu.CompareRole rlv = role.Find(rl => rl.MenuID == "T001B1P1");
            if (rlv.isActived == 1)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }

            rlv = role.Find(rl => rl.MenuID == "T001B1P2");
            if (rlv.isActived == 1)
            {
                btnEdit.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
            }

            rlv = role.Find(rl => rl.MenuID == "T001B1P3");
            if (rlv.isActived == 1)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void groupGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
