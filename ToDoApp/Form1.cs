using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToDoApp 
{
    public partial class Form1 : Form
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        string cs = @"URI=file:" + Application.StartupPath + "\\todo_database.db";
        string path = "todo_database.db";

        public Form1()
        {
            InitializeComponent();
        }
        private void ShowData()
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM TodoList WHERE isDeleted = 0";
            
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr["id"], dr["status"], dr["date"], dr["due_date"], dr["task"], dr["category"]);
                
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells[1].Value != null)
                {

                    if (Convert.ToString(row.Cells[1].Value) == "Completed")
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                    else if (Convert.ToString(row.Cells[1].Value) == "Postponed")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }

                    DateTime currentDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yy"), "dd/MM/yy", null);
                    DateTime tableDate = Convert.ToDateTime(row.Cells[3].Value);
                    //Add date validation
                    int res = DateTime.Compare(currentDate, tableDate);

                    if (res != -1 && Convert.ToString(row.Cells[1].Value) != "Completed")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;

                    }


                }
            }

        }

        private void TableCreation()
        {

            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(cs))
                {
                    sqlite.Open();


                    string sql = @"CREATE TABLE TodoList(id INTEGER PRIMARY KEY, status TEXT,
            date TEXT, due_date TEXT, task TEXT, category TEXT, postponeTimes INT DEFAULT 0, isDeleted INT DEFAULT 0)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Database cannot be created");
            }
            
            
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {
            TableCreation();
            ShowData();
            

            maskedTextBox2_SetDate.Text = DateTime.Now.ToString("dd/MM/yy");


        }

        private void button1_AddTask_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);


            try
            {
                
                cmd.CommandText = "INSERT INTO ToDoList(status, date, due_date, task, category) " +
                "VALUES (@status, @date, @due_date, @task, @category) returning id";

                string STATUS = "in progress";
                string DATE = maskedTextBox2_SetDate.Text;
                string TASK = textBox_task.Text;
                string CATEGORY = textBox_category.Text;
                string DUE_DATE = maskedTextBox1_DueDate.Text;


                cmd.Parameters.AddWithValue("@status", STATUS);
                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@due_date", DUE_DATE);
                cmd.Parameters.AddWithValue("@task", TASK);
                cmd.Parameters.AddWithValue("@category", CATEGORY);
                
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                string[] row = new string[] { Convert.ToString(id), STATUS, DATE, DUE_DATE, TASK, CATEGORY  };
                dataGridView1.Rows.Insert(0, row);



                maskedTextBox2_SetDate.Text = String.Empty;
                maskedTextBox1_DueDate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
                maskedTextBox2_SetDate.Text = DateTime.Now.ToString("dd/MM/yy");
            }
            catch (Exception)
            {
                Console.WriteLine("It is not possible to insert the data");

            }
        }

        private void button4_DeleteTask_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

                
            var cmd = new SQLiteCommand(con);
                
            try
            {
                
                cmd.CommandText = "UPDATE ToDoList SET isDeleted = 1 WHERE id = @id";
                cmd.Prepare();
                var rowIndex = dataGridView1.CurrentCell.RowIndex;
                
                cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[0].Value);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(rowIndex);

                maskedTextBox2_SetDate.Text = String.Empty;
                maskedTextBox1_DueDate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
                maskedTextBox2_SetDate.Text = DateTime.Now.ToString("dd/MM/yy");

            }
            catch (Exception)
            {
                Console.WriteLine("Data cannot be updated");
            }
        }

        private void button2_CompleteTask_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE ToDoList SET status = 'Completed' WHERE id = @id";
                cmd.Prepare();
                var rowIndex = dataGridView1.CurrentCell.RowIndex;
                cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[0].Value);

                cmd.ExecuteNonQuery();
                
                dataGridView1.Rows[rowIndex].Cells[1].Value = "Completed";
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;


                maskedTextBox2_SetDate.Text = String.Empty;
                maskedTextBox1_DueDate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
                maskedTextBox2_SetDate.Text = DateTime.Now.ToString("dd/MM/yy");
            }
            catch (Exception)
            {
                Console.WriteLine("Data cannot be updated");
            }

        }

        private void button3_PostponeTask_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE ToDoList SET status = 'Postponed', postponeTimes = postponeTimes + 1, due_date = @due_date WHERE id = @id";
                cmd.Prepare();
                
                var rowIndex = dataGridView1.CurrentCell.RowIndex;
                cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[rowIndex].Cells[0].Value);
                cmd.Parameters.AddWithValue("@due_date", maskedTextBox1_DueDate.Text);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows[rowIndex].Cells[3].Value = maskedTextBox1_DueDate.Text;
                dataGridView1.Rows[rowIndex].Cells[1].Value = "Postponed";
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                DateTime currentDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yy"), "dd/MM/yy", null);
                DateTime tableDate = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells[3].Value);
                int res = DateTime.Compare(currentDate, tableDate);

                if (res != -1 && Convert.ToString(dataGridView1.Rows[rowIndex].Cells[1].Value) != "Completed")
                {
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    
                }

                maskedTextBox2_SetDate.Text = String.Empty;
                maskedTextBox1_DueDate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
                maskedTextBox2_SetDate.Text = DateTime.Now.ToString("dd/MM/yy");

                cmd.CommandText = "SELECT * FROM ToDoList WHERE postponeTimes >= 3";
                int checkCmd = Convert.ToInt32(cmd.ExecuteScalar());

                if (checkCmd != 0)
                {
                    string message = $"There are tasks that you already have been postponed more than three times ";
                    string title = "Get things done!";
                    MessageBox.Show(message, title);
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Data cannot be updated");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                maskedTextBox2_SetDate.Text = dataGridView1.Rows[e.RowIndex].Cells["date"].FormattedValue.ToString();
                maskedTextBox1_DueDate.Text = dataGridView1.Rows[e.RowIndex].Cells["due_date"].FormattedValue.ToString();
                textBox_task.Text = dataGridView1.Rows[e.RowIndex].Cells["task"].FormattedValue.ToString();
                textBox_category.Text = dataGridView1.Rows[e.RowIndex].Cells["category"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void textBox_filter_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox_filter.Text))
            {
                for (int u = 0; u < dataGridView1.RowCount; u++)
                {
                    if (dataGridView1.Rows[u].Cells[1].Value != null)
                    {
                        if (Convert.ToString(dataGridView1.Rows[u].Cells[1].Value).ToLower() != Convert.ToString(textBox_filter.Text).ToLower())
                        {
                            dataGridView1.Rows[u].Visible = false;
                        }
                        else
                        {
                            dataGridView1.Rows[u].Visible = true;
                        }
                    }

                }
            }
            else
            {
                for (int u = 0; u < dataGridView1.RowCount; u++)
                {
                    dataGridView1.Rows[u].Visible = true;
                }
            }
        }
    }
}
