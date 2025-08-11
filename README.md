# Product Store Web Application

## Background
- This is a web application built to apply CRUD (Create, Read, Update, Delete) for product store using ASP .Net Core and storing into local server using Server Management Studio.

## Setup Guide

### 1. Prerequisites
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)
- [SQL Server](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us)
- [SSMS](https://aka.ms/ssmsfullsetup)
- [Git](https://git-scm.com/downloads/win)

### 2. Database Configuration
**Connection String** (`appsettings.json`):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CafeteriaSystem;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
