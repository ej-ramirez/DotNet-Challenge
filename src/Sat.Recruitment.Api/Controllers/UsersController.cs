using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Services.Abstractions;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ITransactionServices _transactionServices;
        private readonly IValidateServices _validateServices;

        public UsersController(ITransactionServices transactionServices, IValidateServices validateServices)
        {
            _transactionServices = transactionServices;
            _validateServices = validateServices;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<UserGenerationStatus> CreateUser(UserModel userModel)
        {
            var userDto = userModel.ObtenerDTODesdeModel();

            userDto.Money = _transactionServices.GenerateAmountByUserType(userDto);

            userDto.Email = _transactionServices.GetEmail(userDto);

            return _validateServices.ValidateUserGeneration(userDto);
        }
    }
}
