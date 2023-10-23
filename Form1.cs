using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace InventoryForm
{

    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _ExpDate;
        private string _Category;
        private string _Description;
        private string _MfgDate;
        private double _SellPrice;
        private int _Quantity;

        private BindingSource showProductList;

        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            List<string> ListOfProductCategory = new List<string>
            {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other"
            };

            foreach (string element in ListOfProductCategory)
            {
                cbCategory.Items.Add(element);
            }
        }

        public class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message)
            {
            }
        }

        public class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message)
            {
            }
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message)
            {
            }
        }

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    string errorMessage = "Invalid name. Must not contain any special characters!";
                    throw new StringFormatException(errorMessage);
                }

                return name;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    string errorMessage = "The input must start with a digit (0-9). Please enter a valid numerical value.";
                    throw new NumberFormatException(errorMessage);
                }

                return Convert.ToInt32(qty);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    string errorMessage = "Invalid number format. Please enter a valid decimal number.";
                    throw new CurrencyFormatException(errorMessage);
                }

                return Convert.ToDouble(price);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description)); gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; gridViewProductList.DataSource = showProductList;

        }
    }
}