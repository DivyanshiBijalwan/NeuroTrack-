# ⚡ NeuroTrack — Brain Performance Analyzer

A full-stack **ASP.NET Core MVC** web application that tests and analyzes cognitive performance through three interactive tests.

---

## 🚀 Quick Setup

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or VS Code)
- SQL Server / SQL Server LocalDB (comes with Visual Studio)

### Steps

1. **Clone / open** the project in Visual Studio.

2. **Restore packages** (auto or run):
   ```
   dotnet restore
   ```

3. **Apply the database migration** to create the SQL table:
   ```
   dotnet ef database update
   ```
   Or in Package Manager Console:
   ```
   Update-Database
   ```

4. **Run the app**:
   ```
   dotnet run
   ```
   Then open `https://localhost:5001` in your browser.

---

## 📁 Project Structure

```
NeuroTrack/
├── Controllers/
│   ├── HomeController.cs       ← Landing page
│   └── TestController.cs       ← All tests + scoring + dashboard
├── Models/
│   ├── TestResult.cs           ← Database model
│   └── TestSessionViewModel.cs ← API input model
├── Data/
│   └── NeuroTrackDbContext.cs  ← EF Core DbContext
├── Migrations/                 ← EF migration files
├── Views/
│   ├── Shared/_Layout.cshtml   ← Site layout
│   ├── Home/Index.cshtml       ← Landing page
│   └── Test/
│       ├── Reaction.cshtml     ← Reaction time test
│       ├── Memory.cshtml       ← Card memory test
│       ├── Focus.cshtml        ← Focus accuracy test
│       ├── Dashboard.cshtml    ← Gamified results
│       └── History.cshtml      ← Past results + chart
└── wwwroot/css/site.css        ← Full dark neural stylesheet
```

---

## 🧩 How It Works

1. User lands on the home page → clicks **Start Tests**
2. Completes **Reaction** test → score stored in `sessionStorage`
3. Completes **Memory** test → score stored in `sessionStorage`
4. Completes **Focus** test → all scores POSTed to `/Test/Submit`
5. Backend calculates scores, saves to **SQL Server**, returns result ID
6. Browser redirects to `/Test/Dashboard/{id}` — gamified report
7. All past results viewable at `/Test/History`

---

## 🎮 Scoring Logic

| Test | Scoring |
|------|---------|
| Reaction | ≤200ms = 100pts, ≥800ms = 0pts, linear in between |
| Memory | 100 - (extra moves × 2) - (time × 0.5) |
| Focus | (hits / total clicks) × 100 |
| Overall | Average of all three scores |

**Levels:** Beginner (<50) · Intermediate (50–79) · Pro (≥80)

---

## 🔮 Future Enhancements
- User authentication (ASP.NET Identity)
- AI-based personalized improvement tips
- Mobile PWA support
- Leaderboard system
