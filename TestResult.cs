using System.ComponentModel.DataAnnotations;

namespace NeuroTrack.Models
{
    public class TestResult
    {
        public int Id { get; set; }

        [Required]
        public double ReactionTime { get; set; }   // in milliseconds

        [Required]
        public double MemoryScore { get; set; }    // 0–100

        [Required]
        public double FocusScore { get; set; }     // 0–100

        public double OverallScore { get; set; }

        public string Level { get; set; } = string.Empty;

        public string Badge { get; set; } = string.Empty;

        public int XP { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
