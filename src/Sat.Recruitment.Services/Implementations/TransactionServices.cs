using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Services.Abstractions;
using System;

namespace Sat.Recruitment.Services.Implementations
{
    public class TransactionServices : ITransactionServices
    {
        public TransactionServices() { }

        public decimal GenerateAmountByUserType(decimal amount, UserType userType)
        {
            switch (userType)
            {
                case UserType.Normal:
                    amount = CalculateNormalUserAmount(amount);
                    break;
                case UserType.SuperUser:
                    amount = CalculateSuperUserAmount(amount);
                    break;
                case UserType.Premium:
                    amount = CalculatePremiumUserAmount(amount);
                    break;
                default:
                    break;
            }

            return amount;
        }

        private decimal CalculateNormalUserAmount(decimal amount)
        {
            decimal higherPercentage = Convert.ToDecimal(0.12);
            decimal lowerPercentage = Convert.ToDecimal(0.8);           

            if (amount > 100)            
                //If new user is normal and has more than USD100
                amount += amount * higherPercentage;

            if (amount <= 100 && amount > 10)            
                amount += amount * lowerPercentage;            

            return amount;
        }

        private decimal CalculateSuperUserAmount(decimal amount)
        {
            var percentage = Convert.ToDecimal(0.20);

            if (amount  > 100)
                amount += amount * percentage;          

            return amount;
        }

        private decimal CalculatePremiumUserAmount(decimal amount)
        {
            if (amount > 100)
                amount += amount * 2;           

            return amount;
        }
    }
}
