# Product Store Web Application

## Setup Guide

### 1. Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (comes with Visual Studio)
- [SSMS](https://aka.ms/ssmsfullsetup)
- Git

### 2. Database Configuration
**Connection String** (`appsettings.json`):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CafeteriaSystem;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
