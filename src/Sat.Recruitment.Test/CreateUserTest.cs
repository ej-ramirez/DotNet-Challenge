using Moq;
using NUnit.Framework;
using Sat.Recruitment.DataAccess.DAOs.Abstractions;
using Sat.Recruitment.DataAccess.DAOs.Implementation.File;
using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Services.Implementations;

namespace Sat.Recruitment.Test
{
    [TestFixture]
    public class CreateUserTest
    {
        private Mock<IUsersDAO> _saldoDAO;

        [SetUp]
        public void Setup()
        {
            _saldoDAO = new Mock<IUsersDAO>();
        }

        [Test]
        public void Create_New_User_Not_Exists_In_File()
        {
            var userDTO = new UserDTO
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = 0,
                Money = 1234
            };

            var result = new ValidateServices(_saldoDAO.Object).ValidateUserGeneration(userDTO);

            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("User Created", result.Errors);
        }

        [Test]
        public void Validate_If_User_Exists_In_File()
        {
            var userInformation = new UserDTO
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = 0,
                Money = 124
            };

            var files = new UsersDAO().GetUsersFile();

            _saldoDAO.Setup(x => x.GetUsersFile()).Returns(files);

            var result = new ValidateServices(_saldoDAO.Object).ValidateUserGeneration(userInformation);

            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual("User is duplicated", result.Errors);
        }
    }
}
