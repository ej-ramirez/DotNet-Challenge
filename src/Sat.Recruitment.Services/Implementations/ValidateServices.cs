using Sat.Recruitment.DataAccess.DAOs.Abstractions;
using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Services.Abstractions;

namespace Sat.Recruitment.Services.Implementations
{
    public class ValidateServices : IValidateServices
    {
        private readonly IUsersDAO _userDAO;
        public ValidateServices(IUsersDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public UserGenerationStatus ValidateUserGeneration(UserDTO userDTO)
        {
            var result = new UserGenerationStatus();

            var userFile = _userDAO.GetUsersFile();

            foreach (var users in userFile)
            {
                if (users.Email == userDTO.Email
                    ||
                    users.Phone == userDTO.Phone
                    ||
                    users.Name == userDTO.Name
                    ||
                    users.Address == userDTO.Address)
                {
                    result.IsSuccess = false;
                    result.Errors = "User is duplicated";
                }
                else
                {
                    result.IsSuccess = true;
                    result.Errors = "User Created";
                }
            }

            return result;
        }
    }
}
