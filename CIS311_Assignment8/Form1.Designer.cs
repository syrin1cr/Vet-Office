namespace CIS311_Assignment8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvResults = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtAddress = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtCity = new TextBox();
            txtZip = new TextBox();
            txtState = new TextBox();
            txtId = new TextBox();
            btnGoStart = new Button();
            btnGoEnd = new Button();
            btnGoBack = new Button();
            btnGoNext = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            OwnerInfo = new GroupBox();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            OwnerInfo.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(12, 290);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(676, 221);
            dgvResults.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 28);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 66);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 124);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 3;
            label3.Text = "Phone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 23);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 4;
            label4.Text = "ID Number:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(73, 63);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(147, 23);
            txtAddress.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(73, 25);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Owner Name";
            txtName.Size = new Size(147, 23);
            txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(73, 121);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone";
            txtPhone.Size = new Size(147, 23);
            txtPhone.TabIndex = 6;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(73, 92);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "City";
            txtCity.Size = new Size(147, 23);
            txtCity.TabIndex = 3;
            // 
            // txtZip
            // 
            txtZip.Location = new Point(270, 92);
            txtZip.Name = "txtZip";
            txtZip.PlaceholderText = "Zip";
            txtZip.Size = new Size(147, 23);
            txtZip.TabIndex = 5;
            // 
            // txtState
            // 
            txtState.Location = new Point(226, 92);
            txtState.Name = "txtState";
            txtState.PlaceholderText = "State";
            txtState.Size = new Size(38, 23);
            txtState.TabIndex = 4;
            // 
            // txtId
            // 
            txtId.Location = new Point(456, 20);
            txtId.Name = "txtId";
            txtId.Size = new Size(59, 23);
            txtId.TabIndex = 11;
            // 
            // btnGoStart
            // 
            btnGoStart.Location = new Point(15, 173);
            btnGoStart.Name = "btnGoStart";
            btnGoStart.Size = new Size(54, 41);
            btnGoStart.TabIndex = 12;
            btnGoStart.Text = "<|";
            btnGoStart.UseVisualStyleBackColor = true;
            btnGoStart.Click += btnGoStart_Click;
            // 
            // btnGoEnd
            // 
            btnGoEnd.Location = new Point(610, 173);
            btnGoEnd.Name = "btnGoEnd";
            btnGoEnd.Size = new Size(54, 41);
            btnGoEnd.TabIndex = 13;
            btnGoEnd.Text = "|>";
            btnGoEnd.UseVisualStyleBackColor = true;
            btnGoEnd.Click += btnGoEnd_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.Location = new Point(75, 173);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(54, 41);
            btnGoBack.TabIndex = 14;
            btnGoBack.Text = "<<";
            btnGoBack.UseVisualStyleBackColor = true;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // btnGoNext
            // 
            btnGoNext.Location = new Point(550, 173);
            btnGoNext.Name = "btnGoNext";
            btnGoNext.Size = new Size(54, 41);
            btnGoNext.TabIndex = 15;
            btnGoNext.Text = ">>";
            btnGoNext.UseVisualStyleBackColor = true;
            btnGoNext.Click += btnGoNext_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(262, 173);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(54, 41);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(322, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(54, 41);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(382, 173);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(54, 41);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // OwnerInfo
            // 
            OwnerInfo.Controls.Add(btnCancel);
            OwnerInfo.Controls.Add(btnSave);
            OwnerInfo.Controls.Add(txtCity);
            OwnerInfo.Controls.Add(btnUpdate);
            OwnerInfo.Controls.Add(label1);
            OwnerInfo.Controls.Add(btnDelete);
            OwnerInfo.Controls.Add(label2);
            OwnerInfo.Controls.Add(btnAdd);
            OwnerInfo.Controls.Add(label3);
            OwnerInfo.Controls.Add(btnGoNext);
            OwnerInfo.Controls.Add(label4);
            OwnerInfo.Controls.Add(btnGoBack);
            OwnerInfo.Controls.Add(txtAddress);
            OwnerInfo.Controls.Add(btnGoEnd);
            OwnerInfo.Controls.Add(txtName);
            OwnerInfo.Controls.Add(btnGoStart);
            OwnerInfo.Controls.Add(txtPhone);
            OwnerInfo.Controls.Add(txtId);
            OwnerInfo.Controls.Add(txtZip);
            OwnerInfo.Controls.Add(txtState);
            OwnerInfo.Location = new Point(12, 12);
            OwnerInfo.Name = "OwnerInfo";
            OwnerInfo.Size = new Size(676, 272);
            OwnerInfo.TabIndex = 19;
            OwnerInfo.TabStop = false;
            OwnerInfo.Text = "grpOwner";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(353, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(54, 41);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(293, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(54, 41);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 524);
            Controls.Add(OwnerInfo);
            Controls.Add(dgvResults);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            OwnerInfo.ResumeLayout(false);
            OwnerInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResults;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtAddress;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtCity;
        private TextBox txtZip;
        private TextBox txtState;
        private TextBox txtId;
        private Button btnGoStart;
        private Button btnGoEnd;
        private Button btnGoBack;
        private Button btnGoNext;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private GroupBox OwnerInfo;
        private Button btnCancel;
        private Button btnSave;
    }
}
