# 🖥️ MVC Client — Interface for the Expense Management System API

This repository contains the MVC client used to consume the APIs of the Expense Management System project (Programming 3 — Mandatory Assignment).

Important: This client does not follow Clean Architecture nor a well-organized structure.
It was developed solely with the goal of learning:

- How to consume APIs from MVC controllers
- How to structure requests from a client application
- How to handle DTOs to send data to the server
- How Client ⇄ Server interaction works in ASP.NET MVC

---

## 🧠 What does this client do?

The client allows you to:

- Send data to the backend API
- Display information returned by the API
- Create users, payments, expenses, teams (depending on what is implemented)
- Validate that server endpoints work correctly
- Interact with the API without Postman, using only MVC views

It does NOT implement:
- Clean Architecture
- Full validations
- Advanced error handling
- Security (beyond sending a JWT when required)

This is a simple, instrumental, academic client.

---

🏗️ Project Structure (Client)

📦 N3C_348209_Client/
|
├── Controllers/                         # MVC controllers that consume the API
|   ├── UserController.cs
|   ├── ExpenseController.cs
|   ├── PaymentController.cs
|   └── TeamController.cs
|
├── Views/                               # Views associated with each controller
|   ├── User/
|   ├── Expense/
|   ├── Payment/
|   └── Team/
|
├── Models/                              # DTOs used to send/receive data
|
├── Program.cs                           # Basic configuration
└── appsettings.json                     # Backend URL + client settings



# 🔌 Backend Communication

This client sends requests to the backend using:

- HttpClient
- Local DTOs matching the backend DTOs
- JSON payloads via POST / PUT
- Endpoints defined in the server project

General request example (conceptual):

Serialize DTO to JSON  
Create StringContent with application/json  
Send POST request to https://yourserver/api/expenses using HttpClient  

---

# 🌐 Requirements

- The backend server (API) must be running.
- Configure the API URL in appsettings.json:

ApiUrl: https://localhost:7010/api

- Run the project using Visual Studio or VS Code.

---

# 🚀 How to Run

1. Clone the repository:
   git clone https://github.com/youruser/N3C_348209_Client.git

2. Configure the backend URL in appsettings.json.

3. Run the project:
   F5 in Visual Studio
   or
   dotnet run

4. Navigate through the views and test API interactions.

---

# 📌 Code Quality Disclaimer

This client is not intended to be a professional, production-ready project.
It was created exclusively to:

- Learn MVC → API communication
- Validate backend use cases
- Practice endpoint consumption
- Progress in Programming 3

It does not represent a real frontend nor a clean architecture.

---

# 🧑‍💻 Author

Developed by Mauricio Parodi 🇺🇾
MVC client for the Programming 3 mandatory assignment – ORT University.
