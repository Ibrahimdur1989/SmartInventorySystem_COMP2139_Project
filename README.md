# 1️⃣ Create the PostgreSQL database (Modify username/password if needed)
psql -U postgres -c "CREATE DATABASE smart_inventory;"

# 2️⃣ Apply database migrations (Creates tables in DB)
dotnet ef database update

# 3️⃣ Run the application
dotnet run 
