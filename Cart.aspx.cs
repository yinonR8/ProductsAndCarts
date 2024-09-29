    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<CartItem> cartItems = GetCartItems();
                    DisplayCartItems(cartItems);
                    CalculateTotalPrice(cartItems);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message for debugging purposes
                Response.Write(" ");
            }
        }

        private List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems;

            if (Request.Cookies["cartItems"] != null)
            {
                string cookieValue = Server.HtmlDecode(Request.Cookies["cartItems"].Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                cartItems = serializer.Deserialize<List<CartItem>>(cookieValue);
            }
            else
            {
                cartItems = new List<CartItem>();
            }

            return cartItems;
        }

        private void DisplayCartItems(List<CartItem> cartItems)
        {
            Table cartItemsTable = FindControlRecursive<Table>(form1, "cartItemsTable");

            foreach (CartItem item in cartItems)
            {
                TableRow row = new TableRow();

                TableCell nameCell = new TableCell();
                nameCell.Text = item.name;
                row.Cells.Add(nameCell);

                TableCell priceCell = new TableCell();
                priceCell.Text = "$" + item.price.ToString();
                row.Cells.Add(priceCell);

                cartItemsTable.Rows.Add(row);
            }
        }

        private T FindControlRecursive<T>(Control root, string controlId) where T : Control
        {
            if (root.ID == controlId)
            {
                return (T)root;
            }

            foreach (Control control in root.Controls)
            {
                T foundControl = FindControlRecursive<T>(control, controlId);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }

            return null;
        }

        private void CalculateTotalPrice(List<CartItem> cartItems)
        {
            Label totalPriceLabel = FindControlRecursive<Label>(form1, "totalPriceLabel");

            decimal totalPrice = 0;

            foreach (CartItem item in cartItems)
            {
                totalPrice += item.price;
            }

            totalPriceLabel.Text = "$" + totalPrice.ToString();
        }

        public class CartItem
        {
            public string name { get; set; }
            public decimal price { get; set; }
        }
    }
