﻿using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Domain.Enums;
using System.Text.Json.Serialization;

namespace HAN.OOSE.ICDE.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }

        protected override bool IsValidEntity()
        {
            if (string.IsNullOrEmpty(Email)) return false;
            if (string.IsNullOrEmpty(Password)) return false;
            if (string.IsNullOrEmpty(FirstName)) return false;
            if (string.IsNullOrEmpty(LastName)) return false;

            return true;
        }
    }
}
