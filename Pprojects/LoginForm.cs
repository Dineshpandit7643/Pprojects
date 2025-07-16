using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BCrypt.Net;



namespace Pprojects
{

    public partial class LoginForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-6SDSPSO;Initial Catalog=YourDatabase;Integrated Security=True;";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query = "SELECT PasswordHash FROM Users WHERE Username=@Username";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);

            //    conn.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        string storedHash = reader["PasswordHash"].ToString();
            //        if (BCrypt.Net.BCrypt.Verify(txtPassword.Text, storedHash))
            //        {
            //            MessageBox.Show("Login Successful!");
            //           // Dashboard dashboard = new Dashboard(txtUsername.Text);
            //          //  dashboard.Show();
            //            this.Hide();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid Password.");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("User not found.");
            //    }
            //}

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query = "SELECT PasswordHash FROM Users WHERE Username=@Username";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

            //    conn.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        string storedHash = reader["PasswordHash"].ToString();

            //        // ✅ Ensure password verification is working
            //        if (!string.IsNullOrEmpty(storedHash) && BCrypt.Net.BCrypt.Verify(txtPassword.Text, storedHash))
            //        {
            //            MessageBox.Show("Login Successful!");
            //            this.Hide();
            //            //Dashboard dashboard = new Dashboard(); // Open next form
            //            //dashboard.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid Password. Please try again.");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("User not found. Please check your username.");
            //    }
            // }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PasswordHash FROM Users WHERE Username=@Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHash = reader["PasswordHash"].ToString();

                    // ✅ Fix: Ensure storedHash is valid
                    if (!string.IsNullOrEmpty(storedHash) && storedHash.Length >= 10)
                    {
                        // ✅ Fix: Ensure correct password verification
                        if (BCrypt.Net.BCrypt.Verify(txtPassword.Text, storedHash))
                        {
                            MessageBox.Show("Login Successful!");
                            this.Hide();
                          //  Dashboard dashboard = new Dashboard();
                           // dashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Password data is corrupted.");
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }




        }
    }
}
