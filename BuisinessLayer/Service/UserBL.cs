using Azure;
using Azure.Core;
using BuisinessLayer.CustomException;
using BuisinessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Service
{
    public class UserBL(IUserRL userRepo, IConfiguration _configuration) : IUserBL
    {






        private User MapToEntity(UserRequest request)
        {
            return new User
            {
                name = request.name,
                email = request.email,
                password = Encrypt(request.password),
                mobileNumber = request.mobileNumber

            };
        }
        private String Encrypt(String password)
        {
            byte[] passByte = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passByte);
        }
        private String Decrypt(String encryptedPass)
        {
            byte[] passbyte = Convert.FromBase64String(encryptedPass);
            String res = Encoding.UTF8.GetString(passbyte);
            return res;
        }
        public bool createUser(UserRequest request)
        {
           return userRepo.createUser(MapToEntity(request));
        }

        public string login(string userEmail, string password)
        {
            try
            {
                User user = userRepo.login(userEmail);
                if (user == null)
                {
                    throw new UserNotFoundException("UserNot in DataBase please register");
                }
                else
                {
                    if (password.Equals(Decrypt(user.password)))
                        return generateToken(user);
                    else
                        throw new PasswordMissMatchException("incorrect Password Entered By User");
                }
            }
            catch(InvalidOperationException)
            {
                throw new UserNotFoundException("UserNot in DataBase please register");

            }

        }

        public String generateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("userId",user.userId.ToString()),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Name,user.name)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:Minutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
