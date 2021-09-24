using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Model
{
    public class UserModel
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The phone is required")]
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
