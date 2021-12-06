using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tomtec.Lib.Utils;

namespace Tomtec.Lib.Models.DTOs
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public IEnumerable<int> RolesIds { get; set; }

        //Address
        public string Street { get; set; }
        public string Number { get; set; }
        public string AdditionalInformation { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryName { get; set; }
        

        public User ToModel()
        {
            string salt = HashHelper.GeneratePasswordSalt();
            string password = BCrypt.Net.BCrypt.HashPassword(this.Password, salt);
            var user = new User()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = password,
                PasswordSalt = salt,
                UserTypeId = this.UserTypeId,
                Address = new Address() {
                                Street = this.Street,
                                Number = this.Number,
                                AdditionalInformation = this.AdditionalInformation,
                                PostalCode = this.PostalCode,
                                City = this.City,
                                State = this.State,
                                CountryName = this.CountryName,
                            },
            };
            user.UserRoles = this.RolesIds.Select(id => new UserRoles() { RoleId = id, User = user }).ToList();

            return user;
        }
    }
}
