﻿using ApperTech.Akaratak.Authorization.Users;

namespace ApperTech.Akaratak.Authentication.External
{
    public class ExternalAuthUserInfo
    {
        public string ProviderKey { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Surname { get; set; }

        public string Provider { get; set; }

        public UserType UserType { get; set; }

        public string PhotoUrl { get; set; }
    }
}
