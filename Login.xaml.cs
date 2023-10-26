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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        //Connection String
        string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=wpfwdb.ApplicationDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //MEthod to hashpassword
        private string HashPassword(string password)
        {
            using(SHA256 sHA256= SHA256.Create())
            {
                byte[] hashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach(byte b in hashBytes) 
                { 
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
            
        }
        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Landing lands = new Landing();
            this.Hide();
            lands.Show();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
           
            //Fetch from the textboxes
            string enteredUsername = usernameTxtbox.Text;
            string enteredPassword = passwordTxtbox.Text;

            //Now send it to the hashmethod

            string hashedEnteredPassword= HashPassword(enteredPassword);

            //To be fixed in the next lecture with the registration page
            if(validateUser(enteredPassword, hashedEnteredPassword))
            {
                MessageBox.Show("Login successful");
            }
            else 
            {
                MessageBox.Show("Login unsuccessful");
            }
        }

        private bool validateUser(string username, string password) 
        { 
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                //Use parameterized query to prevent SQL injection
                string query = "SELECT COUNT(*) FROM [User] WHERE Username=@Username AND Password=@Password";
                using(SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@Username",username);
                    command.Parameters.AddWithValue("@Password",password);

                    int count = (int)command.ExecuteScalar();
                    if(count > 0) 
                    {
                        //user is valid
                        return true;
                    }

                }
            }
            //User is not valid
            return false;
        }

       
    }
}
