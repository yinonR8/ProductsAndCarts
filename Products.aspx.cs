    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clear the cart items cookie on initial page load
                ClearCartItems();
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            string productName = ((Button)sender).CommandArgument;
            int price = GetProductPrice(productName);

            // Get existing cart items from cookies
            List<CartItem> cartItems = GetCartItems();

            // Add the selected product to the cart
            cartItems.Add(new CartItem { Name = productName, Price = price });

            // Save updated cart items to cookies
            SaveCartItems(cartItems);

            // Provide feedback to the user
            Response.Write("<script>alert('Product added to cart!');</script>");
        }

        private List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems = new List<CartItem>();

            // Check if the cart items cookie exists
            if (Request.Cookies["cartItems"] != null)
            {
                // Retrieve the cart items from the cookie
                string cookieValue = Server.HtmlDecode(Request.Cookies["cartItems"].Value);
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cookieValue);
            }

            return cartItems;
        }

        private void SaveCartItems(List<CartItem> cartItems)
        {
            string cookieValue = Newtonsoft.Json.JsonConvert.SerializeObject(cartItems);

            // Save the cart items to the cookie
            HttpCookie cartItemsCookie = new HttpCookie("cartItems", Server.HtmlEncode(cookieValue));
            Response.Cookies.Add(cartItemsCookie);
        }

        private void ClearCartItems()
        {
            // Clear the cart items cookie
            if (Request.Cookies["cartItems"] != null)
            {
                Response.Cookies["cartItems"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        private int GetProductPrice(string productName)
        {
            // Switch to retrieve product's price
            switch (productName)
            {
                case "Product 1":
                    return 10;
                case "Product 2":
                    return 20;
                case "Product 3":
                    return 15;
                case "Product 4":
                    return 25;
                default:
                    return 0;
            }
        }
        public class CartItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

    }
