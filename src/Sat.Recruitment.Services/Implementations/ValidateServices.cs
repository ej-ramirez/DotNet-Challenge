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
            if (ValidateIfUserIsDuplicated(userDTO))
                return new UserGenerationStatus { IsSuccess = false, Errors = "User is duplicated"};

            return new UserGenerationStatus { IsSuccess = true, Errors = "User Created"};
        }

        private bool ValidateIfUserIsDuplicated(UserDTO user)
        {
            var usersFile = _userDAO.GetUsersFile();

            foreach (var users in usersFile)
            {
                if (users.Email == user.Email
                    ||
                    users.Phone == user.Phone
                    ||
                    users.Name == user.Name
                    ||
                    users.Address == user.Address)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
