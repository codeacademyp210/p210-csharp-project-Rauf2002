namespace Academy
{
    partial class TeacherTable
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
            this.specialityDrop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.teachersTable = new System.Windows.Forms.DataGridView();
            this.teacherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherSpeciality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.teachersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // specialityDrop
            // 
            this.specialityDrop.FormattingEnabled = true;
            this.specialityDrop.Location = new System.Drawing.Point(122, 56);
            this.specialityDrop.Name = "specialityDrop";
            this.specialityDrop.Size = new System.Drawing.Size(211, 21);
            this.specialityDrop.TabIndex = 8;
            this.specialityDrop.SelectedIndexChanged += new System.EventHandler(this.SpecialityDrop_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sort by :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speciality";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(122, 168);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(211, 20);
            this.searchBox.TabIndex = 9;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // teachersTable
            // 
            this.teachersTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teachersTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.teachersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teacherId,
            this.teacherName,
            this.teacherSurname,
            this.teacherEmail,
            this.teacherPhone,
            this.teacherSpeciality});
            this.teachersTable.Location = new System.Drawing.Point(18, 195);
            this.teachersTable.Name = "teachersTable";
            this.teachersTable.Size = new System.Drawing.Size(770, 243);
            this.teachersTable.TabIndex = 10;
            // 
            // teacherId
            // 
            this.teacherId.HeaderText = "Id";
            this.teacherId.Name = "teacherId";
            this.teacherId.Visible = false;
            // 
            // teacherName
            // 
            this.teacherName.HeaderText = "Name";
            this.teacherName.Name = "teacherName";
            this.teacherName.ReadOnly = true;
            // 
            // teacherSurname
            // 
            this.teacherSurname.HeaderText = "Surname";
            this.teacherSurname.Name = "teacherSurname";
            this.teacherSurname.ReadOnly = true;
            // 
            // teacherEmail
            // 
            this.teacherEmail.HeaderText = "Email";
            this.teacherEmail.Name = "teacherEmail";
            this.teacherEmail.ReadOnly = true;
            // 
            // teacherPhone
            // 
            this.teacherPhone.HeaderText = "Phone";
            this.teacherPhone.Name = "teacherPhone";
            this.teacherPhone.ReadOnly = true;
            // 
            // teacherSpeciality
            // 
            this.teacherSpeciality.HeaderText = "Speciality";
            this.teacherSpeciality.Name = "teacherSpeciality";
            this.teacherSpeciality.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(678, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TeacherTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.teachersTable);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.specialityDrop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "TeacherTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TeacherTable";
            ((System.ComponentModel.ISupportInitialize)(this.teachersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox specialityDrop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView teachersTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherId;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherSpeciality;
        private System.Windows.Forms.Button button1;
    }
}