using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interface
{
    public interface ICartBL
    {
        bool addCart(CartRequest request);
        List<CartResponce> getByUserId(int id);
        bool updateCartOrder(int cartId, bool isOrdered);
        bool updateCartquantity(int cartId, int quantity);
    }
}
