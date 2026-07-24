using System.Text.Json.Serialization;

namespace CourseProjectApi.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
