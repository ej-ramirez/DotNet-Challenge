using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Model
{
    public class UserModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string phone { get; set; }

        public UserType userType { get; set; }

        public decimal money { get; set; }

        public UserDTO ObtenerDTODesdeModel() =>
            new UserDTO
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = money,
            };
    }
}
