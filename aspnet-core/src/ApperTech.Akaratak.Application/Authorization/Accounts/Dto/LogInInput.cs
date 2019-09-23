using System;
using System.Collections.Generic;
using System.Text;

namespace ApperTech.Akaratak.Authorization.Accounts.Dto
{
    public class LogInInput
    {
        public string UsernameOrEmailAddress { get; set; }
        public string Password { get; set; }
    }
}
