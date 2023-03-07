using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using System.Xml.Linq;

namespace PrepopulatedDataSql
{
    /// <summary>
    /// Interaction logic for PopulateData.xaml
    /// </summary>
    public partial class PopulateData : Window
    {
        public PopulateData()
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


                


                string query = " select * from SignupTable_ where ID = '"+this.firstNameblock.Text + "'";
                //Establish a sql command

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                 SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {

                    firstNameblock.Text = reader["FirstName"].ToString();
                    lastNameblock.Text = reader["LastName"].ToString();
                    emailblock.Text = reader["Email"].ToString();
                    passwordBlock.Text = reader["Password"].ToString(); 

                }


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

