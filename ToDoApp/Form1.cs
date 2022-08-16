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

            string stm = "SELECT * FROM TodoList";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr.GetString(1), dr.GetString(2), dr.GetString(3));
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
            date TEXT, task TEXT, category TEXT, postponeTimes INT, isDeleted INT)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                //Console.WriteLine("Database cannot be created");
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
                cmd.CommandText = "INSERT INTO ToDoList(date, task, category) " +
                "VALUES (@date, @task, @category)";

                string DATE = textBox_date.Text;
                string TASK = textBox_task.Text;
                string CATEGORY = textBox_category.Text;

                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@task", TASK);
                cmd.Parameters.AddWithValue("@category", CATEGORY);

                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Task date";
                dataGridView1.Columns[1].Name = "Task";
                dataGridView1.Columns[2].Name = "Task category";

                string[] row = new string[] { DATE, TASK, CATEGORY };

                dataGridView1.Rows.Add(row);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("It is not possible to insert the data");

            }
        }
    }
}
