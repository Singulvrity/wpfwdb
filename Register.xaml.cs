using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfwdb
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        //Same connection string as the login page
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=wpfwdb.ApplicationDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //hash password
        private string HashPassword(string password)
        {
            using(SHA256 sHA256= SHA256.Create())
            {
                byte[] hashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Now put the string back
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b  in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString(); 
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserTxtbox.Text;
            string password = PasswordTxtbox.Text;
            string confirmpassword = ConfirmPassTxtbox.Text;
            string email = EmailTxtbox.Text;

            if (password == confirmpassword) 
            { 
                //logic of hashing
                string hashedPassword = HashPassword(password);
                //Now connect to the table
                using(SqlConnection connection = new SqlConnection(connectionString)) 
                { 
                    connection.Open();
                    //Create the query for the INSERT ST
                    string query = "INSERT INTO [User] (@Username,@Password,@Email) VALUES";
                    using(SqlCommand command = new SqlCommand(query, connection)) 
                    { 
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Email", email);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registration successful");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Registration failed");
            }
        }
    }
}
