using Sat.Recruitment.Domain.DTOs;
using System.Collections.Generic;

namespace Sat.Recruitment.DataAccess.DAOs.Abstractions
{
    public interface IUsersDAO
    {
        IEnumerable<UserDTO> GetUsersFile();
    }
}
