# 📘 AcademicRecordsManager

A full-stack **ASP.NET MVC** web application designed to manage academic entities including **students**, **instructors**, **courses**, **departments**, and **student grades**. Built as part of a summer training bootcamp to simulate real-world university record systems.

---

## 🚀 Features

- 🔹 CRUD operations for Students, Instructors, Courses, Departments, and Grades  
- 🔹 Relational data management using **Entity Framework** (Code First)  
- 🔹 **SQL Server** integration for robust data storage  
- 🔹 Responsive frontend using **Bootstrap 5**  
- 🔹 Data validation, model binding, and clean controller logic  
- 🔹 Dynamic dropdowns and filterable views for better UX  

---

## 🛠️ Tech Stack

| Layer       | Technology         |
|-------------|--------------------|
| Backend     | ASP.NET Core MVC   |
| ORM         | Entity Framework   |
| Database    | SQL Server         |
| Frontend    | Bootstrap          |

---

## 📸 Screenshots

**Dashboard View**  
<img width="1267" alt="1" src="https://github.com/user-attachments/assets/0cf04264-54d9-40cf-9c60-9f6c39d9582d" />

**Grade Entry Page**  
<img width="975" alt="2" src="https://github.com/user-attachments/assets/2374e076-9e8c-42ff-88fc-a390c7338b28" />

---

## 📂 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/ysseff/AcademicRecordsManager.git
cd AcademicRecordsManager
```

### 2. Set Up the Database

- Update with your local SQL Server connection string.
- Open the terminal in project root and run:

```bash
dotnet ef database update
```

### 3. Run the App

```bash
dotnet run
```

---

## 📌 Future Improvements

- Role-based authentication (Admin, Instructor, Student)
- PDF/Excel export for grades
- Grade analytics and student performance charts
- REST API support for integration
  
