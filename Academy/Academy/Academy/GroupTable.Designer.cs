namespace Academy
{
    partial class GroupTable
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
            this.teacherDrop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.classroomDrop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mentorDrop = new System.Windows.Forms.ComboBox();
            this.educationDrop = new System.Windows.Forms.ComboBox();
            this.groupsTable = new System.Windows.Forms.DataGridView();
            this.groupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupMentor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupEducation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // teacherDrop
            // 
            this.teacherDrop.FormattingEnabled = true;
            this.teacherDrop.Location = new System.Drawing.Point(122, 56);
            this.teacherDrop.Name = "teacherDrop";
            this.teacherDrop.Size = new System.Drawing.Size(211, 21);
            this.teacherDrop.TabIndex = 11;
            this.teacherDrop.SelectedIndexChanged += new System.EventHandler(this.TeacherSelected);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sort by :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Teacher";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Classroom";
            // 
            // classroomDrop
            // 
            this.classroomDrop.FormattingEnabled = true;
            this.classroomDrop.Location = new System.Drawing.Point(122, 100);
            this.classroomDrop.Name = "classroomDrop";
            this.classroomDrop.Size = new System.Drawing.Size(211, 21);
            this.classroomDrop.TabIndex = 12;
            this.classroomDrop.SelectedIndexChanged += new System.EventHandler(this.ClassroomSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(437, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mentor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(437, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Education Program";
            // 
            // mentorDrop
            // 
            this.mentorDrop.FormattingEnabled = true;
            this.mentorDrop.Location = new System.Drawing.Point(546, 57);
            this.mentorDrop.Name = "mentorDrop";
            this.mentorDrop.Size = new System.Drawing.Size(211, 21);
            this.mentorDrop.TabIndex = 11;
            this.mentorDrop.SelectedIndexChanged += new System.EventHandler(this.MentorSelected);
            // 
            // educationDrop
            // 
            this.educationDrop.FormattingEnabled = true;
            this.educationDrop.Location = new System.Drawing.Point(637, 101);
            this.educationDrop.Name = "educationDrop";
            this.educationDrop.Size = new System.Drawing.Size(120, 21);
            this.educationDrop.TabIndex = 12;
            this.educationDrop.SelectedIndexChanged += new System.EventHandler(this.EducationSelected);
            // 
            // groupsTable
            // 
            this.groupsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.groupsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupId,
            this.groupName,
            this.groupClassroom,
            this.groupTeacher,
            this.groupMentor,
            this.groupEducation,
            this.groupCapacity});
            this.groupsTable.Location = new System.Drawing.Point(13, 224);
            this.groupsTable.Name = "groupsTable";
            this.groupsTable.Size = new System.Drawing.Size(775, 214);
            this.groupsTable.TabIndex = 13;
            // 
            // groupId
            // 
            this.groupId.HeaderText = "Id";
            this.groupId.Name = "groupId";
            this.groupId.Visible = false;
            // 
            // groupName
            // 
            this.groupName.HeaderText = "Name";
            this.groupName.Name = "groupName";
            this.groupName.ReadOnly = true;
            // 
            // groupClassroom
            // 
            this.groupClassroom.HeaderText = "Classroom";
            this.groupClassroom.Name = "groupClassroom";
            this.groupClassroom.ReadOnly = true;
            // 
            // groupTeacher
            // 
            this.groupTeacher.HeaderText = "Teacher";
            this.groupTeacher.Name = "groupTeacher";
            this.groupTeacher.ReadOnly = true;
            // 
            // groupMentor
            // 
            this.groupMentor.HeaderText = "Mentor";
            this.groupMentor.Name = "groupMentor";
            this.groupMentor.ReadOnly = true;
            // 
            // groupEducation
            // 
            this.groupEducation.HeaderText = "Education Program";
            this.groupEducation.Name = "groupEducation";
            this.groupEducation.ReadOnly = true;
            // 
            // groupCapacity
            // 
            this.groupCapacity.HeaderText = "Capacity";
            this.groupCapacity.Name = "groupCapacity";
            this.groupCapacity.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "Search :";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(134, 189);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(199, 20);
            this.searchBox.TabIndex = 14;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchGroup);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetBtn.Location = new System.Drawing.Point(637, 178);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(119, 34);
            this.resetBtn.TabIndex = 15;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // GroupTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.groupsTable);
            this.Controls.Add(this.educationDrop);
            this.Controls.Add(this.classroomDrop);
            this.Controls.Add(this.mentorDrop);
            this.Controls.Add(this.teacherDrop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "GroupTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GroupTable";
            ((System.ComponentModel.ISupportInitialize)(this.groupsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox teacherDrop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox classroomDrop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mentorDrop;
        private System.Windows.Forms.ComboBox educationDrop;
        private System.Windows.Forms.DataGridView groupsTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupMentor;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupEducation;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupCapacity;
        private System.Windows.Forms.Button resetBtn;
    }
}