<!DOCTYPE html>
<html>
<head>
    <title>Product Page</title>
</head>
<body>
    <h1>Product Page</h1>

    <div class="product">
        <h2>Product 1</h2>
        <p>Price: $10</p>
        <button onclick="addToCart('Product 1', 10)">Add to Cart</button>
    </div>

    <div class="product">
        <h2>Product 2</h2>
        <p>Price: $20</p>
        <button onclick="addToCart('Product 2', 20)">Add to Cart</button>
    </div>

    <div class="product">
        <h2>Product 3</h2>
        <p>Price: $15</p>
        <button onclick="addToCart('Product 3', 15)">Add to Cart</button>
    </div>

    <div class="product">
        <h2>Product 4</h2>
        <p>Price: $25</p>
        <button onclick="addToCart('Product 4', 25)">Add to Cart</button>
    </div>

   <button><a href="Cart.aspx">View Cart</a></button>
    <button><a href="MainPage.aspx">Home</a></button>

    <script>
        function addToCart(productName, price) {
            // Get existing cart items from session storage
            var cartItems = getCartItems();

            // Add the selected product to the cart
            cartItems.push({ name: productName, price: price });

            // Save updated cart items to session storage
            sessionStorage.setItem("cartItems", JSON.stringify(cartItems));

            // Provide feedback to the user
            alert("Product added to cart!");
        }

        function getCartItems() {
            var cartItems = [];

            // Check if the cart items exist in session storage
            var cartItemsJson = sessionStorage.getItem("cartItems");
            if (cartItemsJson) {
                cartItems = JSON.parse(cartItemsJson);
            }

            return cartItems;
        }
    </script>
</body>
</html>
