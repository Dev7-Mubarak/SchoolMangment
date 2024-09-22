# 🏫 School Management API

A robust **School Management API** built using **Clean Architecture** to provide structured, scalable, and maintainable code. This API facilitates managing students, teachers, classes, and other school resources. Authentication is secured using **JWT tokens** with **refresh tokens** for session management.

## ✨ Features
- 📚 Manage students, teachers, classes, and subjects.
- 📝 CRUD operations for school resources.
- 🔐 Secure authentication using **JWT**.
- ♻️ Refresh tokens for extended session management.
- 🏗️ Modular and scalable design using **Clean Architecture**.

## 🛠️ Technologies Used
- **ASP.NET Core** for the backend framework.
- **Entity Framework Core** for database management.
- **JWT** for authentication.
- **Refresh Token** for session renewal.
- **Clean Architecture** to organize the codebase.
- **SQL Server** as the primary database.

## 📑 API Endpoints

### Authentication
- `POST /auth/login` – Login with email and password to receive a **JWT token** and **refresh token**.
- `POST /auth/refresh` – Get a new **JWT token** using a valid **refresh token**.
- `POST /auth/register` – Register a new user.

### Students
- `GET /students` – Get a list of all students.
- `POST /students` – Add a new student.
- `PUT /students/{id}` – Update student details.
- `DELETE /students/{id}` – Delete a student.

### Teachers
- `GET /teachers` – Get a list of all teachers.
- `POST /teachers` – Add a new teacher.
- `PUT /teachers/{id}` – Update teacher details.
- `DELETE /teachers/{id}` – Delete a teacher.

### Classes
- `GET /classes` – Get a list of all classes.
- `POST /classes` – Add a new class.
- `PUT /classes/{id}` – Update class details.
- `DELETE /classes/{id}` – Delete a class.

## 🚀 Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/username/school-management-api.git
   ```

2. **Navigate to the project directory**:
   ```bash
   cd school-management-api
   ```

3. **Install the necessary packages**:
   ```bash
   dotnet restore
   ```

4. **Apply database migrations**:
   ```bash
   dotnet ef database update
   ```

5. **Run the API**:
   ```bash
   dotnet run
   ```

## 🛠️ Clean Architecture

The project follows the **Clean Architecture** principles, ensuring separation of concerns across the following layers:

1. **Domain** – Contains core business logic and entities.
2. **Application** – Contains use cases and business rules.
3. **Infrastructure** – Handles external concerns like databases.
4. **Presentation** – Exposes the API endpoints.

## 🔐 JWT & Refresh Tokens

### JWT (JSON Web Tokens)
- After successful login, users receive a **JWT** token used for API authentication.
- The **JWT** token has a short expiry time for enhanced security.

### Refresh Tokens
- To extend the session without forcing the user to log in again, the **Refresh Token** is issued alongside the **JWT** token.
- Clients can request a new **JWT** token using the **Refresh Token**.

### Example Authentication Flow
1. **Login** → Client sends credentials → Receives **JWT** + **Refresh Token**.
2. **Access Secured Endpoints** → Include **JWT** in the `Authorization` header.
3. **Token Expiry** → Use **Refresh Token** to get a new **JWT** without logging in again.

## 📂 Folder Structure

```
src/
│
├── Application/           # Use cases, interfaces, DTOs
├── Domain/                # Core business logic and entities
├── Infrastructure/        # Database access, external services
├── Presentation/          # API controllers and middleware
└── Tests/                 # Unit and integration tests
```

## 🤝 Contributing

We welcome contributions! Please follow these steps:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -m 'Add feature'`).
4. Push the branch (`git push origin feature-branch`).
5. Open a pull request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
