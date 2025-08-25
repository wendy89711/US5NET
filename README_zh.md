# 應用系統諮詢服務

- [English Version](README.md)
- 以 **ASP.NET MVC 5** 為架構的 **應用系統諮詢服務系統**。 

![Project Demo](demo_image/UI_US5NET.png)

## 系統需求
- **IDE**：Visual Studio 2019 或 2022（含 .NET 開發工作負載）
- **資料庫**（若有）：SQL Server / SQL Server Express / LocalDB 皆可



## 專案結構
```bash
US5NET/                  
├─ Controllers
│  ├─ US1000                # 控制使用者端相關介面
│  ├─ US2000                # 控制開發者端相關介面
│  └─ HomeController.cs     # 控制首頁
├─ Models                   # 自動產生檔
├─ Views
│  ├─ Ansr                  # 介面：案件清單、回覆問題
│  ├─ Home                  # 介面：首頁、關於、聯繫
│  ├─ Quer                  # 介面：詢問問題
│  ├─ Shared                # 共享介面，如：發生錯誤
│  ├─ SystClass             # 介面：CRUD 問題分類
│  └─ SystQAdb              # 介面：CRUD Q&A
└─ ...                      
```
