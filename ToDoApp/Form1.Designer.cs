namespace ToDoApp
{
    partial class Form1
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
            this.button1_AddTask = new System.Windows.Forms.Button();
            this.button2_CompleteTask = new System.Windows.Forms.Button();
            this.button3_PostponeTask = new System.Windows.Forms.Button();
            this.button4_DeleteTask = new System.Windows.Forms.Button();
            this.textBox_task = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.due_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_category = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox1_DueDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2_SetDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1_AddTask
            // 
            this.button1_AddTask.BackColor = System.Drawing.Color.BlueViolet;
            this.button1_AddTask.ForeColor = System.Drawing.Color.White;
            this.button1_AddTask.Location = new System.Drawing.Point(14, 541);
            this.button1_AddTask.Margin = new System.Windows.Forms.Padding(5);
            this.button1_AddTask.Name = "button1_AddTask";
            this.button1_AddTask.Size = new System.Drawing.Size(140, 60);
            this.button1_AddTask.TabIndex = 0;
            this.button1_AddTask.Text = "Add";
            this.button1_AddTask.UseVisualStyleBackColor = false;
            this.button1_AddTask.Click += new System.EventHandler(this.button1_AddTask_Click);
            // 
            // button2_CompleteTask
            // 
            this.button2_CompleteTask.BackColor = System.Drawing.Color.BlueViolet;
            this.button2_CompleteTask.ForeColor = System.Drawing.Color.White;
            this.button2_CompleteTask.Location = new System.Drawing.Point(245, 541);
            this.button2_CompleteTask.Margin = new System.Windows.Forms.Padding(5);
            this.button2_CompleteTask.Name = "button2_CompleteTask";
            this.button2_CompleteTask.Size = new System.Drawing.Size(140, 60);
            this.button2_CompleteTask.TabIndex = 1;
            this.button2_CompleteTask.Text = "Complete";
            this.button2_CompleteTask.UseVisualStyleBackColor = false;
            this.button2_CompleteTask.Click += new System.EventHandler(this.button2_CompleteTask_Click);
            // 
            // button3_PostponeTask
            // 
            this.button3_PostponeTask.BackColor = System.Drawing.Color.BlueViolet;
            this.button3_PostponeTask.ForeColor = System.Drawing.Color.White;
            this.button3_PostponeTask.Location = new System.Drawing.Point(14, 649);
            this.button3_PostponeTask.Margin = new System.Windows.Forms.Padding(5);
            this.button3_PostponeTask.Name = "button3_PostponeTask";
            this.button3_PostponeTask.Size = new System.Drawing.Size(140, 60);
            this.button3_PostponeTask.TabIndex = 2;
            this.button3_PostponeTask.Text = "Postpone";
            this.button3_PostponeTask.UseVisualStyleBackColor = false;
            this.button3_PostponeTask.Click += new System.EventHandler(this.button3_PostponeTask_Click);
            // 
            // button4_DeleteTask
            // 
            this.button4_DeleteTask.BackColor = System.Drawing.Color.BlueViolet;
            this.button4_DeleteTask.ForeColor = System.Drawing.Color.White;
            this.button4_DeleteTask.Location = new System.Drawing.Point(243, 649);
            this.button4_DeleteTask.Margin = new System.Windows.Forms.Padding(5);
            this.button4_DeleteTask.Name = "button4_DeleteTask";
            this.button4_DeleteTask.Size = new System.Drawing.Size(140, 60);
            this.button4_DeleteTask.TabIndex = 3;
            this.button4_DeleteTask.Text = "Delete";
            this.button4_DeleteTask.UseVisualStyleBackColor = false;
            this.button4_DeleteTask.Click += new System.EventHandler(this.button4_DeleteTask_Click);
            // 
            // textBox_task
            // 
            this.textBox_task.Location = new System.Drawing.Point(14, 255);
            this.textBox_task.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_task.Multiline = true;
            this.textBox_task.Name = "textBox_task";
            this.textBox_task.Size = new System.Drawing.Size(371, 169);
            this.textBox_task.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 218);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type your task";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.status,
            this.date,
            this.due_date,
            this.task,
            this.category});
            this.dataGridView1.Location = new System.Drawing.Point(394, 82);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(788, 503);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "TaskNo";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 80;
            // 
            // status
            // 
            this.status.HeaderText = "TaskStatus";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Width = 125;
            // 
            // date
            // 
            this.date.HeaderText = "Setdate";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.Width = 90;
            // 
            // due_date
            // 
            this.due_date.HeaderText = "Duedate";
            this.due_date.MinimumWidth = 6;
            this.due_date.Name = "due_date";
            this.due_date.Width = 90;
            // 
            // task
            // 
            this.task.HeaderText = "Task";
            this.task.MinimumWidth = 6;
            this.task.Name = "task";
            this.task.Width = 200;
            // 
            // category
            // 
            this.category.HeaderText = "Taskcategory";
            this.category.MinimumWidth = 6;
            this.category.Name = "category";
            this.category.Width = 150;
            // 
            // textBox_category
            // 
            this.textBox_category.Location = new System.Drawing.Point(17, 474);
            this.textBox_category.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_category.Name = "textBox_category";
            this.textBox_category.Size = new System.Drawing.Size(371, 30);
            this.textBox_category.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Task set date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 439);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Task category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Task due date";
            // 
            // maskedTextBox1_DueDate
            // 
            this.maskedTextBox1_DueDate.Location = new System.Drawing.Point(12, 178);
            this.maskedTextBox1_DueDate.Margin = new System.Windows.Forms.Padding(5);
            this.maskedTextBox1_DueDate.Mask = "00/00/00";
            this.maskedTextBox1_DueDate.Name = "maskedTextBox1_DueDate";
            this.maskedTextBox1_DueDate.Size = new System.Drawing.Size(371, 30);
            this.maskedTextBox1_DueDate.TabIndex = 15;
            this.maskedTextBox1_DueDate.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox2_SetDate
            // 
            this.maskedTextBox2_SetDate.Location = new System.Drawing.Point(13, 82);
            this.maskedTextBox2_SetDate.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox2_SetDate.Mask = "00/00/00";
            this.maskedTextBox2_SetDate.Name = "maskedTextBox2_SetDate";
            this.maskedTextBox2_SetDate.Size = new System.Drawing.Size(371, 30);
            this.maskedTextBox2_SetDate.TabIndex = 16;
            this.maskedTextBox2_SetDate.ValidatingType = typeof(System.DateTime);
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(814, 624);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(374, 30);
            this.textBox_filter.TabIndex = 17;
            this.textBox_filter.TextChanged += new System.EventHandler(this.textBox_filter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(814, 592);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Filter by task status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 723);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_filter);
            this.Controls.Add(this.maskedTextBox2_SetDate);
            this.Controls.Add(this.maskedTextBox1_DueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_category);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_task);
            this.Controls.Add(this.button4_DeleteTask);
            this.Controls.Add(this.button3_PostponeTask);
            this.Controls.Add(this.button2_CompleteTask);
            this.Controls.Add(this.button1_AddTask);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_AddTask;
        private System.Windows.Forms.Button button2_CompleteTask;
        private System.Windows.Forms.Button button3_PostponeTask;
        private System.Windows.Forms.Button button4_DeleteTask;
        private System.Windows.Forms.TextBox textBox_task;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_category;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1_DueDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2_SetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn due_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn task;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.Label label5;
    }
}

