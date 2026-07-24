namespace CourseProjectApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}