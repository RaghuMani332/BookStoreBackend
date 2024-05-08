using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Service
{
    public class CartRL(DapperContext context) : ICartRL
    {
        public bool addCart(Cart cart)
        {
            IDbConnection con= context.CreateConnection();
            string insertQuery = @"INSERT INTO Cart (quantity, userId, bookId, isOrdered) 
                                       VALUES (@quantity, @userId, @bookId, @isOrdered)";

           int nora= con.Execute(insertQuery, cart);
            return nora > 0;
        }

        public Cart getByUserId(int id)
        {
            IDbConnection con = context.CreateConnection();
            string query = @"SELECT * FROM Cart WHERE userId = @UserId";
            return con.QueryFirstOrDefault<Cart>(query, new { UserId = id });
        }

        public bool updateCartOrder(int cartId, bool isOrdered)
        {
            IDbConnection con = context.CreateConnection();
            string query = @"UPDATE Cart SET isOrdered = @IsOrdered WHERE cartId = @CartId";
            int rowsAffected = con.Execute(query, new { CartId = cartId, IsOrdered = isOrdered });
            return rowsAffected > 0;
        }

        public bool updateCartquantity(int cartId, int quantity)
        {
            IDbConnection con = context.CreateConnection();
            string query = @"UPDATE Cart SET quantity = @Quantity WHERE cartId = @CartId";
            int rowsAffected = con.Execute(query, new { CartId = cartId, Quantity = quantity });
            return rowsAffected > 0;
        }
    }
}
