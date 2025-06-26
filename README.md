## Admin-Courses-Management
A web-based admin dashboard that allows administrators to manage courses, instructors, and departments with full CRUD functionality. Built using ASP.NET Core MVC following clean architectural principles.

🧩 Features
🔹 Manage Courses, Instructors, and Departments (Create, Read, Update, Delete)
🔹 Built using n-tier architecture with UnitOfWork pattern
🔹 Clean, modular code with Separation of Concerns
🔹 Fully Responsive UI using Bootstrap
🔹 Reusable Partial Views for better UI organization

--

🛠️ Tech Stack
Backend: ASP.NET Core MVC
Architecture: N-Tier Architecture + Unit of Work
Frontend: HTML, CSS, Bootstrap
Views: Razor Views + Partial Views

--

🚫 Authentication & Authorization
Authentication & Authorization are not yet implemented.
✅ Planned update: Add JWT-based Authentication and Role-based Authorization for Admins in future versions.

--

📌 Project Structure
│
├── DAL/                  # Data Access Layer (Repositories, Entities)
├── BLL/                  # Business Logic Layer (Services, Interfaces)
├── PL/                   # Presentation Layer (Controllers, Views)
├── wwwroot/              # Static files (CSS, JS, etc.)
└── AdminCourses.sln      # Solution file

--

🔮 Future Enhancements
✅ Add JWT Authentication
✅ Implement Admin Roles & Permissions
✅ Add logs and exception handling middleware



