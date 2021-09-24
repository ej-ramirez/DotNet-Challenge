using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Services.Abstractions
{
    public interface ITransactionServices
    {
        decimal GenerateAmountByUserType(decimal amount, UserType userType);        
    }
}
