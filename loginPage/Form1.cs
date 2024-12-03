using System.Collections.Generic;
using System.Data;

//using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace loginPage
{
    public partial class Form1 : Form
    {
        public Form1()
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

                string connectionString = "Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=UtilityStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
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
                                MessageBox.Show($"Login Successful! Role: {reader["Role"]}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
