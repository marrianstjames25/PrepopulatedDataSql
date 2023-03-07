using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace PrepopulatedDataSql
{
    /// <summary>
    /// Interaction logic for Random.xaml
    /// </summary>
    public partial class Random : Window
    {
        public Random()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SignUpDB; Integrated Security=True");

            try
            {


                //opening the connection to the db 

                sqlCon2.Open();

                //Build our actual query   
                string query = " Select FirstName,LastName,Email,Password from SignupTable_ where  ID = '"+Convert.ToInt32(txtID.Text)+ "'";
                //Establish a sql command
              
                SqlCommand cmd = new SqlCommand(query, sqlCon2);           
   
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                PopulateData pda = new PopulateData();

                while (reader.Read())
                {
                    
                    pda.firstNameblock.Text = reader["FirstName"].ToString();
                    pda.lastNameblock.Text = reader["LastName"].ToString();
                    pda.emailblock.Text = reader["Email"].ToString();
                    pda.passwordBlock.Text = reader["Password"].ToString();
                   
                    
                }
               
                pda.Show();


            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon2.Close();

            }
        }
    }
    }

