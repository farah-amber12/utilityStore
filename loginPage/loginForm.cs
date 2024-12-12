

using System.Collections.Generic;
using System.Data;
using UtilityStoreApp;
//using Microsoft.Data.SqlClient;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.Data.SqlClient;
//using UtilityStoreApp;

namespace loginPage
{
    
    public partial class loginForm: Form
    {
       static string frhconnect = "Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=UtilityStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
       static  string equcoonect = "Data Source=DESKTOP-NJ11NR5\\SQLEXPRESS;Initial Catalog=Utility_Store;Integrated Security=True;Trust Server Certificate=True";
         
        public static string connectionString = frhconnect;
        

        public loginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            String username = tbUsername.Text;
            String password = tbPassword.Text;
            String role = comboBoxRole.SelectedItem.ToString(); // Assuming cbRole is a ComboBox

            //farah db : "Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=UtilityStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
            //eqan db : "Data Source=DESKTOP-NJ11NR5\\SQLEXPRESS;Initial Catalog=Utility_Store;Integrated Security=True;Trust Server Certificate=True"

       
           
                
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("VerifyStaffCredentials", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@UserPassword", password);
                        cmd.Parameters.AddWithValue("@Role", role);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read() && reader["Status"].ToString() == "Success")
                        {
                            string userRole = reader["Role"].ToString();

                            if (userRole == "manager")
                            {
                                manager managerForm = new manager();
                                managerForm.Show();
                            }
                            else if (userRole == "owner")
                            {
                               Form2  owner= new Form2();
                               owner.Show();
                            }
                            else if(userRole == "cashier")
                            {
                                cashier cashierForm = new cashier();
                                cashierForm.Show(); 
                            }
                           
                            else
                            {
                                MessageBox.Show("Unknown role. Please contact the administrator.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            this.Hide(); // Hide the current form after opening the new one
                        }

                       
                        else
                        {
                            MessageBox.Show("Invalid Username, Password, or Role!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }











        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxRole.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

