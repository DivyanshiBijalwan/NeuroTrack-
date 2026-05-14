# 🧠 NeuroTrack — Brain Performance Analyzer

A web-based cognitive performance analyzer built
with ASP.NET Core MVC and C# that tests Reaction
Speed, Memory, and Focus through three interactive
anime-themed games and displays results on a
gamified dashboard.

---

## 🛠️ Tech Stack

- **Backend** — C# / ASP.NET Core MVC
- **Frontend** — HTML / CSS / JavaScript / Razor
- **Database** — SQLite + Entity Framework Core
- **Charts** — Chart.js
- **Theme** — Anime / Manga UI with CSS animations

---

## 🚀 Quick Setup

### Prerequisites
- .NET 10 SDK
- VS Code

### Steps

1. Clone the repository
2. Open in VS Code
3. Run in terminal:

dotnet restore
dotnet run

4. Open browser at:

http://localhost:5041

---

## 🎮 Three Cognitive Games

### 1. 🐍 Whack a Mole — Reaction Test
- 4x3 grid of holes
- Anime mole characters pop up randomly
- Hit correct moles avoid bad ones
- Combo system rewards consecutive hits
- 30 second timer
- Score = total points divided by 4

### 2. 🔢 Math Challenge — Memory Test
- 10 math questions
- 3 difficulty levels
- 4 answer options per question
- Streak bonus for consecutive correct answers
- 10 second per question timer
- Score = (correct answers / 10) x 100

### 3. 🔤 Word Scramble — Focus Test
- Unscramble coding and computer science terms
- Click letter tiles to build answer
- Hint system available (3 hints)
- Time bonus for faster answers
- Streak bonus system
- Score = (total points / 150) x 100

---

## 📁 Project Structure

```
NeuroTrack/
├── Controllers/
│   ├── HomeController.cs
│   ├── TestController.cs
│   └── ResultController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   └── TestResult.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Test/
│   │   ├── Reaction.cshtml
│   │   ├── Memory.cshtml
│   │   └── Focus.cshtml
│   └── Result/
│       └── Dashboard.cshtml
├── wwwroot/
│   └── css/
│       └── site.css
└── Program.cs
```

---

## 🔄 How It Works

1. User opens home page and clicks Start Test
2. Completes Whack a Mole game
3. Score saved to C# Session
4. Completes Math Challenge game
5. Score saved to C# Session
6. Completes Word Scramble game
7. Score saved to C# Session
8. ResultController reads all 3 session scores
9. Calculates overall score
10. Saves result to SQLite database
11. Displays gamified dashboard

---

## 📊 Scoring Logic

| Test | Formula |
|------|---------|
| Reaction | Math.min(100, totalPoints / 4) |
| Memory | (correctAnswers / 10) x 100 |
| Focus | Math.min(100, totalPoints / 150 x 100) |
| Overall | (Reaction + Memory + Focus) / 3 |

---

## 🏆 Gamification

| Overall Score | Level | Badge |
|--------------|-------|-------|
| Below 50 | Beginner | Needs Improvement |
| 50 to 79 | Intermediate | Good |
| 80 to 100 | Pro | Excellent |

XP Points = Overall Score x 10 (Max 1000)

---

## 🗄️ Database

SQLite database stores:
- Id (Primary Key)
- ReactionScore
- MemoryScore
- FocusScore
- OverallScore
- Date

---

## 🌟 Future Scope

- User authentication system
- AI based performance analysis
- Mobile app using .NET MAUI
- Global leaderboard system
- Cloud deployment on Azure

---

## 👩‍💻 Developer

Divyanshi Bijalwan
BCA Student
