using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Services.Abstractions;
using System;

namespace Sat.Recruitment.Services.Implementations
{
    public class TransactionServices : ITransactionServices
    {
        public TransactionServices() { }

        public decimal GenerateAmountByUserType(UserDTO userDTO)
        {
            if (userDTO.UserType == UserType.Normal)
            {
                if (userDTO.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = userDTO.Money * percentage;
                    userDTO.Money += gif;
                }

                if (userDTO.Money < 100 && userDTO.Money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = userDTO.Money * percentage;
                    userDTO.Money += gif;
                }
            }

            if (userDTO.UserType == UserType.SuperUser && userDTO.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = userDTO.Money * percentage;
                userDTO.Money += gif;                
            }

            if (userDTO.UserType == UserType.Premium && userDTO.Money > 100)
            {
                var gif = userDTO.Money * 2;
                userDTO.Money += gif;
            }

            return userDTO.Money;

            //switch (userDTO.UserType)
            //{
            //    case UserType.Normal:
            //        break;
            //    case UserType.SuperUser:
            //        break;
            //    case UserType.Premium:
            //        break;
            //    default:
            //        break;
            //}
        }

        public string GetEmail(UserDTO userDTO)
        {
            //Normalize email
            var aux = userDTO.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return userDTO.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
