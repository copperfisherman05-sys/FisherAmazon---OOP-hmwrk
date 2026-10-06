using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisherAmazon___OOP_hmwrk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //This will add sections to the ListView like a list with rows.
            ListView.View = View.Details;
            ListView.GridLines = true;
            ListView.FullRowSelect = true;

            ListView.Columns.Add("Product ID", 90);
            ListView.Columns.Add("Product Name", 90);
            ListView.Columns.Add("Product Description", 120);
            ListView.Columns.Add("Product Price", 90);
            ListView.Columns.Add("Product Category", 110);

            
        }


        //Count on how many objects are within the class (Old version)
        //public int count = 0;
        
        int Count = Product.productCounter; //This is to count how many objects are within the class Product.
                                              //This is a static variable that will be shared across all instances of the Product class.


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtProdName.Text))
            {
                return;
            }

            //To place data for each property
            Product product = new Product(
                txtID.Text,
                txtProdName.Text,
                txtProdDescription.Text,
                decimal.Parse(txtProdPrice.Text),
                txtProdCategory.Text
           );
           

            ListViewItem item = new ListViewItem(product.ProductId);

            item.SubItems.Add(product.ProductName);
            item.SubItems.Add(product.ProductDescription);
            item.SubItems.Add(product.ProductPrice.ToString("C"));
            item.SubItems.Add(product.ProductCategory);
            

            ListView.Items.Add(item);


            //count = count + 1  (Old version)

            Count = ListView.Items.Count; //This will add every time someone adds a product to the listview.
                                          //This is a static variable that will be shared across all instances of the Product class.
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selected = ListView.SelectedItems.Cast<ListViewItem>().ToArray();
            if (selected.Length == 0)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            foreach (var item in selected)
            {
                ListView.Items.Remove(item);
            }

            /*    (Old version on how to remove items from the listview)
            while (ListView.SelectedItems.Count > 0)
            {
                //Will delete the chosen row or object from Listview
                ListView.Items.Remove(ListView.SelectedItems[0]);
            }
            */


            //count = Math.Max(0, count - selected.Length); (Old version on how to count after removing items from the listview)

            Count = Math.Max(0, Count - selected.Length); //This will remove the count of the items that were removed from the listview.
                                                          //This is a static variable that will be shared across all instances of the Product class.
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the textboxes
            txtID.Clear();
            txtProdName.Clear();
            txtProdDescription.Clear();
            txtProdPrice.Clear();  
            txtProdCategory.Clear();
        }
            
        private void btnCount_Click(object sender, EventArgs e)
        {
            //lblProductCount.Text = "Count:" + count; (Old version on how to display the count of the items in the listview)

            lblProductCount.Text = "Count: " + ListView.Items.Count; //This will display the count of the items in the listview.
                                                      //This is a static variable that will be shared across all instances of the Product class.
        }
    }
}
