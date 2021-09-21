using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Model
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public UserType UserType { get; set; }

        public decimal Money { get; set; }

        public UserDTO GetDtoFromModel() =>
            new UserDTO
            {
                Name = Name,
                Email = Email,
                Address = Address,
                Phone = Phone,
                UserType = UserType,
                Money = Money,
            };
    }
}
