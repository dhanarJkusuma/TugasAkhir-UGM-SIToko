﻿using Sales.libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales.model
{
    class Group : BaseModel
    {
        public static String[] Columns = {
                                            "group_id",
                                            "group_name",
                                            "created_at"
                                         };

        private Int32 _id;

        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private String _createdAt;

        public String CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        public static QueryBuilder query()
        {
            table = VariableBuilder.Table.Group;
            return new QueryBuilder();
        }

        public void New() 
        {
            List<String> insertedColumns = Columns.ToList();
            insertedColumns.RemoveAt(0);
            String[] values = { Name.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
            DatabaseBuilder.insert(VariableBuilder.Table.Group, insertedColumns.ToArray(), insertedColumns.ToArray(), values,"New Group has been added.");
        }

        public void Update() 
        {
            String[] selectedColumns = { Columns[1] };
            String[] values = { Name.ToString() };
            DatabaseBuilder.update(VariableBuilder.Table.Group, selectedColumns, selectedColumns, values, Columns[0] + "=" + Id,"Selected Group has been edited.");
        }

        public static DataTable All() 
        {
            return DatabaseBuilder.read(VariableBuilder.Table.Group);
        }

        public static Group Find(String id)
        {
            Group group = new Group();
            SqlConnection connection = DatabaseBuilder.getConnection();
            connection.Open();
            SqlDataReader reader = DatabaseBuilder.readData(VariableBuilder.Table.Group, Columns, Columns[0] + "=" + id, connection);
            while (reader.Read())
            {
                group.Id = Convert.ToInt32(reader.GetValue(0));
                group.Name = reader.GetString(1);
            }
            connection.Close();
            return group;
        }

        public static void Destroy(String id) 
        {
            DatabaseBuilder.destory(VariableBuilder.Table.Group, Group.Columns[0], id);
        }

        public static List<Group> FillComboBox(ComboBox comboBox)
        {
            List<Group> values = new List<Group>();
            SqlConnection connection = DatabaseBuilder.getConnection();
            connection.Open();
            SqlDataReader reader = DatabaseBuilder.readData(VariableBuilder.Table.Group, connection);
            while (reader.Read())
            {
                Group group = new Group();
                group.Id = Convert.ToInt32(reader.GetValue(0));
                group.Name = reader.GetString(1);
                group.CreatedAt = reader.GetDateTime(2).ToString();
                values.Add(group);

                comboBox.Items.Add(group.Name);
            }

            connection.Close();
            return values;
        }

    }
}
