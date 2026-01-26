  Farmer Product Management System

1 Download and Extract the Project
* Download the project .zip file
* Right-click → Extract All
* Place the folder in a suitable location (e.g., Documents\Projects)

2️ Open in Visual Studio
* Open Visual Studio 2022 or later
* Click Open a project or solution
* Select the .sln file inside the extracted folder

3️ Restore Dependencies
* Allow Visual Studio to restore NuGet packages automatically

4️ Configure Database
* Ensure appsettings.json contains a valid connection string:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FarmerDb;Trusted_Connection=True;"
}

5️ Run the Application
* Press F5 or click Start
* The database will be created automatically
* Sample data will be seeded on first run

Employee Login:
Username/Email: admin@example.com
Password: adminpass

User Roles and Features
FARMER
* Log in using email and password
* Add new products
* View a list of their own products only

🧑‍💼 Employee
* Log in using email and password
* Add new farmer profiles
* View a list of all registered farmers
* Filter products by:
  - Category
  - Production date
