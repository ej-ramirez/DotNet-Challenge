using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Entities
{
    public class UserGenerationStatus
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
