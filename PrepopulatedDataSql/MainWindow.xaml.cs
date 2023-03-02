using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrepopulatedDataSql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SignUpDB; Integrated Security=True");

            try
            {


                //opening the connection to the db 

                sqlCon.Open();

                //Build our actual query 

                string query = "INSERT INTO SignUpTable_(FirstName,LastName,Email,Username,Password)values ('" + this.txtFirstName.Text + "','" + this.txtLastName.Text + "','" + this.txtEmail.Text + "','" + this.txtUsername.Text + "','" + this.PasswordBox.Password + "') ";

                //Establish a sql command

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");

                //LogIn_ lg = new LogIn_();
                //lg.Show();
                //this.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon.Close();

            }
        }
    }
 }

