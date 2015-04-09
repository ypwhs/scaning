using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace scaning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string connect = "Server=.;User ID=sa;Password=;DataBase=book;";
                SqlConnection sql = new SqlConnection(connect);
                sql.Open();
                SqlCommand command = sql.CreateCommand();
                command.CommandText = "SELECT * from goods WHERE barcode LIKE '" + textBox1.Text + "'";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String name = (String)reader["name"];
                    String price = Convert.ToString(reader["price"]);
                    MessageBox.Show("物品名称：" + name + "\n价格：" + price);
                }
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
