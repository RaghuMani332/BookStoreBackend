using BuisinessLayer.Interface;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using RepositaryLayer.Interface;

namespace BuisinessLayer.Service
{
    public class CartBL(ICartRL cartRepo) : ICartBL
    {
        private Cart MapToEntity(CartRequest request)
        {
            return new Cart
            {
                bookId=request.bookId,
                quantity=request.quantity,
                userId=request.userId
            };
        }
        public bool addCart(CartRequest request)
        {
            return cartRepo.addCart(MapToEntity(request));
        }

        public Cart getByUserId(int id)
        {
           return cartRepo.getByUserId(id);
        }

        public bool updateCartOrder(int cartId, bool isOrdered)
        {
            return cartRepo.updateCartOrder(cartId, isOrdered);
        }

        public bool updateCartquantity(int cartId, int quantity)
        {
            return cartRepo.updateCartquantity(cartId, quantity);
        }
    }
}
