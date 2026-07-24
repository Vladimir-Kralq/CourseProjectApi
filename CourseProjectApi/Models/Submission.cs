namespace CourseProjectApi.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string Content { get; set; } 
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}