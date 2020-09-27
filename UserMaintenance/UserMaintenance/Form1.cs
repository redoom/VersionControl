﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName; 
            btnAdd.Text = Resource1.Add;
            btnDelete.Text = Resource1.Delete;
            btnWriteToFile.Text = Resource1.WriteToFile;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text,
            };
            users.Add(u);
        }

        private void btnWriteToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv"; 
            sfd.DefaultExt = "csv"; 
            sfd.AddExtension = true;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var s in users)
                {
                    sw.Write(s.ID);
                    sw.Write(";");
                    sw.Write(s.FullName);
                    sw.Write(";");
                    sw.WriteLine(); // Ez a sor az alábbi módon is írható: sr.Write("\n");
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            users.RemoveAt(listUsers.SelectedIndex);
        }
    }
}
