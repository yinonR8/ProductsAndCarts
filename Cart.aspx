
<!DOCTYPE html>
<html>
<head>
    <title>Cart Page</title>
</head>
<body>
    <h1>Cart Page</h1>
    <form id="form1" runat="server">
        <table id="cartItemsTable">
            <thead>
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody id="cartItemsContainer">
                <!-- Cart items will be dynamically added here -->
            </tbody>
        </table>
    </form>

    <h2>Total Price: <asp:Label ID="totalPriceLabel" runat="server"></asp:Label></h2>

   <button><a href="Products.aspx">Back to Products</a></button>
    <button><a href="MainPage.aspx">Home</a></button>

    <script>
        // Load cart items on page load
        window.onload = function () {
            var cartItems = getCartItems();
            displayCartItems(cartItems);
            calculateTotalPrice(cartItems);
        }

        function displayCartItems(cartItems) {
            var cartItemsContainer = document.getElementById("cartItemsContainer");

            // Clear existing cart items
            cartItemsContainer.innerHTML = "";

            // Add each cart item to the table
            cartItems.forEach(function (item) {
                var row = document.createElement("tr");

                var nameCell = document.createElement("td");
                nameCell.textContent = item.name;
                row.appendChild(nameCell);

                var priceCell = document.createElement("td");
                priceCell.textContent = "$" + item.price;
                row.appendChild(priceCell);

                cartItemsContainer.appendChild(row);
            });
        }

        function calculateTotalPrice(cartItems) {
            var totalPrice = 0;

            // Calculate the total price
            cartItems.forEach(function (item) {
                totalPrice += item.price;
            });

            document.getElementById("<%= totalPriceLabel.ClientID %>").textContent = "$" + totalPrice;
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
