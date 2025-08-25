# Application System Consultation Service Platform

- [繁體中文版](README_zh.md)
- An Application System Consultation Service Platform built with ASP.NET MVC 5.

![Project Demo](demo_image/UI_US5NET.png)

## System Requirements

- IDE: Visual Studio 2019 or 2022
- Database (if used): SQL Server / SQL Server Express / LocalDB


## Project Structure
```bash
US5NET/                  
├─ Controllers
│  ├─ US1000                # Controllers for user-side UIs
│  ├─ US2000                # Controllers for developer-side UIs
│  └─ HomeController.cs     # Home page controller
├─ Models                   # Auto-generated files
├─ Views
│  ├─ Ansr                  # Views: ticket list, reply to questions
│  ├─ Home                  # Views: Home, About, Contact
│  ├─ Quer                  # Views: ask/submit a question
│  ├─ Shared                # Shared views, e.g., error pages
│  ├─ SystClass             # Views: CRUD for question categories
│  └─ SystQAdb              # Views: CRUD for Q&A
└─ ...                      

```
