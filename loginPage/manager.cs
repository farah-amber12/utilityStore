using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginPage
{
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void orderPicture_Click(object sender, EventArgs e)
        {
            // Open the next window
            Order placeOrder = new Order();
            placeOrder.Show();

            // Optional: Hide or close the current form
            this.Hide();
        }

        private void viewAddProducts_Click(object sender, EventArgs e)
        {
            Products addAndViewProducts = new Products();
            addAndViewProducts.Show();
            this.Hide();
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            this.Hide();
        }
    }
}
