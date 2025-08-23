# 應用系統諮詢服務

- [English Version](README.md)
- 以 **ASP.NET MVC 5** 為架構的 **應用系統諮詢服務系統**。 



## 系統需求
- **IDE**：Visual Studio 2019 或 2022（含 .NET 開發工作負載）
- **資料庫**（若有）：SQL Server / SQL Server Express / LocalDB 皆可



## 資料夾結構
```bash
US5NET/                              # 專案根目錄（GitHub Repo Root）
├─ QuerSyst/                         # ASP.NET MVC 5 網站專案（主程式碼所在）
│  ├─ App_Start/                     # 啟動與全域設定（RouteConfig、FilterConfig、BundleConfig 登記點）
│  ├─ Content/                       # 前端樣式與靜態資源（CSS、字型、圖片）
│  ├─ Controllers/                   # 控制器：處理用例流程、驗證輸入、回傳 View/Json/File
│  ├─ FileUploads/                   # 上傳檔案儲存區（諮詢問題附件；由下載 Action 輸出）
│  ├─ Models/
│  │  └─ US/                         # 領域模型與 ViewModel/DTO（分類、問題、QA、附件、欄位驗證）
│  ├─ Properties/                    # 專案屬性與組件資訊（AssemblyInfo）
│  ├─ Scripts/                       # 前端 JS（查詢/分頁、表單驗證、AJAX 呼叫、互動邏輯）
│  ├─ Views/                         # Razor 視圖；Shared/_Layout.cshtml 為全站共用版型
│  ├─ images/                        # 網站圖片（Logo、插圖、圖示）
│  ├─ Global.asax                    # 應用程式入口；Application_Start() 註冊路由/篩選器/Bundle
│  ├─ Global.asax.cs                 # Global.asax 的程式碼後置
│  ├─ US5NET.csproj                  # 專案檔（編譯項目、組態、目標 .NET Framework）
│  ├─ Web.Debug.config               # Debug 組態 Transform（本機/測試設定）
│  ├─ Web.Release.config             # Release 組態 Transform（正式環境設定）
│  └─ Web.config                     # 核心設定（連線字串、appSettings、驗證授權、IIS 行為/限制）
├─ .gitattributes                    # Git 屬性：行尾（EOL）正規化、合併策略、LFS 指定（如有）
├─ .gitignore                        # 忽略建置/IDE/使用者檔（bin/obj、.vs、*.user、packages/ 等）
└─ US5NET.sln                        # Visual Studio 解決方案（載入/管理整個方案與組態）
```
