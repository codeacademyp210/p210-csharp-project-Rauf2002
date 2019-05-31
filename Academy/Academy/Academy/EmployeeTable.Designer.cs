namespace Academy
{
    partial class EmployeeTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.minimumBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maximumBox = new System.Windows.Forms.TextBox();
            this.employeesTable = new System.Windows.Forms.DataGridView();
            this.empId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.positionDrop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deadlineTimePicker = new System.Windows.Forms.DateTimePicker();
            this.beforeRadio = new System.Windows.Forms.RadioButton();
            this.afterRadio = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum Salary";
            // 
            // minimumBox
            // 
            this.minimumBox.Location = new System.Drawing.Point(13, 85);
            this.minimumBox.Name = "minimumBox";
            this.minimumBox.Size = new System.Drawing.Size(166, 20);
            this.minimumBox.TabIndex = 1;
            this.minimumBox.TextChanged += new System.EventHandler(this.MinimumSalary);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(506, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Position";
            // 
            // maximumBox
            // 
            this.maximumBox.Location = new System.Drawing.Point(257, 85);
            this.maximumBox.Name = "maximumBox";
            this.maximumBox.Size = new System.Drawing.Size(166, 20);
            this.maximumBox.TabIndex = 2;
            this.maximumBox.TextChanged += new System.EventHandler(this.MaximumSalary);
            // 
            // employeesTable
            // 
            this.employeesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empId,
            this.empName,
            this.empSurname,
            this.empEmail,
            this.empPhone,
            this.empPosition,
            this.empStartTime,
            this.empSalary});
            this.employeesTable.Location = new System.Drawing.Point(13, 194);
            this.employeesTable.Name = "employeesTable";
            this.employeesTable.Size = new System.Drawing.Size(979, 244);
            this.employeesTable.TabIndex = 4;
            // 
            // empId
            // 
            this.empId.HeaderText = "Id";
            this.empId.Name = "empId";
            this.empId.Visible = false;
            // 
            // empName
            // 
            this.empName.HeaderText = "Name";
            this.empName.Name = "empName";
            this.empName.ReadOnly = true;
            // 
            // empSurname
            // 
            this.empSurname.HeaderText = "Surname";
            this.empSurname.Name = "empSurname";
            this.empSurname.ReadOnly = true;
            // 
            // empEmail
            // 
            this.empEmail.HeaderText = "Email";
            this.empEmail.Name = "empEmail";
            this.empEmail.ReadOnly = true;
            // 
            // empPhone
            // 
            this.empPhone.HeaderText = "Phone";
            this.empPhone.Name = "empPhone";
            this.empPhone.ReadOnly = true;
            // 
            // empPosition
            // 
            this.empPosition.HeaderText = "Position";
            this.empPosition.Name = "empPosition";
            this.empPosition.ReadOnly = true;
            // 
            // empStartTime
            // 
            this.empStartTime.HeaderText = "Start Time";
            this.empStartTime.Name = "empStartTime";
            this.empStartTime.ReadOnly = true;
            // 
            // empSalary
            // 
            this.empSalary.HeaderText = "Salary";
            this.empSalary.Name = "empSalary";
            this.empSalary.ReadOnly = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(107, 168);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(320, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchEmployee);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(505, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sort by :";
            // 
            // positionDrop
            // 
            this.positionDrop.FormattingEnabled = true;
            this.positionDrop.Location = new System.Drawing.Point(616, 55);
            this.positionDrop.Name = "positionDrop";
            this.positionDrop.Size = new System.Drawing.Size(376, 21);
            this.positionDrop.TabIndex = 5;
            this.positionDrop.SelectedIndexChanged += new System.EventHandler(this.PositionDrop_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Maximum Salary";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(506, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date";
            // 
            // deadlineTimePicker
            // 
            this.deadlineTimePicker.CustomFormat = "dd-mm-yyyy";
            this.deadlineTimePicker.Location = new System.Drawing.Point(616, 109);
            this.deadlineTimePicker.Name = "deadlineTimePicker";
            this.deadlineTimePicker.Size = new System.Drawing.Size(376, 20);
            this.deadlineTimePicker.TabIndex = 6;
            // 
            // beforeRadio
            // 
            this.beforeRadio.AutoSize = true;
            this.beforeRadio.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beforeRadio.Location = new System.Drawing.Point(616, 148);
            this.beforeRadio.Name = "beforeRadio";
            this.beforeRadio.Size = new System.Drawing.Size(69, 24);
            this.beforeRadio.TabIndex = 7;
            this.beforeRadio.TabStop = true;
            this.beforeRadio.Text = "Before";
            this.beforeRadio.UseVisualStyleBackColor = true;
            this.beforeRadio.CheckedChanged += new System.EventHandler(this.BeforeRadio_CheckedChanged);
            // 
            // afterRadio
            // 
            this.afterRadio.AutoSize = true;
            this.afterRadio.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.afterRadio.Location = new System.Drawing.Point(717, 148);
            this.afterRadio.Name = "afterRadio";
            this.afterRadio.Size = new System.Drawing.Size(62, 24);
            this.afterRadio.TabIndex = 7;
            this.afterRadio.TabStop = true;
            this.afterRadio.Text = "After";
            this.afterRadio.UseVisualStyleBackColor = true;
            this.afterRadio.CheckedChanged += new System.EventHandler(this.AfterRadio_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(882, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Filter :";
            // 
            // EmployeeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.afterRadio);
            this.Controls.Add(this.beforeRadio);
            this.Controls.Add(this.deadlineTimePicker);
            this.Controls.Add(this.positionDrop);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.employeesTable);
            this.Controls.Add(this.maximumBox);
            this.Controls.Add(this.minimumBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "EmployeeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmployeeTable";
            ((System.ComponentModel.ISupportInitialize)(this.employeesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox minimumBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maximumBox;
        private System.Windows.Forms.DataGridView employeesTable;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn empId;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName;
        private System.Windows.Forms.DataGridViewTextBoxColumn empSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn empEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn empPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn empPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn empStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn empSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox positionDrop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker deadlineTimePicker;
        private System.Windows.Forms.RadioButton beforeRadio;
        private System.Windows.Forms.RadioButton afterRadio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}