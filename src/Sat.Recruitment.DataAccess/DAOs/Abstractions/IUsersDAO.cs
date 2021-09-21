using Sat.Recruitment.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.DataAccess.DAOs.Abstractions
{
    public interface IUsersDAO
    {
        IList<UserDTO> GetUsersFile();
    }
}
