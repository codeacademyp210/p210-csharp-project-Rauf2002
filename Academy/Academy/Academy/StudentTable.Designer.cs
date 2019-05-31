namespace Academy
{
    partial class StudentTable
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
            this.studentsTable = new System.Windows.Forms.DataGridView();
            this.studentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupDrop = new System.Windows.Forms.ComboBox();
            this.maximumBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.minimumBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // studentsTable
            // 
            this.studentsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentId,
            this.studentName,
            this.studentSurname,
            this.studentEmail,
            this.studentPhone,
            this.studentGroup,
            this.studentFee,
            this.studentAverage});
            this.studentsTable.Location = new System.Drawing.Point(13, 237);
            this.studentsTable.Name = "studentsTable";
            this.studentsTable.Size = new System.Drawing.Size(775, 201);
            this.studentsTable.TabIndex = 0;
            // 
            // studentId
            // 
            this.studentId.HeaderText = "Id";
            this.studentId.Name = "studentId";
            this.studentId.Visible = false;
            // 
            // studentName
            // 
            this.studentName.HeaderText = "Name";
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            // 
            // studentSurname
            // 
            this.studentSurname.HeaderText = "Surname";
            this.studentSurname.Name = "studentSurname";
            this.studentSurname.ReadOnly = true;
            // 
            // studentEmail
            // 
            this.studentEmail.HeaderText = "Email";
            this.studentEmail.Name = "studentEmail";
            this.studentEmail.ReadOnly = true;
            // 
            // studentPhone
            // 
            this.studentPhone.HeaderText = "Phone";
            this.studentPhone.Name = "studentPhone";
            this.studentPhone.ReadOnly = true;
            // 
            // studentGroup
            // 
            this.studentGroup.HeaderText = "Group";
            this.studentGroup.Name = "studentGroup";
            this.studentGroup.ReadOnly = true;
            // 
            // studentFee
            // 
            this.studentFee.HeaderText = "Left Amount";
            this.studentFee.Name = "studentFee";
            this.studentFee.ReadOnly = true;
            // 
            // studentAverage
            // 
            this.studentAverage.HeaderText = "Average";
            this.studentAverage.Name = "studentAverage";
            this.studentAverage.ReadOnly = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(122, 210);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(211, 20);
            this.searchBox.TabIndex = 11;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchStudent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search";
            // 
            // groupDrop
            // 
            this.groupDrop.FormattingEnabled = true;
            this.groupDrop.Location = new System.Drawing.Point(490, 55);
            this.groupDrop.Name = "groupDrop";
            this.groupDrop.Size = new System.Drawing.Size(298, 21);
            this.groupDrop.TabIndex = 19;
            this.groupDrop.SelectedIndexChanged += new System.EventHandler(this.GroupSelected);
            // 
            // maximumBox
            // 
            this.maximumBox.Location = new System.Drawing.Point(14, 158);
            this.maximumBox.Name = "maximumBox";
            this.maximumBox.Size = new System.Drawing.Size(319, 20);
            this.maximumBox.TabIndex = 18;
            this.maximumBox.TextChanged += new System.EventHandler(this.MaximumBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "Filter :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(379, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sort by :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "Group";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 26);
            this.label5.TabIndex = 15;
            this.label5.Text = "Maximum Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Minimum Amount";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(679, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // minimumBox
            // 
            this.minimumBox.Location = new System.Drawing.Point(18, 85);
            this.minimumBox.Name = "minimumBox";
            this.minimumBox.Size = new System.Drawing.Size(315, 20);
            this.minimumBox.TabIndex = 17;
            this.minimumBox.TextChanged += new System.EventHandler(this.MinimumBox_TextChanged);
            // 
            // StudentTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupDrop);
            this.Controls.Add(this.maximumBox);
            this.Controls.Add(this.minimumBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentsTable);
            this.Name = "StudentTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StudentTable";
            ((System.ComponentModel.ISupportInitialize)(this.studentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView studentsTable;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox groupDrop;
        private System.Windows.Forms.TextBox maximumBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentAverage;
        private System.Windows.Forms.TextBox minimumBox;
    }
}