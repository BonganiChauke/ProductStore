# Product Store Web Application

## Background
- This is a web application built to apply CRUD (Create, Read, Update, Delete) for product store using ASP .Net Core and storing into local server using Server Management Studio. This project allows users to **create, edit, and delete products** with image uploads, stored in SQL Server using Entity Framework Core.

## Features
- Upload and manage product images
- Create, read, update, and delete products
- Responsive UI using Bootstrap 5
- Data stored in **SQL Server** 

## Tech Stack
- **ASP.NET Core 8** with Razor Pages
- **Entity Framework Core**
- **SQL Server**
- **Bootstrap 5** for UI
- **C#** for backend logic

## Setup Guide

### 1. Prerequisites
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)
- [SQL Server](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us)
- [SSMS](https://aka.ms/ssmsfullsetup)
- [Git](https://git-scm.com/downloads/win)

### 2. Database Configuration
- Update the DefaultConnection string with your SQL Server instance
**Connection String** (`appsettings.json`):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
### 3. Apply Migration
- Open Package Manager Console in Visual Studio and run:
```bash
Add-Migration InitialCreate
Update-Database
```
### 4. Run the Project
- Press F5 or click Start Debugging
- The app should open in your browser (e.g., https://localhost:5001)

## Project Structure
```bash
ProductStore/
│── Pages/                  # Razor Pages (UI)
│── Models/                 # Data models (Product, ProductDetail)
│── Services/               # Database context & services
│── wwwroot/                # Static files (CSS, JS, images)
│── appsettings.json        # Configuration file
│── Program.cs              # App startup
│── README.md               # Project documentation
```

## Image Upload Location
- Uploaded product images are stored in:
```bash
wwwroot/products/
```

