namespace Academy
{
    partial class TaskTable
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
            this.tasksTable = new System.Windows.Forms.DataGridView();
            this.taskId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDeadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupDrop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.taskDrop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksTable
            // 
            this.tasksTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasksTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tasksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskId,
            this.groupId,
            this.taskName,
            this.taskGroup,
            this.taskDeadline});
            this.tasksTable.Location = new System.Drawing.Point(13, 240);
            this.tasksTable.Name = "tasksTable";
            this.tasksTable.Size = new System.Drawing.Size(775, 198);
            this.tasksTable.TabIndex = 0;
            this.tasksTable.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TasksTable_RowHeaderMouseDoubleClick);
            // 
            // taskId
            // 
            this.taskId.HeaderText = "Id";
            this.taskId.Name = "taskId";
            this.taskId.Visible = false;
            // 
            // groupId
            // 
            this.groupId.HeaderText = "gId";
            this.groupId.Name = "groupId";
            this.groupId.Visible = false;
            // 
            // taskName
            // 
            this.taskName.HeaderText = "Task";
            this.taskName.Name = "taskName";
            this.taskName.ReadOnly = true;
            // 
            // taskGroup
            // 
            this.taskGroup.HeaderText = "Group";
            this.taskGroup.Name = "taskGroup";
            this.taskGroup.ReadOnly = true;
            // 
            // taskDeadline
            // 
            this.taskDeadline.HeaderText = "Deadline";
            this.taskDeadline.Name = "taskDeadline";
            this.taskDeadline.ReadOnly = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(122, 213);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(211, 20);
            this.searchBox.TabIndex = 13;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search";
            // 
            // groupDrop
            // 
            this.groupDrop.FormattingEnabled = true;
            this.groupDrop.Location = new System.Drawing.Point(123, 55);
            this.groupDrop.Name = "groupDrop";
            this.groupDrop.Size = new System.Drawing.Size(210, 21);
            this.groupDrop.TabIndex = 22;
            this.groupDrop.SelectedIndexChanged += new System.EventHandler(this.GroupDrop_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Filter by :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Group";
            // 
            // taskDrop
            // 
            this.taskDrop.FormattingEnabled = true;
            this.taskDrop.Location = new System.Drawing.Point(486, 59);
            this.taskDrop.Name = "taskDrop";
            this.taskDrop.Size = new System.Drawing.Size(298, 21);
            this.taskDrop.TabIndex = 24;
            this.taskDrop.SelectedIndexChanged += new System.EventHandler(this.TaskDrop_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(398, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "Task";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(661, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 28);
            this.button1.TabIndex = 25;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TaskTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.taskDrop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupDrop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tasksTable);
            this.Name = "TaskTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TaskTable";
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tasksTable;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox groupDrop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox taskDrop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskId;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDeadline;
        private System.Windows.Forms.Button button1;
    }
}