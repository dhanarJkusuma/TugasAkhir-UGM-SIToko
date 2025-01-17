﻿using Sales.libs;
using Sales.model;
using Sales.ui.inventory.master_item.processForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales.ui.inventory.master_item
{
    public partial class itemForm : Form
    {
        private String[] getColumns = {
                                        VariableBuilder.Table.Item + "." + Item.Columns[0] + " as Barcode",
                                        VariableBuilder.Table.Item + "." + Item.Columns[1] + " as Name",
                                        VariableBuilder.Table.Category + "." + Category.Columns[1] + " as Category",
                                        VariableBuilder.Table.Unit + "." + Unit.Columns[1] + " as Unit",
                                        VariableBuilder.Table.Item + "." + Item.Columns[4] + " as Price",
                                        VariableBuilder.Table.Item + "." + Item.Columns[5] + " as Stock_Alert"
                                      };
        public itemForm()
        {
            InitializeComponent();
            refreshData();
            setMenu();
        }

        public void refreshData() 
        {
            itemGrid.DataSource = Item.query()
                                      .leftJoin(VariableBuilder.Table.Category)
                                      .on(
                                      VariableBuilder.Table.Category + "." + Category.Columns[0]
                                      + "=" +
                                      VariableBuilder.Table.Item + "." + Item.Columns[2]
                                      )
                                      .leftJoin(VariableBuilder.Table.Unit)
                                      .on(
                                      VariableBuilder.Table.Unit + "." + Unit.Columns[0]
                                      + "=" +
                                      VariableBuilder.Table.Item + "." + Item.Columns[3]
                                      )
                                      .GetData(getColumns);
            itemGrid.ReadOnly = true;
            itemGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            newItem newItemForm = new newItem(this);
            Helper.Forms.startForm(newItemForm);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (itemGrid.SelectedRows.Count == 1) 
            {
                DataGridViewRow selectedItem = itemGrid.SelectedRows[0];
                Item currentItem = Item.Find(selectedItem.Cells[0].Value.ToString());
                editItem editForm = new editItem(this);
                editForm.CurrentItem = currentItem;
                Helper.Forms.startForm(editForm);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this data?", "Dialog Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in itemGrid.SelectedRows)
                {
                    Item.Destroy(row.Cells[0].Value.ToString());
                }
                refreshData();
            }
        }

        private void setMenu()
        {
            List<Sales.model.SalesMenu.CompareRole> role = SalesMenu.getAuth(VariableBuilder.Session.userLogged.Group, 2, "T003B3");
            Sales.model.SalesMenu.CompareRole rlv = role.Find(rl => rl.MenuID == "T003B3P1");
            if (rlv.isActived == 1)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }

            rlv = role.Find(rl => rl.MenuID == "T003B3P2");
            if (rlv.isActived == 1)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }

            rlv = role.Find(rl => rl.MenuID == "T003B3P3");
            if (rlv.isActived == 1)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            Helper.Data.setBinding(itemGrid, "Name", tSearch.Text);
        }

    }
}
