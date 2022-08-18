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
                dataGridView1.Rows.Insert(0, dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));
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


                    string sql = @"CREATE TABLE TodoList(id INTEGER PRIMARY KEY,
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO ToDoList(date, due_date, task, category) " +
                "VALUES (@date, @due_date, @task, @category)";

                string DATE = textBox_date.Text;
                string TASK = textBox_task.Text;
                string CATEGORY = textBox_category.Text;
                string DUE_DATE = textBox_duedate.Text;

                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@task", TASK);
                cmd.Parameters.AddWithValue("@category", CATEGORY);
                cmd.Parameters.AddWithValue("@due_date", DUE_DATE);

                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "Set date";
                dataGridView1.Columns[1].Name = "Due date";
                dataGridView1.Columns[2].Name = "Task";
                dataGridView1.Columns[3].Name = "Task category";
                

                string[] row = new string[] { DATE, DUE_DATE, TASK, CATEGORY };

                dataGridView1.Rows.Add(row);
                cmd.ExecuteNonQuery();
                textBox_date.Text = String.Empty;
                textBox_duedate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
            }
            catch (Exception)
            {
                Console.WriteLine("It is not possible to insert the data");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE ToDoList SET isDeleted = 1 WHERE date = @date";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", textBox_date.Text);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                ShowData();
                textBox_date.Text = String.Empty;
                textBox_duedate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
            }
            catch(Exception)
            {
                Console.WriteLine("Data cannot be updated");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE ToDoList SET due_date = 'Completed' WHERE date = @date";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", textBox_date.Text);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                ShowData();
                textBox_date.Text = String.Empty;
                textBox_duedate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;
            }
            catch (Exception)
            {
                Console.WriteLine("Data cannot be updated");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE ToDoList SET postponeTimes = postponeTimes + 1, due_date = @due_date WHERE date = @date";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@date", textBox_date.Text);
                cmd.Parameters.AddWithValue("@due_date", textBox_duedate.Text);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                ShowData();
                textBox_date.Text = String.Empty;
                textBox_duedate.Text = String.Empty;
                textBox_task.Text = String.Empty;
                textBox_category.Text = String.Empty;

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
    }
}
