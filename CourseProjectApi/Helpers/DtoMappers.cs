using CourseProjectApi.Dtos;
using CourseProjectApi.Models;

namespace CourseProjectApi.Helpers
{
    public static class DtoMappers
    {
        public static User MapUserDtoToModel(UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
            };
        }
    }
}
