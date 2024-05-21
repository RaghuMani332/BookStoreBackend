using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RepositaryLayer.Service
{
    public class WishListRL : IWishListRL
    {
        private readonly DapperContext _context;

        public WishListRL(DapperContext context)
        {
            _context = context;
        }

        public bool addWishList(WishList wishList)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "INSERT INTO WishList (UserId, BookId) VALUES (@UserId, @BookId);";
                var result = connection.Execute(query, new { wishList.UserId, wishList.BookId });
                return result > 0;
            }
        }

        public bool deleteWishList(int uId, int wishListId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "DELETE FROM WishList WHERE UserId = @UserId AND WishListId = @WishListId;";
                var result = connection.Execute(query, new { UserId = uId, WishListId = wishListId });
                return result > 0;
            }
        }

        public List<Object> getWishList(int uId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT w.WishListId,w.bookId,w.userId,b.* FROM WishList w inner join Books b on w.bookId = b.bookId where w.UserId=@UserId;";
                var wishLists = connection.Query<Object>(query, new { UserId = uId }).ToList();
                return wishLists;
            }
        }
    }
}
