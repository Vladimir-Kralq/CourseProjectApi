namespace CourseProjectApi.Models
{
    public class CourseTeacher
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
