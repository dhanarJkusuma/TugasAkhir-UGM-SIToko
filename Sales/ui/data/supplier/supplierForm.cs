﻿using Sales.libs;
using Sales.model;
using Sales.ui.data.supplier.processForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales.ui.data.supplier
{
    public partial class supplierForm : BaseForm
    {
        private String[] selectedColumns = {
                                            VariableBuilder.Table.Supplier + "." + Supplier.Columns[0] + " as Supplie_No",
                                            VariableBuilder.Table.Supplier + "." + Supplier.Columns[1] + " as Name",
                                            VariableBuilder.Table.Supplier + "." + Supplier.Columns[2] + " as Telp",
                                            VariableBuilder.Table.Supplier + "." + Supplier.Columns[3] + " as Address",
                                            VariableBuilder.Table.Provinces + ".prov_name as Province", 
                                            VariableBuilder.Table.Regencies + ".reg_name as Regency",
                                            VariableBuilder.Table.Districts + ".dis_name as District",
                                            VariableBuilder.Table.Villages + ".vill_name as Village"
                                           };
        private List<Sales.model.SalesMenu.CompareRole> role;
        public supplierForm()
        {
            InitializeComponent();
            refreshData();
            role = SalesMenu.getAuth(VariableBuilder.Session.userLogged.Group, 2, "T002B2");
            setMenu();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newSupplier newForm = new newSupplier(this);
            Helper.Forms.startForm(newForm);
        }

        private void setMenu()
        {
            Sales.model.SalesMenu.CompareRole rlv = role.Find(rl => rl.MenuID == "T002B2P1");
            if (rlv.isActived == 1)
            {
                btnNew.Enabled = true;
            }
            else
            {
                btnNew.Enabled = false;
            }

            rlv = role.Find(rl => rl.MenuID == "T002B2P2");
            if (rlv.isActived == 1)
            {
                editBtn.Enabled = true;
            }
            else
            {
                editBtn.Enabled = false;
            }

            rlv = role.Find(rl => rl.MenuID == "T002B2P3");
            if (rlv.isActived == 1)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        public override void refreshData()
        {
            base.refreshData();
            supplierGrid.DataSource = Supplier.query()
                                           .innerJoin(VariableBuilder.Table.Provinces)
                                           .on(
                                               VariableBuilder.Table.Supplier + "." + Supplier.Columns[5]
                                               + "=" +
                                               VariableBuilder.Table.Provinces + ".prov_code"
                                           )
                                           .innerJoin(VariableBuilder.Table.Regencies)
                                           .on(
                                               VariableBuilder.Table.Supplier + "." + Supplier.Columns[6]
                                               + "=" +
                                               VariableBuilder.Table.Regencies + ".reg_code"
                                           )
                                           .innerJoin(VariableBuilder.Table.Districts)
                                           .on(
                                               VariableBuilder.Table.Supplier + "." + Supplier.Columns[7]
                                               + "=" +
                                               VariableBuilder.Table.Districts + ".dis_code"
                                           )
                                           .innerJoin(VariableBuilder.Table.Villages)
                                           .on(
                                               VariableBuilder.Table.Supplier + "." + Supplier.Columns[8]
                                               + "=" +
                                               VariableBuilder.Table.Villages + ".vill_code"
                                           )
                                           .GetData(selectedColumns);
            supplierGrid.ReadOnly = true;
            supplierGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (supplierGrid.SelectedRows.Count == 1) 
            {
                editSupplier editForm = new editSupplier(this);
                editForm.CurrentSupplier = Supplier.Find(supplierGrid.SelectedRows[0].Cells[0].Value.ToString());
                Helper.Forms.startForm(editForm);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this supplier ?", "Dialog Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in supplierGrid.SelectedRows)
                {
                    Supplier.Destroy(row.Cells[0].Value.ToString());
                }
                refreshData();
            }
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            Helper.Data.setBinding(supplierGrid, "Name", tSearch.Text);
        }
    }
}
