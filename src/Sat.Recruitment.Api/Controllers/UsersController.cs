using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Services.Abstractions;
using System;
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
        public async Task<IActionResult> CreateUser(UserModel userModel)
        {
            try
            {
                var userDto = userModel.GetDtoFromModel();

                userDto.Money = _transactionServices.GenerateAmountByUserType(userDto);

                userDto.Email = _transactionServices.GetEmail(userDto);

                var userStatus = _validateServices.ValidateUserGeneration(userDto);              

                return Ok(userStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
