# DOT_NET_lab_11 - Smart Campus Service Portal

Practical 11 implementation based on the supplied experiment PDF. This project targets **.NET 6** and uses **SQLite + Entity Framework Core 6**, so it is suitable for the user's .NET 6 development setup.

## Requirements
- .NET 6 SDK
- Internet connection on first run to restore NuGet packages

## Run on macOS (Terminal)
1. Extract `DOT_NET_lab_11.zip`.
2. Open Terminal and enter the extracted folder:
   ```bash
   cd ~/Downloads/DOT_NET_lab_11
   ```
   Change the path if you extracted it elsewhere.
3. Restore packages and run:
   ```bash
   dotnet restore
   dotnet run
   ```
4. Open the `http://localhost:xxxx` or `https://localhost:xxxx` URL printed in Terminal.

The SQLite database `campus.db` is created automatically and three demonstration requests are seeded on first launch.

## Features
- List campus service requests
- Search by student name, enrollment number, or category
- Submit a validated request
- Change request status (Pending, In Progress, Resolved)
- REST API: `GET /api/service-requests`, `GET /api/service-requests/{id}`, `POST /api/service-requests`, `PATCH /api/service-requests/{id}/status`

## Notes
- Stop the server with `Ctrl+C`.
- To reset the demo data, stop the app and delete `campus.db`; it will be recreated on next run.
- `bin/` and `obj/` are intentionally not included in the ZIP.
