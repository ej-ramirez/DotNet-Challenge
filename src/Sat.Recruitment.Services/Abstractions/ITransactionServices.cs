using Sat.Recruitment.Domain.DTOs;

namespace Sat.Recruitment.Services.Abstractions
{
    public interface ITransactionServices
    {
        decimal GenerateAmountByUserType(UserDTO userDTO);

        string GetEmail(UserDTO userDTO);
        
    }
}
