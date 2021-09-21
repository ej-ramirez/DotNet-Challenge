using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Services.Abstractions
{
    public interface IValidateServices
    {
        UserGenerationStatus ValidateUserGeneration(UserDTO userDTO);
    }
}
