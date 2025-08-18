
# Smart Inventory System – COMP2139 Web Application Development Project

This repository contains the final group project for COMP2139 – Web Application Development at George Brown College (Semester 4, 2025).
The Smart Inventory System is a full-stack web application for managing products, categories, and orders.

This project was developed collaboratively by a team of three members.
My contributions included building the Authentication system, Admin and User Dashboards, Database Structure, UI improvements, and fixing key functionalities.



# Project Overview
  The Smart Inventory System allows:

  - Admin users to create and manage product categories, products, and view all orders
  - Regular users to browse inventory, place orders, and manage their profiles
  - Secure login and registration with role-based access
  - Real-time logging of system activities using Serilog

 
* 
# 1️⃣ Create the PostgreSQL database (Modify username/password if needed)
psql -U postgres -c "CREATE DATABASE smart_inventory;"

# 2️⃣ Apply database migrations (Creates tables in DB)
dotnet ef database update

# 3️⃣ Run the application
dotnet run 

# 4️⃣ To Access Manager Account 
Email: admin@inventory.com
Pass: Admin1912/*


 
## 📌 Key Features

  - User Registration and Authentication
  - Role-Based Authorization (Admin / Regular User)
  - Product and Category Management (CRUD operations)
  - Order Placement by Users
  - Logging of system events using Serilog
  - Error handling pages (404 Not Found and 500 Server Error)
  - Responsive Bootstrap Design
 
# My Contributions

  - Designed and implemented major UI components (Navbar, Header, Footer).
  - Developed and fixed functionalities for Edit, Delete, and Details pages.
  - Built and styled custom Search and Track Orders functionalities.
  - Resolved critical bugs in Login, Logout, and Profile Management flows.
  - Created custom 404 and 500 error pages for better user experience.
  - Improved backend controllers for Products and Orders with proper error handling and logging.
  - Assisted with database structure updates, migration management, and deployment configuration.
  - Managed layout updates for better navigation and user experience across the platform.

## 📷 Screenshots

### 1️⃣  Login
<img width="800" height="893" alt="image" src="https://github.com/user-attachments/assets/ab69cb22-a33b-4050-842b-73a0b16475c1" />
Users can sign in with email and password. Links are provided for password reset, new user registration, and resending email confirmation.

### 2️⃣ Register
<img width="800" height="900" alt="image" src="https://github.com/user-attachments/assets/24439ab7-0559-4bb0-853f-f0a009b7470e" />
New account creation with first name, last name, email, password, and confirm password.

### 3️⃣ Dashboard (Welcome)
<img width="800" height="900" alt="image" src="https://github.com/user-attachments/assets/7db9fb9a-57f1-42c9-b9f4-dde30f6fd5d3" />
Welcome panel with quick actions to **Manage Categories**, **Manage Products**, and **Manage Orders**.

### 4️⃣ Categories
<img width="800" height="867" alt="image" src="https://github.com/user-attachments/assets/4881a59b-0993-4894-b803-697f55e6cf50" />
Category management (list, **Edit**, **Delete**) with an **Add New Category** button.

### 5️⃣ Products (with search)
<img width="800" height="885" alt="image" src="https://github.com/user-attachments/assets/19d81a80-eaf9-46e0-aa18-2f498beea552" />
Products table with **Category**, **Price**, **Stock**, and action buttons (**Edit**, **Details**, **Delete**).  
A search box allows filtering by product name or category, plus an **Add New Product** action.

### 6️⃣ Orders
<img width="800" height="847" alt="image" src="https://github.com/user-attachments/assets/df46655a-2815-4eda-85a8-aa80a66bb14b" />
Orders list showing **Guest Name**, **Order Date**, **Total Price**, and **Status** (Pending/Completed/Cancelled) with actions (**Edit**, **Details**, **Delete**).

### 7️⃣ Order Items
<img width="800" height="866" alt="image" src="https://github.com/user-attachments/assets/faa49905-6ae9-4e68-876f-85c42e3ad547" />
Drill-down into the order’s items, including **Product**, **Quantity**, **Price**, and actions (**Edit**, **Details**, **Delete**). A **Create New Order Item** button is available.










