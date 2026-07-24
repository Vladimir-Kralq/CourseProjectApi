# CourseProjectApi

ASP.NET Core Web API for course management — built as a university course project.

## 📋 Overview
A backend system for managing university courses, including:
- User and role management (Admin, Teacher, Student)
- Course creation and enrollment
- Team and team member management
- Assignments and submissions tracking

## 🛠️ Built With
- ASP.NET Core Web API
- Entity Framework Core (with migrations)
- DTOs and mapping layer for clean data transfer
- RESTful controllers (Users, Roles, UserRoles)

## 📁 Structure
- **Controllers** – API endpoints
- **Models** – Course, Enrollment, Team, Assignment, Submission, User, Role
- **Data** – ApplicationDbContext (EF Core)
- **Dtos / Helpers** – Data transfer objects and mappers
