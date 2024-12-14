using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using loginPage;

namespace loginPage
{
    public partial class cashier : Form
    {
        private readonly SqlConnection cashierConnection;
        public cashier()
        {
            InitializeComponent();
            cashierConnection = new SqlConnection(loginForm.connectionString);
        }

        private void OrderPicture_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cashier_Load(object sender, EventArgs e)
        {

        }
    }
}
