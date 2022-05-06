/*
 * ITSE 1430
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = true;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Handle errors
            try
            {
                //Save product
                _database.Add(child.Product);
                UpdateList();
            }  catch (ValidationException error)
            {
                var msg = error.ValidationResult.ErrorMessage;
                MessageBox.Show(this, msg, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception error)
            {
                MessageBox.Show(this, error.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Handle errors
            try
            {
                //Delete product
                _database.Remove(product.Id);
                UpdateList();
            } catch (Exception error)
            {
                MessageBox.Show(this, error.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Handle errors
            try
            {
                //Save product
                _database.Update(child.Product);
                UpdateList();
            } catch (Exception error)
            {
                MessageBox.Show(this, error.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            //Handle errors
            try
            {
                _bsProducts.DataSource = _database.GetAll();
            } catch (Exception error)
            {
                MessageBox.Show(this, error.Message, "Failed to get products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private string GetConnectionString ( string name )
                => Program.Configuration.GetConnectionString(name);

        private readonly IProductDatabase _database = new Nile.Stores.Sql.SqlProductDatabase(Program.Configuration.GetConnectionString("ProductDatabase"));
        #endregion

        private void OnAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }
    }
}
