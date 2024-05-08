using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System.Data;
using static Dapper.SqlMapper;

namespace RepositaryLayer.Service
{
    public class UserRL(DapperContext context) : IUserRL
    {
        public bool createUser(User entity)
        {
           IDbConnection con=context.CreateConnection();
            string sql = @"INSERT INTO BookStoreBackend (name, email, password, mobileNumber)
                               VALUES (@name, @email, @password, @mobileNumber)";
            int rowsAffected = con.Execute(sql, entity);
            return rowsAffected > 0;
        }

        public User login(string userEmail)
        {
            IDbConnection con = context.CreateConnection();
            string sql = "select * from BookStoreBackend where email=@userEmail";
            User entity = con.Query<User>(sql, new { userEmail =userEmail}).First();
            return entity;
        }
    }
}
