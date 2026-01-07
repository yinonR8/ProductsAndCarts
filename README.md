# ASP.NET Simple Shopping Cart 🛒

A lightweight e-commerce simulation built using ASP.NET Web Forms. This project demonstrates fundamental concepts of web development, including state management, page navigation, and data serialization.

## Overview
This application simulates a basic online shopping experience. Users can browse a list of hardcoded products, add them to a virtual cart, and view the total cost on a separate cart page. The project is unique in that it showcases two distinct methods of persisting data: client-side (via JavaScript and SessionStorage) and server-side (via C# and HTTP Cookies).



## Features

### 🛍️ Product Management
* Displays a list of available products (Product 1 - Product 4).
* Dynamic pricing retrieval based on product selection.
* **"Add to Cart"** functionality that updates the user's session.

### 🛒 Cart Functionality
* **View Cart:** dynamically renders a table of selected items.
* **Total Calculation:** Automatically sums the prices of all items in the cart.
* **State Persistence:** Keeps cart items available even when navigating between pages.

## Technical Highlights

* **Backend:** C# / ASP.NET Web Forms.
* **Frontend:** HTML5, JavaScript.
* **State Management:**
    * **Cookies:** Used by the server-side code to store serialized JSON data of the cart items.
    * **SessionStorage:** Used by the client-side JavaScript to store cart data locally in the browser.
* **Data Serialization:** Uses `Newtonsoft.Json` (or `JavaScriptSerializer`) to convert Cart objects to JSON strings for storage.

## Project Structure

* **Products.aspx:** The main landing page where users select items. It handles the logic for creating cookies and clearing old sessions.
* **Cart.aspx:** The checkout simulation page. It reads the stored data (from Cookies in C# or Storage in JS) and renders the itemized list and total price.

## How to Run
1.  Open the solution file in **Visual Studio**.
2.  Ensure you have the necessary references (like `Newtonsoft.Json` or `System.Web.Extensions`).
3.  Set `MainPage.aspx` or `Products.aspx` as the start page.
4.  Run the application using IIS Express.

## Requirements
* Visual Studio (2019 or later recommended)
* .NET Framework
