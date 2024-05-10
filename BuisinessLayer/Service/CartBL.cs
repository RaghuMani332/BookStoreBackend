using BuisinessLayer.Interface;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
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
            List<CartResponce> li = cartRepo.getByUserId(request.userId);
            if(li==null||!li.Any()) {
                return cartRepo.addCart(MapToEntity(request));
            }

            foreach (var item in li)
            {
                if (item.BookId == request.bookId)
                {
                    if (item.IsOrdered)
                        return cartRepo.addCart(MapToEntity(request));
                    else
                        return false;

                }
               



            }
            return cartRepo.addCart(MapToEntity(request));

        }
        /* public bool addCart(CartRequest request)
         {
             List<Cart> cartList = cartRepo.getByUserId(request.userId);

             var existingCart = cartList.FirstOrDefault(item => item.bookId == request.bookId && item.isOrdered);

             if (existingCart != null)
             {
                 return cartRepo.addCart(MapToEntity(request));
             }

             return false;
         }
 */

        public List<CartResponce> getByUserId(int id)
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
