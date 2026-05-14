using Microsoft.AspNetCore.Mvc;
using NeuroTrack.Data;
using NeuroTrack.Models;

namespace NeuroTrack.Controllers
{
    public class TestController : Controller
    {
        private readonly NeuroTrackDbContext _context;

        public TestController(NeuroTrackDbContext context)
        {
            _context = context;
        }

        // GET: /Test/Reaction
        public IActionResult Reaction() => View();

        // GET: /Test/Memory
        public IActionResult Memory() => View();

        // GET: /Test/Focus
        public IActionResult Focus() => View();

        // POST: /Test/Submit
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] TestSessionViewModel data)
        {
            if (data == null)
                return BadRequest();

            // Score calculations
            double reactionScore = CalculateReactionScore(data.ReactionTime);
            double memoryScore = data.MemoryScore;
            double focusScore = data.FocusScore;
            double overall = Math.Round((reactionScore + memoryScore + focusScore) / 3.0, 1);

            string level = overall >= 80 ? "Pro" : overall >= 50 ? "Intermediate" : "Beginner";
            string badge = overall >= 80 ? "Excellent 🏆" : overall >= 50 ? "Good 🥈" : "Needs Improvement 🌱";
            int xp = (int)(overall * 10);

            var result = new TestResult
            {
                ReactionTime = data.ReactionTime,
                MemoryScore = memoryScore,
                FocusScore = focusScore,
                OverallScore = overall,
                Level = level,
                Badge = badge,
                XP = xp,
                Date = DateTime.Now
            };

            _context.TestResults.Add(result);
            await _context.SaveChangesAsync();

            return Json(new { id = result.Id });
        }

        // GET: /Test/Dashboard/5
        public async Task<IActionResult> Dashboard(int id)
        {
            var result = await _context.TestResults.FindAsync(id);
            if (result == null) return NotFound();
            return View(result);
        }

        // GET: /Test/History
        public IActionResult History()
        {
            var results = _context.TestResults
                .OrderByDescending(r => r.Date)
                .ToList();
            return View(results);
        }

        // Helper: map reaction time (ms) to score 0–100
        private static double CalculateReactionScore(double ms)
        {
            // < 200ms = 100, > 800ms = 0
            if (ms <= 200) return 100;
            if (ms >= 800) return 0;
            return Math.Round(100 - ((ms - 200) / 6.0), 1);
        }
    }
}
