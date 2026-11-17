using System.Data;
using System.Windows.Forms;

/// <summary>
/// Author: Cody Syring
/// Filename: Form1.cs
/// Part of Project: CIS311_Assignment8.cs
///
/// File Purpose:
/// This Files purpose is to control what and when information is update on
/// the form. It will also control what the user can interact with depending
/// on the users interaction. 
/// </summary>

namespace CIS311_Assignment8
{
    public partial class Form1 : Form
    {
        string addUpdateFlag;
        DBHandle dataBase;
        /// <summary>
        // This method will create a instance of our DBHandle class.
        // It will than update the form according to the the first user.
        /// </summary>
        public Form1()
        {
            dataBase = new DBHandle();

            InitializeComponent();

            makeFormNotInteractable();
            updateForm(dataBase.GetRow());
            updateDataGrid(dataBase.GetPetTable(txtId.Text.ToString()));

        }
        /// <summary>
        /// This method will get a single row from the database and display it to the user.
        /// </summary>
        /// <param name="rowToPush"></param>    This variable is the row we will
        ///                                     push to the UI
        public void updateForm(DataRow rowToPush)
        {
            txtId.Text = rowToPush["Id"]?.ToString()?.Trim();
            txtName.Text = rowToPush["OwnerName"]?.ToString()?.Trim();
            txtAddress.Text = rowToPush["OwnerAddress"]?.ToString()?.Trim();
            txtCity.Text = rowToPush["OwnerCity"]?.ToString()?.Trim();
            txtState.Text = rowToPush["OwnerState"]?.ToString()?.Trim();
            txtZip.Text = rowToPush["OwnerZipCode"]?.ToString()?.Trim();
            txtPhone.Text = rowToPush["OwnerPhoneNumber"]?.ToString()?.Trim();

            updateDataGrid(dataBase.GetPetTable(txtId.Text.ToString()));
        }
        /// <summary>
        /// This method will get a DataTable and push it to dgvResults
        /// in the UI.
        /// </summary>
        /// <param name="tableToPush"></param>  This variable is the row we will
        ///                                     push to the UI
        private void updateDataGrid(DataTable tableToPush)
        {
            dgvResults.DataSource = tableToPush;
            dgvResults.Columns["ID"].ReadOnly = true;
            dgvResults.Columns["OwnerID"].ReadOnly = true;
        }
        /// <summary>
        /// This method will request the first user from the DB class and 
        /// request a form update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoStart_Click(object sender, EventArgs e)
        {
            updateForm(dataBase.GoFirst());
        }
        /// <summary>
        /// This method will request the Last user from the DB class and 
        /// request a form update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoEnd_Click(object sender, EventArgs e)
        {
            updateForm(dataBase.GoLast());
        }
        /// <summary>
        /// This method will request the previous user from the DB class and 
        /// request a form update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            updateForm(dataBase.GoBackUser());
        }
        /// <summary>
        /// This method will request the next user from the DB class and 
        /// request a form update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoNext_Click(object sender, EventArgs e)
        {
            updateForm(dataBase.GoNextUser());
        }
        /// <summary>
        /// This method will change what controls are enabled or disabled.
        /// The goal is to make all input fields not enabled so the user can't edit them.
        /// </summary>
        private void makeFormNotInteractable()
        {
            txtId.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtZip.Enabled = false;
            txtPhone.Enabled = false;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            btnGoBack.Enabled = true;
            btnGoEnd.Enabled = true;
            btnGoNext.Enabled = true;
            btnGoStart.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            dgvResults.Enabled = false;


        }
        /// <summary>
        /// This method will change what controls are enabled or disabled.
        /// The goal is to make all input fields enabled so the user can edit them.
        /// </summary>
        private void makeFormInteractable()
        {
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtZip.Enabled = true;
            txtPhone.Enabled = true;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            btnGoBack.Enabled = false;
            btnGoEnd.Enabled = false;
            btnGoNext.Enabled = false;
            btnGoStart.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;

            dgvResults.Enabled = true;
        }
        /// <summary>
        /// This method will reset our flag.
        /// Make the input box's disabled.
        /// update the form so we are not looking at a blank Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            addUpdateFlag = "";
            makeFormNotInteractable();
            updateForm(dataBase.GetRow());
            updateDataGrid(dataBase.GetPetTable(txtId.Text.ToString()));
        }
        /// <summary>
        /// This method does allot of work... Ooops...
        /// 
        /// This method will do two actions depending on what addUpdateFlag is set to.
        /// If its set to "add" we will request to add a user to the database.
        /// Nothing on the form will update till we have a successful responce from the database.
        /// If it fails we drop out of this control and wait for a request.
        /// 
        /// If its set to "update" we will request to update a user to the database.
        /// Nothing on the form will update till we have a successful responce from the database.
        /// If it fails we drop out of this control and wait for a request.
        /// 
        /// Will also gather all the pets currently in the dgv box and run a merg on the data
        /// base with that data. Finally we will request that all animals not in the dgv for the
        /// current owner gets removed from the data base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dbResult;

            switch (addUpdateFlag)
            {
                case "add":
                    dbResult = dataBase.insertUser(txtName.Text.ToString(),
                                                      txtAddress.Text.ToString(),
                                                      txtCity.Text.ToString(),
                                                      txtState.Text.ToString(),
                                                      txtZip.Text.ToString(),
                                                      txtPhone.Text.ToString()
                                                      );
                    if (dbResult)
                    {
                        btnGoEnd_Click(sender, e);
                        makeFormNotInteractable();
                    }
                    break;
                case "update":
                    string ownerID = txtId.Text.ToString();

                    dbResult = dataBase.updateUser(ownerID,
                                                   txtName.Text.ToString(),
                                                   txtAddress.Text.ToString(),
                                                   txtCity.Text.ToString(),
                                                   txtState.Text.ToString(),
                                                   txtZip.Text.ToString(),
                                                   txtPhone.Text.ToString()
                                                  );
                    if (dbResult)
                    {
                        for (int i = 0; i < dgvResults.Rows.Count - 1; i++)
                        {
                            DataGridViewRow targetRow = dgvResults.Rows[i];


                            dataBase.updateOrAddPet(targetRow.Cells["Id"].Value.ToString(),
                                targetRow.Cells["PetName"].Value.ToString(),
                                targetRow.Cells["PetSpecies"].Value.ToString(),
                                targetRow.Cells["PetBirthday"].Value.ToString(),
                                targetRow.Cells["PetLastVisitDate"].Value.ToString(),
                                ownerID);
                        }

                        dataBase.removePets(dgvResults, ownerID);
                        updateDataGrid(dataBase.GetPetTable(txtId.Text.ToString()));
                        makeFormNotInteractable();
                    }
                    break;
            }
        }
        /// <summary>
        /// This method will request a user to be deleted.
        /// We will jump back to the first user in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataBase.removeUser(txtId.Text.ToString());
            btnGoStart_Click(sender, e);
        }
        /// <summary>
        /// This method will check to see if an Add is currently happening so 
        /// we dont lose the current progress.
        /// It then sets an update flag used in the Save user call.
        /// Makes it so we can edit the fields in the form.
        /// Resets the text feilds to be empty. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Enabled == false)
            {
                addUpdateFlag = "add";
                makeFormInteractable();

                dgvResults.DataSource = null;
                txtId.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtZip.Text = "";
                txtPhone.Text = "";
            }
        }
        /// <summary>
        /// This method will check to see if an update is currently happening so 
        /// we dont lose the current progress.
        /// It than sets our flag to update used in the save button call.
        /// Updates the form so the user can edit the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Enabled == false)
            {
                addUpdateFlag = "update";
                makeFormInteractable();
            }
        }
    }
}
