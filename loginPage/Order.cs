using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using loginPage;
using Microsoft.Data.SqlClient; // Import this namespace for database connection

namespace loginPage
{
    public partial class Order : Form
    {
        private readonly SqlConnection orderdbconnection;

        public Order()
        {
            InitializeComponent();
            orderdbconnection = new SqlConnection(loginForm.connectionString);
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }
    }
}
