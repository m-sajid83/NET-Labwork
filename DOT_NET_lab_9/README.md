# DOT_NET_lab_9 - Placement Dashboard

**Experiment 9:** Placement Dashboard with database access, data-bound tables and multi-page navigation.  
**Student details supplied:** Yatharthsinh Zala (92400103336), Batch A.

## Mac / .NET 6 version
The supplied practical uses ASP.NET Web Forms (`.aspx`, `System.Web`) and SQL Server. Web Forms requires Windows and .NET Framework, so this project implements the same features in ASP.NET Core MVC with SQLite for Mac and .NET 6.

## Features
- Placement overview: total placed, highest package and average package.
- All-students placement status table.
- Previous / Next pagination.
- Separate Company Details page with hiring summary and placed-student list.
- SQLite database and sample data are created automatically.

## Run
```bash
dotnet restore
dotnet run --urls http://localhost:5000
```
Open http://localhost:5000

The database is created at `bin/Debug/net6.0/placement.db`. Sample records can be edited in `Data/PlacementDb.cs`.
