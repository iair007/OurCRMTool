using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;

namespace OurCRMTool
{
    public partial class RolesNotUsed : Form
    {
        private BL bl;
        log4net.ILog log;
        public RolesNotUsed(BL _bl, log4net.ILog _log)
        {
            InitializeComponent();
            bl = _bl;
            log = _log;
            this.Text = "Roles Not Used - Connected to: " + bl.url;
            SetRolesGrid();
        }

        private void SetRolesGrid()
        {
            try
            {
                gridRoles.Rows.Clear();
                EntityCollection roles = bl.GetNotUsedRoles();

                foreach (Entity r in roles.Entities)
                {
                    string roleName = r.GetAttributeValue<string>("name");
                    Guid roleId = r.GetAttributeValue<Guid>("roleid");
                    string businessUnit = r.GetAttributeValue<AliasedValue>("businessunit.name").Value.ToString();
                    string createdby = r.GetAttributeValue<AliasedValue>("user.fullname").Value.ToString();
                    string createdOn = r.GetAttributeValue<DateTime>("createdon").ToString("dd/MM/yyyy");

                    gridRoles.Rows.Add(roleName, roleId, businessUnit, createdby, createdOn);
                }

                lbSecurityRoles.Text = "Security Roles: " + gridRoles.Rows.Count.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        #region Events

        private void gridRoles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);

            if (dataGridView.CurrentCell.Value == null || dataGridView.CurrentCell.Value.ToString() == string.Empty) return;

            bl.OpenRole(dataGridView.CurrentRow.Cells["RoleId"].Value.ToString());

        }


        #endregion

    }
}
