
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


 
# Key Features

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



