using ModelLayer.DTO.Responce;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Interface
{
    public interface ICartRL
    {
        bool addCart(Cart cart);
        List<CartResponce> getByUserId(int id);
        bool updateCartOrder(int cartId, bool isOrdered);
        bool updateCartquantity(int cartId, int quantity);
    }
}
