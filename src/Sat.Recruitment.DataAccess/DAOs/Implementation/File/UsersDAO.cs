using Sat.Recruitment.DataAccess.DAOs.Abstractions;
using Sat.Recruitment.Domain.DTOs;
using Sat.Recruitment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.DataAccess.DAOs.Implementation.File
{
    public class UsersDAO : IUsersDAO
    {
        public UsersDAO() { }

        public IEnumerable<UserDTO> GetUsersFile()
        {
            var users = new List<UserDTO>();

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                string[] line = reader.ReadLineAsync()?.Result?.Split(',');

                var user = new UserDTO
                {
                    Name = line[0].ToString(),
                    Email = line[1].ToString(),
                    Phone = line[2].ToString(),
                    Address = line[3].ToString(),
                    UserType = (UserType)Enum.Parse(typeof(UserType), line[4].ToString()),
                    Money = decimal.Parse(line[5].ToString()),
                };

                users.Add(user);
            }

            reader.Close();

            return users;
        }

    }
}
